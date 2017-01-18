using Newtonsoft.Json;

namespace Api_Game.Models
{
    public class Company
    {
        [JsonProperty(PropertyName = "id")]
        public long CompanyId { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Url { get; set; }

        public Image Logo { get; set; }

        public string Website { get; set; }
    }
}