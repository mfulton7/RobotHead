using System;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cleverbot.Net;
using Serial_UI;
using System.Windows.Forms;

namespace Serial_UI
{
    class SpeechHandler
    {
        private Thread l_Thread;
        private bool should_Listen = false;
        private SpeechRecognitionEngine recognizer;
        private SpeechSynthesizer synth;
        private CleverbotSession session;

        public SpeechHandler()
        {
            session = Cleverbot.createSession();
            recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            synth = new SpeechSynthesizer();

            recognizer.SetInputToDefaultAudioDevice();
            synth.SetOutputToDefaultAudioDevice();

            DictationGrammar defaultDictationGrammar = new DictationGrammar();
            defaultDictationGrammar.Name = "default dictation";
            defaultDictationGrammar.Enabled = true;
            recognizer.LoadGrammar(defaultDictationGrammar);

            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
        }

        public void Begin_Listening()
        {
            if (l_Thread == null)
            {
                l_Thread = new Thread(new ThreadStart(listening));
                l_Thread.Start();
                should_Listen = true;
            }
            else
            {
                should_Listen = true;
            }
        }

        public void Stop_Listening()
        {
            should_Listen = false;
        }

        public void Close_Thread()
        {
            if (l_Thread.IsAlive)
            {
                l_Thread.Abort();
            }
        }

        private void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Speech recognized: " + e.Result.Text);
            Serial_Interface.Input_Value = e.Result.Text;

            var response = Cleverbot.getChatResponse(session, e.Result.Text);
            Console.WriteLine("Cleverbot: " + response);

            Serial_Interface.Output_Value = response;
            synth.Speak(response);
        }

        private void listening()
        {
            while (true)
            {
                if (should_Listen)
                {
                    recognizer.Recognize();
                }
            }
        }

    }
}
