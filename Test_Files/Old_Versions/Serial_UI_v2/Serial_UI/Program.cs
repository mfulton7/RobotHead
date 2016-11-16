using System;
using System.IO.Ports;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cleverbot.Net;
using System.Windows.Forms;
using System.Data;

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
        public static void Read(SerialPort l)
        {
            while (l.IsOpen)
            {

                int waiting = 0;
                string result;

                try
                {
                    waiting = l.BytesToRead;

                    byte[] tmp = new byte[waiting];
                    //if a bytes are waiting to be read
                    if (waiting > 0)
                    {
                        //get information update
                        l.Read(tmp, 0, waiting);
                        result = Encoding.UTF8.GetString(tmp);
                        Console.WriteLine(result);
                        //Console.WriteLine(result);
                        // int place = result.Length - 1;
                        // string[] codes = result.Split('0');
                        // //if the recieved code meets the criteria for a valid code
                        // //  if(result[place] == '0' && result.Length == 4)
                        // //  {
                        // //save the updates
                        // for (int j = 0; j < codes.Length; j++)
                        // {
                        //     if (codes[j].Length == 3)
                        //     {
                        //         int motornum = int.Parse(codes[j][0].ToString());
                        //         int motorpos = int.Parse(codes[j][1].ToString());
                        //         motorpos = motorpos * 10 + int.Parse(codes[j][2].ToString());
                        //         positions[motornum] = motorpos;
                        //     }
                        // }

                        //// }

                    }
                    
                    
                    //reset waiting
                    waiting = 0;

                }
                catch (TimeoutException) { }
            }
        }
    }

   
}
