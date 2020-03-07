using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests
{
    internal class YRequest
    {
        #region Поля

        private HttpWebRequest fullRequest;
        protected YAuthStorage storage;        

        #endregion Поля

        public YRequest(YAuthStorage userStorage)
        {
            storage = userStorage;
        }

        #region Вспомогательные функции

        protected string GetQueryString(Dictionary<string, string> query)
        {
            return string.Join("&", query.Select(p => $"{p.Key}={p.Value}"));
        }

        protected virtual HttpWebRequest FormRequest(string url, string method = WebRequestMethods.Http.Get,
            Dictionary<string, string> query = null, string body = null)
        {
            var queryStr = string.Empty;
            if (query != null && query.Count > 0)
                queryStr = "?" + GetQueryString(query);

            var uri = new Uri($"{url}{queryStr}");
            var request = WebRequest.CreateHttp(uri);

            if (storage.Context.WebProxy != null)
                request.Proxy = storage.Context.WebProxy;

            request.Method = method;
            if (storage.Context.Cookies == null)
                storage.Context.Cookies = new CookieContainer();

            if (!string.IsNullOrEmpty(body))
                using (var sw = new StreamWriter(request.GetRequestStream(), Encoding.UTF8))
                    sw.Write(body);

            request.CookieContainer = storage.Context.Cookies;
            request.KeepAlive = true;
            request.Headers[HttpRequestHeader.AcceptCharset] = Encoding.UTF8.WebName;
            request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            fullRequest = request;

            return request;
        }

        protected T Deserialize<T>(JToken token, string jsonPath = "")
        {
            JToken obj = token.SelectToken(jsonPath).ToString();
            return JsonConvert.DeserializeObject<T>(obj.ToString());
        }

        protected T Deserialize<T>(string json, string jsonPath = "")
        {
            return Deserialize<T>(JToken.Parse(json), jsonPath);
        }

        protected async Task<T> GetDataFromResponseAsync<T>(HttpWebResponse response, string jsonPath = "")
        {
            try
            {
                string result;
                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream);
                    result = await reader.ReadToEndAsync();
                }

                storage.Context.Cookies.Add(response.Cookies);
                return Deserialize<T>(result, jsonPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default(T);
            }
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public async Task<HttpWebResponse> GetResponseAsync()
        {
            return (HttpWebResponse) await fullRequest.GetResponseAsync();
        }

        public async Task<T> GetResponseAsync<T>(string jsonPath = "")
        {
            if (fullRequest == null)
                return default(T);

            using (var response = await GetResponseAsync())
                return await GetDataFromResponseAsync<T>(response, jsonPath);
        }

        #endregion Основные функции

    }
}