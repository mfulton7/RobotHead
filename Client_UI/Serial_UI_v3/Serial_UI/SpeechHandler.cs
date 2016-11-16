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
            Console.WriteLine("Speech recognized: " + e.Result.Text);
           // Serial_Interface.Input_Value = e.Result.Text;
            Main_UI.set_Input_Text(e.Result.Text);
            var response = Cleverbot.getChatResponse(session, e.Result.Text);
            Main_UI.set_Output_Text(response);

           // Serial_Interface.Output_Value = response;
            string[] syllables = response.Split('a', 'e', 'i', 'o', 'u', 'y');

            List<byte[]> data = new List<byte[]>();
            for(int i = 0; i< syllables.Length; i++)
            {
                data.Add(new byte[4]);
                //data[i] = new byte[4];
                data[i][0] = 0;
                data[i][1] = 200;
                int tmp = syllables[i].Length;
                tmp = tmp * 15;
                data[i][2] = (byte)tmp;
                data[i][3] = 0;
            }
            //add one final position to make sure mouth is closed when finished
            byte[] f = new byte[4];
            f[0] = 0;
            f[1] = 255;
            f[2] = 0;
            f[3] = 0;
            data.Add(f);
            //make sure link is open
            if (!Main_UI.link.IsOpen)
            {
                MessageBox.Show("Error Com Port not open...", "Error", MessageBoxButtons.OK);
            }
            else {
                //loop to write data
                for (int j = 0; j < data.Count; j++)
                {
                    Main_UI.link.Write(data[j], 0, data[j].Length);
                }
            }
            synth.Speak(response);

            if (should_listen)
            {
                recognizer.RecognizeAsync();
            }
        }




        //private void listening()
        //{
        //    while (true)
        //    {
        //        if (should_Listen)
        //        {
        //            recognizer.Recognize();
        //        }
        //    }
        //}

    }
}
