using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace Api_Game.Utils
{
    public static class TranslatorHttpClient
    {
        public static async Task<T> GetAsync<T>(string uri, Dictionary<string, string> headers, Dictionary<string, string> parameters)
        {
            using (var client = new HttpClient())
            {
                foreach (var header in headers)
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);

                var completeUri = QueryHelpers.AddQueryString(uri, parameters);
                var response = await client.GetAsync(completeUri);
                var responseString = await response.Content.ReadAsStringAsync();


                var responseJson = JsonConvert.DeserializeObject<T>(
                    responseString,
                     new JsonSerializerSettings()
                     {
                         ContractResolver = new UnderscorePropertyNamesContractResolver()
                     });

                return responseJson;
            }
        }
    }
}
