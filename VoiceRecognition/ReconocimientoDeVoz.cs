using System;
using System.Speech.Recognition;

namespace VoiceRecognition
{
    internal class ReconocimientoDeVoz
    {
        SpeechRecognitionEngine speechRecognitionEngine;
        GeneradorDeVoz generadorDeVoz;
        Trabajador trabajador;
        string[] comandos;
        private readonly Menu menu;

        public ReconocimientoDeVoz(Menu menu)
        {
            this.menu = menu;
            CargarComandos(); //carga las diferentes instrucciones que puede recibir
            generadorDeVoz = new GeneradorDeVoz();
            trabajador = new Trabajador();
        }

        public void ArrancarConocimientoDeVoz()
        {
            hablar("activating voice recognition");
            CargarComandos();
        }

        public void ParaReconocimientoDeVoz()
        {
            hablar("deactivating voice recognition");
            speechRecognitionEngine.RecognizeAsyncStop();
        }

        private void CargarComandos()
        {
            // Diferentes comandos
            Console.WriteLine("Inicializando los siguientes comandos:");
            comandos = new string[] {
                "What's your name?",
                "how are you",
                "How's the weather?",
                "What's my name?",
                "open eclipse",
                "open jira",
                "open gitlab",
                "open google"

            };

            foreach(string comando in comandos)
            {
                Console.WriteLine(comando);
            }

            Choices elecciones = new Choices();
            elecciones.Add(comandos);

            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(elecciones);
            Grammar grammar = new Grammar(grammarBuilder);

            speechRecognitionEngine = new SpeechRecognitionEngine();
            speechRecognitionEngine.LoadGrammarAsync(grammar);

            // Seleccionado el dispositivo de audio
            Console.WriteLine("Seleccionado el dispositivo de audio por defecto");
            speechRecognitionEngine.SetInputToDefaultAudioDevice();
            speechRecognitionEngine.SpeechRecognized += speechRecognitionEngine_SpeechRecognized;
            speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        /*
         *  Enlace un comando de voz con una función.
         */
        private void speechRecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String textoReconocido = e.Result.Text;
            switch (textoReconocido)
            {
                case "What's your name?":
                    hablar("My name is Andromeda, nice to meet you.");
                    break;
                case "How's the weather?":
                    hablar("It is sunny.");
                    break;
                case "how are you":
                    hablar("I'm great.");
                    break;
                case "What's my name?":
                    hablar("Fran");
                    break;
                case "open eclipse":
                    hablar("Opening eclipse.");
                    break;
                case "open jira":
                    hablar("Opening jira");
                    break;
                case "open gitlab":
                    hablar("Opening gitlab");
                    break;
                case "open google":
                    hablar("Opening google");
                    break;
            }

            trabajador.HacerTrabajo(textoReconocido);
        }
        /*
         * Imprime por comandos y dice la respuesta
         */
        private void hablar(String frase)
        {
            generadorDeVoz.Hablar(frase);
            Console.WriteLine(frase);
            menu.Console = frase;
        }

    }
}