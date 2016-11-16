using System;
//add assembly reference for these
using System.Speech.Synthesis;
using System.Speech.Recognition;
//installed with Nuget
using Cleverbot.Net;

using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;

namespace ChatbotExamples
{

    public class ChatBot
    {
        SpeechSynthesizer synthesizer;
        SpeechRecognitionEngine recognizer;


        public ChatBot()
        {
            synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // (0 - 100)
            synthesizer.Rate = 0;     // (-10 - 10)

            // Create an in-process speech recognizer for the en-US locale.
            System.Globalization.CultureInfo en = new System.Globalization.CultureInfo("en-US");
            recognizer = new SpeechRecognitionEngine(en);
           
            // Create and load a dictation grammar.
            recognizer.LoadGrammar(new DictationGrammar());

            // Add a handler for the speech recognized event.
            recognizer.SpeechRecognized +=
              new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

            // Configure input to the speech recognizer.
            recognizer.SetInputToDefaultAudioDevice();

            

          }

        // Handle the SpeechRecognized event.
        static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Recognized text: " + e.Result.Text);
        }


        public void ChatLoop()
        {
            // Console.Write("Please say something: ");
            // recognizer.Recognize();

            while (true)
            {

                string answer = CallCleverbot();

                //clean input, check speed of this
                answer = Regex.Replace(answer, "[^a-zA-Z0-9% ._]", string.Empty);
                var words = answer.Split(' ');

                foreach (string word in words)
                {
                    int syllables = CalculateSyllables(word);
                    //use this info to send bytecode to Arduino
                    Console.WriteLine(word + " contains: " + syllables + " syllables.");
                   // synthesizer.Speak(word);
                    //synthesizer.SpeakAsync(word);
                    //synthesizer.Speak("");
                }
            }
        }


        public string CallCleverbot()
        {
            string question, answer = "";

            //API User and Pass Keys
            var session = CleverbotSession.NewSession("0VrnWzbEZNTu267C", "SQ6OtXq07kede794AByhwee7pMA6aewT");

            Console.Write("Ask Cleverbot Something:");
            question = Console.ReadLine();
            answer = session.Send(question);
            Console.WriteLine(answer);

            return answer;
        }


        public int CalculateSyllables(string word)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };
            int vowelCount = 0;
            word = word.ToLower();
            bool lastCharWasVowel = false;

            foreach (char letter in word)
            {

                bool foundVowel = false;

                foreach (char vowel in vowels)
                {
                    //if last letter was a vowel...
                    //example: coin
                    //only count as one
                    if (vowel == letter)
                    {
                        foundVowel = true;

                        if (lastCharWasVowel)
                        {
                            lastCharWasVowel = true;
                            break;
                        }
                        else
                        {
                            lastCharWasVowel = true;
                            vowelCount++;
                            break;
                        }

                    }
                }

                //if full cycle and no vowel found, set lastWasVowel to false;
                if (!foundVowel)
                    lastCharWasVowel = false;



            }

            //if word ends with 'e' or 'es' a syllable can be subtracted as this is usually silent.
            if(word.Length > 1)
             {
                 if(new[] { "es", "e"}.Equals(word.Substring(word.Length-2)))
                 {
                     vowelCount--;
                 }
             }

            //If no Vowels, assume 1 Syllable.
            //ex: 'hmmm'
            if (vowelCount < 1)
            {
                return 1;
            }
            else
            {
                return vowelCount;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
             ChatBot chat = new ChatBot();
             chat.ChatLoop();

        }
    }
}
