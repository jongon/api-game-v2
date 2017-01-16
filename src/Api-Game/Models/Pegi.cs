using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Game.Enums;

namespace Api_Game.Models
{
    public class Pegi
    {
        public PegiEnum Rating { get; set; }

        public string Synopsis { get; set; }
    }
}
