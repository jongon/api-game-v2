using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Api_Game.Models
{
    public class ReleaseDate
    {
        public string Date { get; set; }

        public dynamic Platform { get; set; }
    }
}
