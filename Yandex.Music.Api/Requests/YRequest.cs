using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Newtonsoft.Json;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Requests
{
    internal class YRequest
    {
        public YRequest(YandexMusicApi yandex, AuthStorage auth)
        {
            api = yandex;
            storage = auth;
        }

        #region Поля

        private HttpWebRequest fullRequest;
        protected YandexMusicApi api;
        protected AuthStorage storage;

        #endregion Поля

        #region Вспомогательные функции

        protected string GetQueryString(Dictionary<string, string> query)
        {
            return string.Join("&", query.Select(p => $"{p.Key}={HttpUtility.UrlEncode(p.Value)}"));
        }

        protected virtual void FormRequest(string url, string method = WebRequestMethods.Http.Get,
            Dictionary<string, string> query = null, List<KeyValuePair<string, string>> headers = null, string body = null)
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

            storage.SetHeaders(request);

            if (headers != null && headers.Count > 0)
                foreach (var header in headers)
                    request.Headers.Add(header.Key, header.Value);

            if (!string.IsNullOrEmpty(body)) {
                byte[] bytes = Encoding.UTF8.GetBytes(body);
                Stream s = request.GetRequestStream();
                s.Write(bytes, 0, bytes.Length);

                request.ContentLength = bytes.Length;
            }

            request.CookieContainer = storage.Context.Cookies;
            request.KeepAlive = true;
            request.Headers[HttpRequestHeader.AcceptCharset] = Encoding.UTF8.WebName;
            request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            fullRequest = request;
        }

        protected async Task<T> GetDataFromResponseAsync<T>(HttpWebResponse response)
        {
            try {
                string result;
                using (var stream = response.GetResponseStream()) {
                    var reader = new StreamReader(stream);
                    result = await reader.ReadToEndAsync();
                }

                storage.Context.Cookies.Add(response.Cookies);

                JsonSerializerSettings settings = new JsonSerializerSettings {
                    Converters = new List<JsonConverter> {
                        new YExecutionContextConverter(api, storage)
                    }
                };

                if (storage.Debug != null)
                    return storage.Debug.Deserialize<T>(response.ResponseUri.AbsolutePath, result, settings);

                return JsonConvert.DeserializeObject<T>(result, settings);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return default(T);
            }
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public async Task<HttpWebResponse> GetResponseAsync()
        {
            try {
                return (HttpWebResponse) await fullRequest.GetResponseAsync();
            }
            catch (Exception ex) {
                using (StreamReader sr = new StreamReader(((WebException)ex).Response.GetResponseStream())) {
                    string result = await sr.ReadToEndAsync();
                    Console.WriteLine(result);
                }

                throw;
            }
        }

        public async Task<T> GetResponseAsync<T>()
        {
            if (fullRequest == null)
                return default(T);

            using (var response = await GetResponseAsync()) {
                return await GetDataFromResponseAsync<T>(response);
            }
        }

        #endregion Основные функции
    }
}