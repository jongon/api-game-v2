using Newtonsoft.Json;

namespace Api_Game.Models
{
    public class VideoGameName
    {
        [JsonProperty(PropertyName = "id")]
        public long VideoGameId { get; set; }

        public string Name { get; set; }
    }
}