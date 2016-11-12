using System;

using System.IO.Ports;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleverbot.Net;
using System.Windows.Forms;

namespace Serial_UI
{
   
    static class Program
    {
        public static bool l_thread;
        [STAThread]
        static void Main()
        {

            //initialization stuff
            l_thread = false;
           // SpeechHandler speech = new SpeechHandler();
           // Thread oThread = new Thread(new ThreadStart(speech.Begin_Listening));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Serial_Interface());

           
        }       
    }

   
}
