using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Newtonsoft.Json;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Requests.Common
{
    internal class YRequest<T>
    {
        #region Поля

        private HttpRequestMessage msg;
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
            string queryStr = string.Empty;
            if (query is { Count: > 0 })
                queryStr = "?" + GetQueryString(query);

            Uri uri = new($"{url}{queryStr}");
            HttpWebRequest request = WebRequest.CreateHttp(uri);

            if (storage.Context.WebProxy != null)
                request.Proxy = storage.Context.WebProxy;

            request.Method = method;
            storage.Context.Cookies ??= new CookieContainer();

            storage.SetHeaders(request);

            if (headers is { Count: > 0 })
                foreach (KeyValuePair<string, string> header in headers)
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
        }

        protected async Task<T> GetDataFromResponseAsync(HttpResponseMessage response)
        {
            try {
                string result = await response.Content.ReadAsStringAsync();

                JsonSerializerSettings settings = new()
                {
                    Converters = new List<JsonConverter> {
                        new YExecutionContextConverter(api, storage)
                    }
                };

                return storage.Debug != null 
                    ? storage.Debug.Deserialize<T>(response.RequestMessage?.RequestUri?.AbsolutePath, result, settings) 
                    : JsonConvert.DeserializeObject<T>(result, settings);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return default;
            }
        }

        private Task<HttpResponseMessage> GetWebResponseAsync()
        {
            try
            {
                HttpClient client = new(new SocketsHttpHandler {
                    Proxy = storage.Context.WebProxy,
                    AutomaticDecompression = DecompressionMethods.GZip,
                    UseCookies = true,
                    CookieContainer = storage.Context.Cookies,
                });

                return client.SendAsync(msg);
            }
            catch (Exception ex)
            {
                using StreamReader sr = new(((WebException)ex).Response.GetResponseStream());
                string result = sr.ReadToEnd();
                Console.WriteLine(result);

                throw;
            }
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public YRequest(HttpRequestMessage message, YandexMusicApi yandex, AuthStorage auth)
        {
            msg = message;
            api = yandex;
            storage = auth;
        }

        public async Task<T> GetResponseAsync()
        {
            if (msg == null)
                return default;

            using HttpResponseMessage response = await GetWebResponseAsync();

            return typeof(T) == typeof(HttpResponseMessage)
                ? (T)(object)response
                : await GetDataFromResponseAsync(response);
        }

        #endregion Основные функции
    }
}