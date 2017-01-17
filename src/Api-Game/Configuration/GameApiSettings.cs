using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Game.Configuration
{
    public class GameApiSettings
    {
        public string ApiUri { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public Dictionary<string, string> Paths { get; set; }
    }
}
