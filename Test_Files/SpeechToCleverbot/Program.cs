using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RobotChat;

namespace RobotChat
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechHandler speech = new SpeechHandler();
            Thread oThread = new Thread(new ThreadStart(speech.Begin_Listening));
            oThread.Start();
            while (!oThread.IsAlive) ;
            var session = Cleverbot.createSession();
            string message;
            Console.WriteLine("Welcome to CleverBot.Net.");
            do
            {
                Console.WriteLine("Try saying something to Cleverbot. Type \"exit\" to quit the program");
                message = Console.ReadLine();
            } while (message.ToLower().Trim() != "exit");

            //exit the test thread
            oThread.Abort();
            Environment.Exit(0);
        }
    }
}
