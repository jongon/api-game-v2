using Api_Game.Enums;

namespace Api_Game.Models
{
    public class Pegi
    {
        public PegiEnum Rating { get; set; }

        public string Synopsis { get; set; }
    }
}