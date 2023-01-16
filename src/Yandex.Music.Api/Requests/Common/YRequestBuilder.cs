using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Web;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Extensions;

namespace Yandex.Music.Api.Requests.Common
{
    public class YRequestBuilder<ResponseType, ParamsTuple>
    {
        #region Поля

        private readonly JsonSerializerSettings jsonSettings = new() {
            Converters = new List<JsonConverter> {
                new StringEnumConverter {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            },
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        private YRequestAttribute requestInfo;
        private Dictionary<string, string> subs;

        protected YandexMusicApi api;
        protected AuthStorage storage;
        protected string Device = "os=CSharp; os_version=; manufacturer=Marshal; model=Yandex Music API; clid=; device_id=random; uuid=random";

        #endregion Поля

        #region Свойства

        protected YandexMusicApi API => api;
        protected AuthStorage Storage => storage;

        #endregion Свойства

        #region Вспомогательные функции

        private Uri BuildUri(ParamsTuple tuple)
        {
            NameValueCollection queryParams = GetQueryParams(tuple);
            NameValueCollection modifiedParams = HttpUtility.ParseQueryString(string.Empty);

            // Подстановка в параметры
            foreach (string key in queryParams.Keys)
            {
                modifiedParams.Set(key, ReplaceSubs(queryParams.Get(key)));
            }

            string endpoint = ReplaceSubs(requestInfo.Url);

            UriBuilder builder = new(endpoint) {
                Query = modifiedParams.ToString() ?? string.Empty
            };


            return builder.Uri;
        }

        private HttpRequestMessage CreateMessage(ParamsTuple tuple)
        {
            HttpRequestMessage msg = new() {
                RequestUri = BuildUri(tuple),
                Method = new HttpMethod(requestInfo.Method),
                Content = GetContent(tuple)
            };

            msg.Headers.TryAddWithoutValidation(HttpRequestHeader.AcceptCharset.GetName(), Encoding.UTF8.WebName);
            msg.Headers.TryAddWithoutValidation(HttpRequestHeader.AcceptEncoding.GetName(), "gzip");

            // Добавление заголовка авторизации
            if (!string.IsNullOrEmpty(storage.Token))
                msg.Headers.TryAddWithoutValidation(HttpRequestHeader.Authorization.GetName(), $"OAuth {storage.Token}");

            SetCustomHeaders(msg.Headers);

            return msg;
        }

        protected string ReplaceSubs(string str)
        {
            string[] sub = str.GetMatches(@"\{.+?\}");

            foreach (string s in sub)
            {
                if (!subs.TryGetValue(s.ReplaceRegex(@"[\{\}]", string.Empty), out string value))
                    throw new Exception($"Не найдена подстановка {s}");

                str = str.Replace(s, value);
            }

            return str;
        }
        protected virtual Dictionary<string, string> GetSubstitutions(ParamsTuple tuple)
        {
            return new Dictionary<string, string>();
        }

        protected virtual NameValueCollection GetQueryParams(ParamsTuple tuple)
        {
            return new NameValueCollection();
        }

        protected virtual HttpContent GetContent(ParamsTuple tuple)
        {
            return null;
        }

        protected virtual void SetCustomHeaders(HttpRequestHeaders headers)
        {
        }

        protected string SerializeJson(object data)
        {
            return JsonConvert.SerializeObject(data, jsonSettings);
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public YRequestBuilder(YandexMusicApi yandex, AuthStorage auth)
        {
            requestInfo = GetType()
                .GetCustomAttributes<YRequestAttribute>()
                .FirstOrDefault();

            if (requestInfo == null)
                throw new NotImplementedException($"Отсутствует атрибут {nameof(YRequestAttribute)}");

            api = yandex;
            storage = auth;
        }

        internal YRequest<ResponseType> Build(ParamsTuple tuple)
        {
            subs = GetSubstitutions(tuple);
            HttpRequestMessage msg = CreateMessage(tuple);

            return new YRequest<ResponseType>(msg, api, storage);
        }

        #endregion Основные функции
    }
}
