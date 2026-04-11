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
            //keyboard.gen = p;
            p.Show();

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
