using System.Collections.Generic;

namespace Api_Game.Configuration
{
    public class TranslatorSettings
    {
        public string ApiUri { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public Dictionary<string, string> Parameters { get; set; }
    }
}