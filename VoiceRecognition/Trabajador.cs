using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
    class Trabajador
    {
        private ConsolaDeComandos consolaComandos = new ConsolaDeComandos();
        private string BAT_PATH = "%userprofile%/customscripts/";

        public void HacerTrabajo(String opcion)
        {
            switch (opcion)
            {
                case "What's your name?":
                    WhatYourName();
                    break;
                case "How's the weather?":
                    HowsTheWeather();
                    break;
                case "how are you":
                    HowAreYou();
                    break;
                case "What's my name?":
                    WhatsMyName();
                    break;
                case "open eclipse":
                    OpenEclipse();
                    break;
                case "open jira":
                    OpenJira();
                    break;
                case "open gitlab":
                    OpenGitLab();
                    break;
                case "open google":
                    OpenGoogle();
                    break;
            }
        }

        private void OpenGoogle()
        {
            consolaComandos.EjecutarComando("start \"\" \"www.google.com\"");
        }

        private void OpenGitLab()
        {
            consolaComandos.EjecutarComando(BAT_PATH+"gitlab");
        }

        private void OpenJira()
        {
            consolaComandos.EjecutarComando(BAT_PATH+"jira");
        }

        private void OpenEclipse()
        {
            consolaComandos.EjecutarComando(BAT_PATH+"eclipse");
        }

        private void WhatsMyName()
        {
            
        }

        private void HowAreYou()
        {
            
        }

        private void HowsTheWeather()
        {
            
        }

        private void WhatYourName()
        {
            
        }
    }
}
