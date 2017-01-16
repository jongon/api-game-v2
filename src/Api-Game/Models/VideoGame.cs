using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Game.Models
{
    public class VideoGame
    {
        public long VideoGameId { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Url { get; set; }

        public string Summary { get; set; }

        public string Storyline { get; set; }

        public IEnumerable<Company> Developers { get; set; }

        public IEnumerable<Company> Publishers { get; set; }

        public IEnumerable<Image> Cover { get; set; }

        public Esrb Esrb { get; set; }

        public Pegi Pegi { get; set; }
    }
}
