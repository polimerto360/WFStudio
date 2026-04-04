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
        public static double Time
        {
            get { 
                return sw.Elapsed.TotalSeconds; 
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static WasapiOut audio_output = new WasapiOut();
        [STAThread]
        static void Main()
        {
            sw.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
