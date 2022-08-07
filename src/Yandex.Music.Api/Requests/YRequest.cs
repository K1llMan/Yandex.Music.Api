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
    internal class YRequest<T>
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

            fullRequest = request;
        }

        protected async Task<T> GetDataFromResponseAsync(HttpWebResponse response)
        {
            try {
                string result;
                await using (Stream stream = response.GetResponseStream()) {
                    StreamReader reader = new(stream);
                    result = await reader.ReadToEndAsync();
                }

                storage.Context.Cookies.Add(response.Cookies);

                JsonSerializerSettings settings = new()
                {
                    Converters = new List<JsonConverter> {
                        new YExecutionContextConverter(api, storage)
                    }
                };

                return storage.Debug != null 
                    ? storage.Debug.Deserialize<T>(response.ResponseUri.AbsolutePath, result, settings) 
                    : JsonConvert.DeserializeObject<T>(result, settings);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return default;
            }
        }

        private async Task<HttpWebResponse> GetWebResponseAsync()
        {
            try
            {
                return (HttpWebResponse)await fullRequest.GetResponseAsync();
            }
            catch (Exception ex)
            {
                using StreamReader sr = new(((WebException)ex).Response.GetResponseStream());
                string result = await sr.ReadToEndAsync();
                Console.WriteLine(result);

                throw;
            }
        }

        #endregion Вспомогательные функции

        #region Основные функции


        public async Task<T> GetResponseAsync()
        {
            if (fullRequest == null)
                return default;

            using HttpWebResponse response = await GetWebResponseAsync();

            return typeof(T) == typeof(HttpWebResponse)
                ? (T)(object)response
                : await GetDataFromResponseAsync(response);
        }

        #endregion Основные функции
    }
}