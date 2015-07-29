using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Newtonsoft.Json;

namespace WifiThermometer
{
    public static class HttpUtils<T>
    {
        /// <summary> </summary>
        /// <returns></returns>
        public static async Task<T> GetJsonDataFromUriAsync(Uri uri)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);
            var responseBodyAsText = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseBodyAsText);
        }
    }
}
