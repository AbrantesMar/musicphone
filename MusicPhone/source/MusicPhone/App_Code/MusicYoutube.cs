using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using Newtonsoft.Json;

namespace MusicPhone.App_Code
{
    public class Translate
    {
        public string id { get; set; }
        public int lang { get; set; }
        public string url { get; set; }
        public string text { get; set; }
    }

    public class Mus
    {
        public string id { get; set; }
        public string lang { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string pic_small { get; set; }
        public string pic_medium { get; set; }
    }

    public class Mu
    {
        public Mu music { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public int lang { get; set; }
        public string text { get; set; }
        public List<Translate> translate { get; set; }
        public List<Related> related { get; set; }
        public string ytid { get; set; }
        public string urlYoutube = "http://www.youtube.com/watch?v=";
        public event EventHandler<BuscaEventArgs> BuscaCompleted;
        public string UrlYoutube
        {
            get { return urlYoutube + ytid + "&autoplay=1"; }
            //"http://www.youtube.com/v/" + ytid + "?rel=1&color1=0x2b405b&color2=0x6b8ab6&border=1&fs=1"; }

        }

        public class BuscaEventArgs : EventArgs
        {
            public Mu music { get; private set; }

            public BuscaEventArgs(Mu music)
            {
                this.music = music;
            }
        }

        public class RootObject
        {
            public string tipo { get; set; }
            public List<Mu> mus { get; set; }
        }

        public void BuscaMusicAsync(string id)
        {
            string uriJS;
            //uriJS = this.url + nome + "/index.js";
            uriJS = "http://www.vagalume.com.br/api/search.php?musid=" + id + "&extra=ytid,relmus,relart";
            var wc = new WebClient();
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
            wc.DownloadStringAsync(new Uri(uriJS, UriKind.RelativeOrAbsolute));
        }

        private void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                var serializer = new JsonSerializer();
                RootObject root = serializer.Deserialize(new StringReader(e.Result), typeof(RootObject)) as RootObject;
                this.music = root.mus.FirstOrDefault();
                if (BuscaCompleted != null)
                    BuscaCompleted(this, new BuscaEventArgs(this.music));
            }
            catch
            {
                MessageBox.Show("Musica não encontrada ou formato incorreto.", "Desculpe!", MessageBoxButton.OK);
            }
        }
    }
    
}
