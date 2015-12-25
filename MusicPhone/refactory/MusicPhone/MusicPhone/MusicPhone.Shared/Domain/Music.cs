using System;
using System.Collections.Generic;
using System.IO;

namespace MusicPhone.Domain
{
    public class Music
    {
        public Art artista { get; set; }
        public Music music;
        public string id { get; set; }
        public string name { get; set; }
        public string url = "http://www.vagalume.com.br/";
        public string urlYoutube = "http://www.youtube.com/watch?v=";
        public string UrlYoutube
        {
            get { return urlYoutube + ytid; }

        }
        public int lang { get; set; }
        public string text { get; set; }
        public List<Translate> translate { get; set; }
        public string ytid { get; set; }

        public Music()
        { }

        public class Art
        {
            public string id { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Translate
        {
            public string id { get; set; }
            public int lang { get; set; }
            public string url { get; set; }
            public string text { get; set; }
        }

        //public class Mu
        //{
        //    public string id { get; set; }
        //    public string name { get; set; }
        //    public string url { get; set; }
        //    public int lang { get; set; }
        //    public string text { get; set; }
        //    public List<Translate> translate { get; set; }
        //}

        public class RootObject
        {
            //public string type { get; set; }
            ////nome artista 
            public Music music { get; set; }
            ////titulo musica
            //public List<Music> music { get; set; }
        }

        public class BuscaEventArgs : EventArgs
        {
            public Music music { get; private set; }

            public BuscaEventArgs(Music music)
            {
                this.music = music;
            }
        }

        public event EventHandler<BuscaEventArgs> BuscaCompleted;

        //public void BuscaMusicAsync(string nome)
        //{
        //    string uriJS;
        //    uriJS = this.url + nome +"/index.js";
        //    //uriJS = "http://www.vagalume.com.br/api/search.php?musid="+id+"&extra=ytid,relmus,relart";
        //    WebClient wc = new WebClient();
        //    wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
        //    wc.DownloadStringAsync(new Uri(uriJS, UriKind.RelativeOrAbsolute));
        //}

        //void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        //{
        //    try
        //    {
        //        JsonSerializer serializer = new JsonSerializer();
        //        RootObject root = serializer.Deserialize(new StringReader(e.Result), typeof(RootObject)) as RootObject;

        //        this.music = root.music;

        //        if (BuscaCompleted != null)
        //            BuscaCompleted(this, new BuscaEventArgs(this));
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Musica não encontrada ou formato incorreto.", "Desculpe!", MessageBoxButton.OK);
        //    }
        //}
    }
}
