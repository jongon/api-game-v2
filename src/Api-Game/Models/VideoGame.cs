using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Api_Game.Models
{
    public class VideoGame
    {
        [JsonProperty(PropertyName = "id")]
        public long VideoGameId { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Url { get; set; }

        public string Summary { get; set; }

        public string Storyline { get; set; }

        //It Could be long or Company
        public IEnumerable<dynamic> Developers { get; set; }

        //It Could be long or Company
        public IEnumerable<dynamic> Publishers { get; set; }

        public Image Cover { get; set; }

        public Esrb Esrb { get; set; }

        public Pegi Pegi { get; set; }
    }
}
