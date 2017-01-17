using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Game.Models
{
    public class Translation
    {
        public string translatedText { get; set; }
        public string detectedSourceLanguage { get; set; }
    }

    public class Translate
    {
        public IEnumerable<Translation> translations { get; set; }
    }

    public class DataTranslate
    {
        public Translate data { get; set; }
    }
}
