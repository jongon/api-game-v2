using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Game.Utils
{
    public static class TranslatorHttpClient
    {
        public static async Task<object> GetAsync<T>(string url, string apiKey, Dictionary<string, string> parameters)
        {
            return null;
            //using (var client = new HttpClient())
            //{
            //    client.DefaultRequestHeaders.Add("app_id", _id);
            //    client.DefaultRequestHeaders.Add("app_key", _key);

            //    var stringContent = new StringContent("");
            //    var response = await client.PostAsync(url, stringContent);
            //    var responseString = response.Content.ReadAsStringAsync().Result;
            //    var responseJson = JsonConvert.DeserializeObject<T>(
            //        responseString,
            //        new JsonSerializerSettings()
            //        {
            //            ContractResolver = new UnderscorePropertyNamesContractResolver()
            //        });

            //    return responseJson;
            //}
        }

        public static async Task<object> Get<T>(string url, string apiKey, Dictionary<string, string> parameters)
        {
            return null;

        }
    }
}
