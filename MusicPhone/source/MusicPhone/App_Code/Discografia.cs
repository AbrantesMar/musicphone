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
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace MusicPhone.App_Code
{

    public class Artist1
    {
        public string id { get; set; }
        public string desc { get; set; }
        public string url { get; set; }
    }

    public class Item1
    {
        public string id { get; set; }
        public string desc { get; set; }
        public string url { get; set; }
        public string cover { get; set; }
        public List<Item> discs { get; set; }
    }

    public class Discography
    {
        const string uri = "http://www.vagalume.com.br/";//u2/discografia/index.js";
        public Artist artist { get; set; }
        public List<Item1> item { get; set; }
        public Discography discografia;

        public Discography() { }

        public event EventHandler<BuscaEventArgs> BuscaCompleted;

        public string Url(string uriT)
        {
            string u = uri + uriT.Replace(" ", "%20") + "/discografia/index.js";
            return u;
        }

        public class BuscaEventArgs : EventArgs
        {
            public Discography discografia { get; private set; }

            public BuscaEventArgs(Discography discografia)
            {
                this.discografia = discografia;
            }
        }

        public void BuscaArtiscaAsync(string nome)
        {
            string uriJS;
            uriJS = uri + nome + "/index.js";
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
            wc.DownloadStringAsync(new Uri(uriJS, UriKind.RelativeOrAbsolute));
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                RootObject root = serializer.Deserialize(new StringReader(e.Result), typeof(RootObject)) as RootObject;

                this.discografia = root.discography;

                if (BuscaCompleted != null)
                    BuscaCompleted(this, new BuscaEventArgs(this));
            }
            catch
            {
            }
        }

        public class RootObject
        {
            public Discography discography { get; set; }
        }
    }
}
