using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api_Game.Models
{
    public class VideoGameExcerpt
    {
        public VideoGameExcerpt()
        {
            Publishers = new HashSet<dynamic>();    
        }

        [JsonProperty(PropertyName = "id")]
        public long VideoGameId { get; set; }

        public string Name { get; set; }

        public IEnumerable<dynamic> Publishers { get; set; }

        public Tcse Tcse { get; set; }

        public Esrb Esrb { get; set; }
    }
}