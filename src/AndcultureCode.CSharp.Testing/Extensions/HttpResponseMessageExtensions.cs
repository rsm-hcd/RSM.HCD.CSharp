using System.Net.Http;
using Newtonsoft.Json;

namespace AndcultureCode.CSharp.Testing.Extensions
{
    // TODO: Temporary until https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/pull/1 has been merged
    public static class HttpResponseMessageExtensions
    {
        /// <summary>
        /// Deserializes http response into supplied object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        public static T FromJson<T>(this HttpResponseMessage response)
        {
            var body = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(body);
        }
    }
}