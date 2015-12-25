using System;
using System.Net;
using System.Windows;
using System.Collections.Generic;
using MusicPhone.New.Rests;
using System.Threading.Tasks;
//using Newtonsoft.Json;
//using System.IO;

namespace MusicPhone.Domain
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

        //public class BuscaEventArgs : EventArgs
        //{
        //    public Artist artista { get; private set; }

        //    public BuscaEventArgs(Artist artista)
        //    {
        //        this.artista = artista;
        //    }
        //}

        //public event EventHandler<BuscaEventArgs> BuscaCompleted;

        //public async Task<List<Artist>> GetArtist(string nome)
        //{
        //    List<Artist> a = await BasicRequests<Artist>.GetJson(null, nome + "/index.js");
        //    return a;
        //}

        public async Task<RootObject> GetArtist(string nome)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                RootObject rootJson = await BasicRequests<RootObject>.GetJson(null, nome + "/index.js", null);
                return rootJson;
            }
            else
                return null;
        }
    }
}
