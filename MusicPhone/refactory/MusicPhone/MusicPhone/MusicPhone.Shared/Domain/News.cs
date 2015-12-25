using System;
using System.Collections.Generic;
using System.IO;

namespace MusicPhone.Domain
{
    public class News
    {
#region "Antigo"
        //public class New
        //{
        //    public string headline { get; set; }
        //    public string kicker { get; set; }
        //    public string url { get; set; }
        //    public string inserted { get; set; }
        //    public string modified { get; set; }
        //    public string pic_src { get; set; }
        //    public string pic_width { get; set; }
        //    public string pic_height { get; set; }
        //    public string pic_caption { get; set; }
        //}

        //public class RootObject
        //{
        //    public List<New> news { get; set; }
        //}
#endregion
        public string uri = "http://www.vagalume.com.br/news/index.js";
        public News newus;
        public  List<News> news;
        public string headline { get; set; }
        public string kicker { get; set; }        
        public string inserted { get; set; }
        public string modified { get; set; }
        public string pic_src { get; set; }
        public string pic_width { get; set; }
        public string pic_height { get; set; }
        public string pic_caption { get; set; }

        public News()
        {

        }

        public class RootObject
        {
            public List<News> news { get; set; }
        }

        public class BuscaEventArgs : EventArgs
        {
            public List<News> news { get; private set; }

            public BuscaEventArgs(List<News> news)
            {
                this.news = news;
            }
        }

        public event EventHandler<BuscaEventArgs> BuscaCompleted;

//        public void BuscaNewscaAsync()
//        {
//            try
//            {
//                WebClient wc = new WebClient();
//                wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
//                wc.DownloadStringAsync(new Uri(uri, UriKind.RelativeOrAbsolute));
//                #region w8
//                ////var wc = new HttpClient();


//                ////string responseText = await Serve(uriJS);
//                //string responseText = Serve(uriJS);
//                //RootObject root;
                
//                //Stream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(responseText));
//                //JSONSerializer serializer = new DataContractJsonSerializer(typeof(RootObject));
                
//                ////stream = Encoding.Unicode.GetBytes(responseText);
//                ////root = (List<RootObject>)serializer.ReadObject(stream);
//                //var teste = serializer.ReadObject(stream);
//                ////DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<usernew_timeline>));
                

//                ////RootObject root = serializer.Deserialize(new StringReader(result), typeof(RootObject)) as RootObject;
//                //root = teste as RootObject;
//                //this.news = root.news;

//                //if (BuscaCompleted != null)
//                //    BuscaCompleted(this, new BuscaEventArgs(this.news));
//#endregion

//            }
//            catch (Exception e)
//            {
//                throw new Exception(e.Message);
//            }
//        }


//        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
//        {
//            try
//            {

//                JsonSerializer serializer = new JsonSerializer();
//                RootObject root = serializer.Deserialize(new StringReader(e.Result), typeof(RootObject)) as RootObject;

//                this.news = root.news;

//                if (BuscaCompleted != null)
//                    BuscaCompleted(this, new BuscaEventArgs(this.news));
//                //Stream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(e.Result));
//                //JsonSerializer serializer = new JsonSerializer();// DataContractJsonSerializer(typeof(RootObject));//= new JsonSerializer();
//                ////RootObject root = serializer.Deserialize(new StringReader(e.Result), typeof(List<RootObject>)) as RootObject;
//                //JsonReader j;
//                //j.Value = serializer.Deserialize(new Stream(System.Text.Encoding.UTF8.GetBytes(e.Result)), typeof(RootObject));
//                //var test = serializer.Deserialize(j, typeof(RootObject));//, typeof(RootObject)) as RootObject;

//                //if (BuscaCompleted != null)
//                //    BuscaCompleted(this, new BuscaEventArgs(this));
//            }
//            catch
//            {
//            }
//        }


        //public Task<string> Serve(string nome)
        //{

        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.GetAsync(nome);
        //    return await response.Content.ReadAsStringAsync();
        //}
    }
}
