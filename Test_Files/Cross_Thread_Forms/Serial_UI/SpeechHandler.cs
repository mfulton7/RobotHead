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
using System.ComponentModel;

namespace Serial_UI
{
    class SpeechHandler
    {
        private Serial_Interface Main_UI;
        private bool should_listen;
        private SpeechRecognitionEngine recognizer;
        private SpeechSynthesizer synth;
        private CleverbotSession session;

        public SpeechHandler(Serial_Interface main_UI)
        {
            Main_UI = main_UI;
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
            Main_UI.set_Input_Text("Beginning listening!");
            Main_UI.set_Output_Text("Waiting for input to receive response!");
            recognizer.RecognizeAsync();
            should_listen = true;
        }

        public void Stop_Listening()
        {
            should_listen = false;
            recognizer.RecognizeAsyncCancel();
        }

        private void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Main_UI.set_Input_Text(e.Result.Text);
            var response = Cleverbot.getChatResponse(session, e.Result.Text);
            Main_UI.set_Output_Text(response);
            Console.WriteLine("Cleverbot: " + response);
            synth.Speak(response);

            if (should_listen)
            {
                recognizer.RecognizeAsync();
            }
        }
    }
}
