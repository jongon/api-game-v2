using Newtonsoft.Json;

namespace Api_Game.Models
{
    public class Platform
    {
        [JsonProperty(PropertyName = "id")]
        public long PlatformId { get; set; }

        public string Name { get; set; }
    }
}