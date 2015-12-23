using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MusicPhone.App_Code
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
