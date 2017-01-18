using System.Collections.Generic;

namespace Api_Game.Configuration
{
    public class GameApiSettings
    {
        public string ApiUri { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public Dictionary<string, string> Routes { get; set; }
    }
}