using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFStudio
{
    public class NoteChannel
    {
        public Generator Target;
        public List<Note> NotesByStart = new List<Note>();
        public List<Tuple<long, Note>> CurNotes = new List<Tuple<long, Note>>();
        public int CurIndex = 0;
        public NoteChannel(Generator target)
        {
            Target = target;
            Program.mainWindow.OnReset += () =>
            {
                CurIndex = 0;
                foreach (Tuple<long, Note> n in CurNotes)
                {
                    Target.ReleaseNote(n.Item2);
                }
                CurNotes = new List<Tuple<long, Note>>();
            };
        }
        public void Update()
        {
            while (CurIndex < NotesByStart.Count && NotesByStart.Count > 0 && NotesByStart[CurIndex].Start <= Program.CurSample)
            {
                if (NotesByStart[CurIndex].Length + NotesByStart[CurIndex].Start > Program.CurSample)
                {
                    Note new_note = NotesByStart[CurIndex].Duplicate();
                    new_note.Start += Program.SampleDiff;
                    Target.PlayNote(new_note);
                    CurNotes.Add(new Tuple<long, Note>(new_note.Start - Program.SampleDiff, new_note));
                }
                CurIndex++;
            }

            foreach (var note in CurNotes.ToArray())
            {
                if ((note.Item1 + note.Item2.Length) < Program.CurSample || note.Item1 > Program.CurSample)
                {
                    Target.ReleaseNote(note.Item2);
                    CurNotes.Remove(note);
                }
            }
        }
    }
}
