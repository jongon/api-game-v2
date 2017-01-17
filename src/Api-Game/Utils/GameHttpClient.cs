using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace Api_Game.Utils
{
    public static class GameHttpClient
    {
        public static async Task<T> GetAsync<T>(string uri, string apiKey, Dictionary<string, string> parameters)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Mashape-Key", apiKey);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                var completeUri = QueryHelpers.AddQueryString(uri, parameters);
                var response = await client.GetAsync(completeUri);
                var responseString = await response.Content.ReadAsStringAsync();
                var responseJson = JsonConvert.DeserializeObject<T>(responseString);

                return responseJson;
            }
        }
    }
}
