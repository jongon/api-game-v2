using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api_Game.Models
{
    public class VideoGame
    {
        public VideoGame()
        {
            Developers = new HashSet<dynamic>();
            Publishers = new HashSet<dynamic>();
            ReleaseDates = new HashSet<ReleaseDate>();
        }

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

        public IEnumerable<ReleaseDate> ReleaseDates { get; set; }

        public IEnumerable<Image> Screenshots { get; set; }

        public Image Cover { get; set; }

        public Esrb Esrb { get; set; }

        public Pegi Pegi { get; set; }

        public Tcse Tcse { get; set; }
    }
}