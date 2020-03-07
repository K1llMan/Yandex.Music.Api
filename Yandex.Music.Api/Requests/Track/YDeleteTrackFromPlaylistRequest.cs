using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YDeleteTrackFromPlaylistRequest : YRequest
    {
        public YDeleteTrackFromPlaylistRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(int from, int to, int revision, string kind)
        {
            string diff = JsonConvert.SerializeObject(new[] {
                new Dictionary<string, object> {
                    {"op", "delete"},
                    {"from", from},
                    {"to", to}
                }
            });

            Dictionary<string, string> query = new Dictionary<string, string> {
                {"owner", storage.User.Uid },
                {"kind", kind },
                {"revision", revision.ToString() }, // ?
                {"diff", diff },
                {"lang", storage.User.Lang },
                {"sign", storage.User.Sign },
                {"experiments", storage.User.Experiments },
                {"external-domain", "music.yandex.ru" },
                {"overembed", "no" }
            };

            var request = FormRequest(YEndpoints.PlaylistPatch, body: GetQueryString(query));

            request.Headers[HttpRequestHeader.Accept] = "application/json, text/javascript, */*; q=0.01";
            request.Headers["Accept-Encoding"] = "gzip, deflate, br";
            request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
            request.Headers["access-control-allow-methods"] = "[POST]";
            request.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Headers["Sec-Fetch-Mode"] = "cors";
            request.Headers["X-Current-UID"] = storage.User.Uid;
            request.Headers["X-Requested-With"] = "XMLHttpRequest";
            request.Headers["X-Retpath-Y"] = $"https%3A%2F%2Fmusic.yandex.ru%2Fusers%2F{storage.User.Login}%2Ftracks";
            request.Headers[HttpRequestHeader.AcceptCharset] = Encoding.UTF8.HeaderName;

            request.Headers["origin"] = "https://music.yandex.ru";
            request.Headers["referer"] = $"https://music.yandex.ru/users/{storage.User.Login}/tracks";
            request.Headers["sec-fetch-mode"] = "cors";
            request.Headers["sec-fetch-site"] = "same-site";

            return this;
        }
    }
}