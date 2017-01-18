using Newtonsoft.Json;

namespace Api_Game.Models
{
    public class Genre
    {
        [JsonProperty(PropertyName = "id")]
        public long GenreId { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }
    }
}