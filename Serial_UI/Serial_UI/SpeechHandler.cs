using System;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleverbot.Net;
using Serial_UI;

namespace Serial_UI
{
    class SpeechHandler
    {
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
            while (true)
            {
                recognizer.Recognize();
            }
        }

        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //Console.WriteLine("Speech recognized: " + e.Result.Text);
            
            var response = Cleverbot.getChatResponse(session, e.Result.Text);
            Console.WriteLine("Cleverbot: " + response);
            synth.Speak(response);
            
        }
    }
}
