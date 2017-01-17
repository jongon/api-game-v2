using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;

namespace Api_Game.Utils
{
    public static class GameHttpClient
    {
        public static async Task<T> GetAsync<T>(string uri, string apiKey, Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
            //using (var client = new HttpClient())
            //{
            //    client.DefaultRequestHeaders.Add("X-Mashape-Key", apiKey);
            //    client.DefaultRequestHeaders.Add("Accept", "application/json");

            //    var queryString = new QueryString();
            //    var response = client.GetAsync();
            //    var responseString = await response.Content.ReadAsStringAsync();
            //    var responseJson = JsonConvert.DeserializeObject<T>(responseString);

            //    return responseJson;
            //}
        }
    }
}
