using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api_Game.Utils
{
    public static class TranslatorHttpClient
    {
        public static async Task<T> GetAsync<T>(string uri, Dictionary<string, string> parameters)
        {
            string responseString;
        
            using (var client = new HttpClient())
            {
                var completeUri = QueryHelpers.AddQueryString(uri, parameters);
                var response = await client.GetAsync(completeUri);
                responseString = await response.Content.ReadAsStringAsync();
            }
            
            var responseJson = JsonConvert.DeserializeObject<T>(
                responseString);

            return responseJson;
        }
    }
}