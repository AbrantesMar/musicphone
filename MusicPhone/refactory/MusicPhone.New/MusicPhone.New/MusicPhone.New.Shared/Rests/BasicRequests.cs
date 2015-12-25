using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace MusicPhone.New.Rests
{
    public class BasicRequests<T>
    {

        private static string UriApi { get; set; }

        public static async Task<T> GetJson(int? id, string uri, string uricomplitedy)
        {
            //try
            //{
            #region RequestJson
            HttpClient httpClientTeste = new HttpClient();
            //httpClientTeste.DefaultRequestHeaders.Accept.TryParseAdd("application/json");
            //UriApi
            string uriId = string.Empty;
            if (!string.IsNullOrEmpty(uricomplitedy))
            {
                uriId = uricomplitedy;

            }else
            {
                UriApi = "http://www.vagalume.com.br/";
                uriId = UriApi + uri;
                if (id != null && id != 0)
                {
                    uriId += id;
                }
            }
            
            string ResponseStringTeste = await httpClientTeste.GetStringAsync(new Uri(uriId));
            T jsonTeste = JsonConvert.DeserializeObject<T>(ResponseStringTeste);
            return jsonTeste;
            #endregion
            //}
            //catch (Exception ex)
            //{
            //}

        }

        public static async void PostJson(object Object, string uri)
        {
            try
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                    client.BaseAddress = new Uri(UriApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var json_object = JsonConvert.SerializeObject(Object);
                    var response = await client.PostAsync(uri, new StringContent(json_object.ToString(), Encoding.Unicode, "application/json"));
                    var dataReceived = response.StatusCode;
                    var dRec = new DataContractJsonSerializer(typeof(T));
                }

            }
            catch (Exception ex)
            {
            }

        }
    }
}
