namespace MusicPhone.Domain
{
    public class BuscarPorTrecho
    {
        public class Art
        {
            private string uri = "http://www.vagalume.com.br/api/search.excerpt.php?q=";
            public string name { get; set; }
            //public string url { get; set; }
            public string pic_small { get; set; }
            public string pic_medium { get; set; }

            public string Uri(string trecho)
            {
                var a = trecho.Replace(" ", "%20");
                return uri+ trecho;
            }
        }

        public class Mus
        {
            public string id { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public string excerpt { get; set; }
        }

        public class RootObject
        {
            public Art art { get; set; }
            public Mus mus { get; set; }
        }
    }
}
