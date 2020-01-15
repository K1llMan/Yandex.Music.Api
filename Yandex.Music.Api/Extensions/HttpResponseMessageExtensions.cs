using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static JToken GetContentAsJson(this HttpWebResponse response)
        {
            var result = string.Empty;
            
            using (var stream = response.GetResponseStream())
            {
                var reader = new StreamReader(stream);

                result = reader.ReadToEnd();
            }

            return JToken.Parse(result);
        }
    }
}