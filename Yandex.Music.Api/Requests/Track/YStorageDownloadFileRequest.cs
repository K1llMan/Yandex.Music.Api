using System.Collections.Generic;
using System.Linq;
using System.Net;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YStorageDownloadFileRequest : YRequest
    {
        public YStorageDownloadFileRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(string src)
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "format", "json" },
                { "external-domain", "music.yandex.ru" },
                { "overembed", "no" },
                { "__t", storage.Context.GetTimeInterval().ToString()}
            };

            string[] parts = src.Split('?');
            parts[1].Split('&').ToList().ForEach(p => {
                string[] param = p.Split('=');
                query.Add(param[0], param[1]);
            });

            var request = FormRequest(parts[0], query: query);

            request.Headers[HttpRequestHeader.Accept] = "application/json; q=1.0, text/*; q=0.8, */*; q=0.1";
            //request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate, br";
            //request.Headers[HttpRequestHeader.AcceptLanguage] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";

            //      request.Headers["access-control-allow-methods"] = "[POST]";
            //      request.Headers["X-Current-UID"] = userUid;

            request.Headers["origin"] = "https://music.yandex.ru";
            request.Headers["referer"] = $"https://music.yandex.ru/users/{storage.User.Login}/tracks";
            request.Headers["sec-fetch-dest"] = "empty";
            request.Headers["sec-fetch-mode"] = "cors";
            request.Headers["sec-fetch-site"] = "cross-site";

            return this;
        }
    }
}