using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{

    class GeneradorDeVoz
    {
        public SpeechSynthesizer speechSynthesizer;

        public GeneradorDeVoz()
        {
            speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.SelectVoiceByHints(VoiceGender.Male);
        }

        public void Hablar(String frase)
        {
            speechSynthesizer.SpeakAsync(frase);
        }

        public void MostrarLasVocesInstaladas()
        {
            foreach (InstalledVoice voice in speechSynthesizer.GetInstalledVoices())
            {
                VoiceInfo info = voice.VoiceInfo;
                Console.WriteLine(" Voice Name: " + info.Name);
            }
        }

    }
}
