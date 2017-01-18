namespace Api_Game.Utils
{
    public class Paging
    {
        public int Limit { get; set; }

        public int Offset { get; set; }

        public bool OrderAsc { get; set; }

        public string OrderParam { get; set; }
    }
}