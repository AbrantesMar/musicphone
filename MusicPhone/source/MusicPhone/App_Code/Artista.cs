using System;
using System.Net;
using System.Windows;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace MusicPhone.App_Code
{
    public class Artist
    {
        public string url = "http://www.vagalume.com.br/";
        public Artist artist;

        public bool favoritos;
        public string id { get; set; }
        public string desc { get; set; }
        //public string url { get; set; }
        public string pic_small { get; set; }
        public string pic_medium { get; set; }
        public Rank rank { get; set; }
        public List<Genre> genre { get; set; }
        public List<Related> related { get; set; }
        public Toplyrics toplyrics { get; set; }
        public Lyrics lyrics { get; set; }
        public Albums albums { get; set; }

        public class RootObject
        {
            public Artist artist { get; set; }
        }

        public Artist()
        {
        }

        public class BuscaEventArgs : EventArgs
        {
            public Artist artista { get; private set; }

            public BuscaEventArgs(Artist artista)
            {
                this.artista = artista;
            }
        }

        public event EventHandler<BuscaEventArgs> BuscaCompleted;

        public void BuscaArtiscaAsync(string nome)
        {
            try
            {
                
                string uriJS;
                uriJS = this.url + nome + "/index.js";
                WebClient wc = new WebClient();
                wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
                wc.DownloadStringAsync(new Uri(uriJS, UriKind.RelativeOrAbsolute));
            }
            catch (Exception)
            {

                MessageBox.Show("Artista não encontrado.");
            }
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                RootObject root = serializer.Deserialize(new StringReader(e.Result), typeof(RootObject)) as RootObject;

                this.artist = root.artist;

                if (BuscaCompleted != null)
                    BuscaCompleted(this, new BuscaEventArgs(this));
            }
            catch
            {
                MessageBox.Show("Artista não encontrado.");
            }
        }

    }
}
