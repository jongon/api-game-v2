using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Game.Models
{
    public class Image
    {
        public string Url { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string CloudinaryId { get; set; }
    }
}
