using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFStudio
{
    public partial class Pianoroll : Form
    {
        bool mouse_down = false;

        public int piano_width = 64;
        public int bottom_note = 48;
        public int note_count = 36;
        public int note_height
        {
            get
            {
                return Height / note_count;
            }
        }

        public double start_time = 0;
        public double time_window = 5;
        public long old_time = 0;
        public double snap = 0.25; // part of a beat
        public int time_to_pixels(double time)
        {
            return (int)(time / time_window * (Width - piano_width));
        }
        public double pixels_to_time(int pixels)
        {
            return pixels / (double)(Width - piano_width) * time_window;
        }

        public Note CurNote;
        public Note MouseNote;
        public int MouseXOffset;

        private Generator gen;
        public Generator Gen { 
            get 
            { 
                return gen; 
            } 
            set
            {
                if (value == null) return;
                gen = value;
            }
        }
        public Pianoroll(Generator gen)
        {
            InitializeComponent();
            old_time = Program.CurSample;
            Gen = gen;
            if (gen != null)
            {
                Gen.NotePlayed += (Note n) =>
                {
                    if (this.IsHandleCreated)
                    {
                        this.BeginInvoke((Action)(() =>
                        {
                            Invalidate(RectFromPianoNote(n));
                        }));
                    }
                };
                Gen.NoteReleased += (Note n) =>
                {
                    if (this.IsHandleCreated)
                    {
                        this.BeginInvoke((Action)(() =>
                        {
                            Invalidate(RectFromPianoNote(n));
                        }));
                    }
                };
            }
            MasterTrack.OnRead += (_, samples) =>
            {
                if (this.IsHandleCreated && !MasterTrack.Paused)
                {
                    this.BeginInvoke((Action)(() =>
                    {
                        Invalidate(new Rectangle(piano_width + time_to_pixels(Program.SamplesToTime(old_time) - start_time)-1, 0, 2, Height));
                        Invalidate(new Rectangle(piano_width + time_to_pixels(Program.SamplesToTime(old_time+samples) - start_time) - 1, 0, 2, Height));
                        old_time = Program.CurSample;
                    }));
                }
            };
            Program.mainWindow.OnReset += () =>
            {
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke((Action)(() =>
                    {
                        old_time = 0;
                    }));
                }
            };
        }



        private void Pianoroll_Paint(object sender, PaintEventArgs e)
        {
            // Draw piano keys
            e.Graphics.DrawLine(Pens.Black, piano_width, 0, piano_width, Height);
            for(int i = bottom_note; i < Math.Ceiling(bottom_note + Height/(double)note_height); i++)
            {
                
                int y = Height - (i - bottom_note) * note_height;
                e.Graphics.DrawLine(Pens.Gray, 0, y, Width, y);
                if(i % 12 == 0) e.Graphics.DrawString("C" + i / 12, new Font(FontFamily.GenericSansSerif, 8), Brushes.Black, 3, y - note_height);
                switch (i % 12)
                {
                    case 0: 
                    case 2:
                    case 4:
                    case 5:
                    case 7:
                    case 9:
                    case 11:
                        e.Graphics.DrawRectangle(Pens.Black, 0, y - note_height, piano_width, note_height);
                        break;
                    default:    
                        e.Graphics.FillRectangle(Brushes.Black, 0, y - note_height, piano_width, note_height);
                        break;
                }
            }

            // Draw bar lines
            double seconds_per_beat = 60 / Program.BPM;
            double seconds_per_bar = seconds_per_beat * Program.BeatsPerBar;
            int pixels_per_bar = time_to_pixels(seconds_per_bar);
            
            int cur_bar = (int)Math.Ceiling(start_time / seconds_per_bar);
            int bar_offset = piano_width + pixels_per_bar * cur_bar - time_to_pixels(start_time);
            for (int x = bar_offset; x < Width; x += pixels_per_bar) { 
                e.Graphics.DrawString(cur_bar++.ToString(), new Font(FontFamily.GenericSansSerif, 8), Brushes.Gray, x, 0);
                e.Graphics.DrawLine(Pens.Black, x, 0, x, Height);
                for(int i = 1; i < Program.BeatsPerBar; i++)
                {
                    int beat_x = x + time_to_pixels(seconds_per_beat * i);
                    e.Graphics.DrawLine(Pens.DarkGray, beat_x, 0, beat_x, Height);
                }
            }
            // Draw beat lines before the first bar line
            int cur_beat = (int)Math.Ceiling(start_time / seconds_per_beat);
            for (int x = piano_width + time_to_pixels(seconds_per_beat) * cur_beat - time_to_pixels(start_time); x < bar_offset-10; x += time_to_pixels(seconds_per_beat))
            {
                if(x > piano_width)
                e.Graphics.DrawLine(Pens.DarkGray, x, 0, x, Height);
            }

            // Draw notes on piano
            foreach (Note n in Gen.CurNotes.ToArray())
            {
                if (n.TimeSinceRelease > 0) continue;
                e.Graphics.FillRectangle(Brushes.Orange, RectFromPianoNote(n));
            }
            foreach (Note n in Gen.noteChannel.NotesByStart.ToArray())
            {
                if(time_to_pixels(Program.SamplesToTime(n.Start + n.Length) - start_time) < 0) continue;
                e.Graphics.FillRectangle(Brushes.Orange, RectFromNote(n));
            }
            e.Graphics.DrawLine(Pens.Red, piano_width + time_to_pixels(Program.SamplesToTime(Program.CurSample) - start_time), 0, piano_width + time_to_pixels(Program.SamplesToTime(Program.CurSample) - start_time), Height);

        }
        bool Inside(Point p, Rectangle r)
        {
            return p.X >= r.Left && p.X <= r.Right && p.Y >= r.Top && p.Y <= r.Bottom;
        }
        private void Pianoroll_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_down = true;
            if(e.Location.X > piano_width)
            {
                
                foreach(Note n in Gen.noteChannel.NotesByStart.ToArray())
                {
                    if(Inside(e.Location, RectFromNote(n)))
                    {
                        MouseNote = n;
                        if (e.Button == MouseButtons.Right)
                        {
                            Gen.noteChannel.NotesByStart.Remove(n);
                            goto invalidate;
                        }
                        MouseXOffset = e.Location.X - RectFromNote(n).Left;
                        break;
                    }
                }
                if(MouseNote == null)
                {
                    MouseNote = new Note(NoteStFromY(e.Location.Y), Program.audio_output.OutputWaveFormat.SampleRate, (long)(Program.audio_output.OutputWaveFormat.SampleRate * pixels_to_time(e.Location.X - piano_width) + start_time));
                    Gen.noteChannel.NotesByStart.Add(MouseNote);
                }
            }
        invalidate:
            Invalidate();
            Pianoroll_MouseMove(sender, e);
        }
        public Rectangle RectFromPianoNote(Note n)
        {
            return new Rectangle(0, Height - note_height * ((int)n.Semitones - bottom_note + 1), piano_width, note_height);
        }

        public Rectangle RectFromNote(Note n)
        {
            int cutoff = time_to_pixels(Program.SamplesToTime(n.Start) - start_time);
            int x = Math.Max(piano_width, cutoff + piano_width);
            int width = time_to_pixels(Program.SamplesToTime(n.Length));
            if (cutoff < 0) width += cutoff;
            return new Rectangle(x, Height - note_height * ((int)n.Semitones - bottom_note + 1), width, note_height);
        }
        //public void InvalidateNotes()
        //{
        //    foreach(Note n in Gen.CurNotes.ToArray())
        //    {
        //        Invalidate(RectFromPianoNote(n));
        //    }
        //}
        public int NoteStFromY(int y)
        {
            return (Height - y) / note_height + bottom_note;
        }
        public double Snap(double x, double snap)
        {
            return Math.Round(x / snap) * snap;
        }
        private void Pianoroll_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Location.X < piano_width && mouse_down)
            {
                int note_height = Height / note_count;
                int note_num =  NoteStFromY(e.Location.Y);
                if(CurNote != null)
                {
                    if (note_num == (int)CurNote.Semitones) return;
                    //Invalidate(RectFromPianoNote(CurNote));
                    Gen.ReleaseNote(CurNote);
                }
                CurNote = new Note(note_num, -1, Program.TotalSample);
                Gen.PlayNote(CurNote);
                //Invalidate(RectFromPianoNote(CurNote));
            } else if (mouse_down && MouseNote != null)
            {
                Invalidate(RectFromNote(MouseNote));
                if(MouseXOffset > time_to_pixels(Program.SamplesToTime(MouseNote.Length)) - 20)
                {
                    // grabbed tail of note, change length
                    long new_length = (long)(Program.audio_output.OutputWaveFormat.SampleRate * (pixels_to_time(e.Location.X - piano_width - MouseXOffset) + start_time)) - MouseNote.Start;
                    MouseNote.Length += new_length;
                    if (MouseNote.Length < 410) MouseNote.Length = 410;
                    MouseXOffset = e.Location.X - RectFromNote(MouseNote).Left;
                }
                else
                {
                    long new_start = (long)(Program.audio_output.OutputWaveFormat.SampleRate * Snap(pixels_to_time(e.Location.X - piano_width - MouseXOffset) + start_time, snap));
                    int new_semitones = NoteStFromY(e.Location.Y);
                    if (new_start < 0) new_start = 0;
                    MouseNote.Start = new_start;
                    MouseNote.Semitones = new_semitones;
                }
                Invalidate(RectFromNote(MouseNote));

                //InvalidateNotes();
            }
        }

        private void Pianoroll_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_down = false;
            MouseXOffset = 0;
            if (CurNote != null)
            {
                //InvalidateNotes();
                Gen.ReleaseNote(CurNote);
                CurNote = null;
            }
            if(MouseNote != null)
            {
                //InvalidateNotes();
                MouseNote = null;
                Gen.noteChannel.NotesByStart.Sort((a, b) => a.Start.CompareTo(b.Start));
                
            }
        }

        private void Pianoroll_MouseLeave(object sender, EventArgs e)
        {
            Pianoroll_MouseUp(null, null);
        }

        private void Pianoroll_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left: time_window /= 1.2; break;
                    case Keys.Right: time_window *= 1.2; break;
                    case Keys.Up: note_count++; break;
                    case Keys.Down: note_count--; break;
                    default: goto unhandled;
                }
            } 
            else if(e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Right: Program.CurSample += (int)(Program.audio_output.OutputWaveFormat.SampleRate); break;
                    case Keys.Left: Program.CurSample -= (int)(Program.audio_output.OutputWaveFormat.SampleRate); Gen.noteChannel.CurIndex = 0;  break;
                    default: goto unhandled;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Left: start_time -= time_window / 4; break;
                    case Keys.Right: start_time += time_window / 4; break;
                    case Keys.Up: bottom_note++; break;
                    case Keys.Down: bottom_note--; break;
                    default: goto unhandled;
                }

            }
            Invalidate();
            return;

        unhandled:
            Program.mainWindow.keyboard.gen = Gen;
            if(Program.mainWindow.keyboard.notes.ContainsKey(e.KeyCode)) return;
            Program.mainWindow.keyboard.KeyDown(sender, e);
            //InvalidateNotes();
        }

        private void Pianoroll_KeyUp(object sender, KeyEventArgs e)
        {
            Program.mainWindow.keyboard.gen = Gen;
            //InvalidateNotes();
            Program.mainWindow.keyboard.KeyUp(sender, e);
        }

        private void Pianoroll_ResizeEnd(object sender, EventArgs e)
        {
            Invalidate();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
