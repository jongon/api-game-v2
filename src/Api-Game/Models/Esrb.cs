using Api_Game.Enums;

namespace Api_Game.Models
{
    public class Esrb
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Thumbnail { get; set; }

        public EsrbEnum Rating { get; set; }
    }
}