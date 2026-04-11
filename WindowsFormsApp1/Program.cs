using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFStudio
{
    internal static class Program
    {
        public static Stopwatch sw = new Stopwatch();
        public static MainWindow mainWindow;
        public static double Time
        {
            get { 
                return sw.Elapsed.TotalSeconds; 
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static MasterTrack Master = new MasterTrack();
        public static WasapiOut audio_output = new WasapiOut();
        public static List<Generator> Generators = new List<Generator>();
        public static List<MixerTrack> Tracks = new List<MixerTrack>();
        [STAThread]
        static void Main()
        {
            sw.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            audio_output.Init(Master);
            audio_output.Play();
            mainWindow = new MainWindow();
            Application.Run(mainWindow);
        }
    }
}
