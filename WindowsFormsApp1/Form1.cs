using NAudio.Wave;
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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            KeyDown += keyboard.KeyDown;
            KeyUp += keyboard.KeyUp;
        }
        public Keyboard keyboard = new Keyboard();
        private void button1_Click(object sender, EventArgs e)
        {
            Synth p = new Synth();
            GeneratorUC g = new GeneratorUC();
            g.Gen = p;
            g.GenUI = p;
            //keyboard.gen = p;
            p.Show();
            
            Program.NoteChannels.Add(new NoteChannel(p));
            //Program.NoteChannels[Program.NoteChannels.Count - 1].NotesByStart.Add(new Note(69, 1, 4));
            //Program.NoteChannels[Program.NoteChannels.Count - 1].NotesByStart.Add(new Note(70, 1, 5));
            //Program.NoteChannels[Program.NoteChannels.Count - 1].NotesByStart.Add(new Note(68, 1, 6));
            //Program.NoteChannels[Program.NoteChannels.Count - 1].NotesByStart.Add(new Note(69, 1, 6.5));

            //p.KeyDown += keyboard.KeyDown;
            //p.KeyUp += keyboard.KeyUp;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            keyboard.KeyDown(sender, e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            keyboard.KeyUp(sender, e);
        }
    }
}
