using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YAddLikedTrackRequest : YRequest
    {
        public YAddLikedTrackRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(bool status, string trackKey)
        {
            string time = storage.Context.GetTimeInterval().ToString();

            var trackPair = trackKey.Split(':');
            var trackId = trackPair.FirstOrDefault();
            var albumId = trackPair.LastOrDefault();

            var take = "add";
            if (!status) take = "remove";

            var query = new Dictionary<string, string> {
                {"from", "web-own_tracks-track-track-main" },
                {"sign", storage.User.Sign },
                {"external-domain", "music.yandex.ru"},
                {"overembed", "no"}
            };

            var url =
                $"https://music.yandex.ru/api/v2.1/handlers/track/{trackKey}/web-own_tracks-track-track-main/like/?__t={time}";
            var request = FormRequest(url, body: GetQueryString(query));

            request.Headers[HttpRequestHeader.Accept] = "application/json; q=1.0, text/*; q=0.8, */*; q=0.1";
//      request.Headers["Accept-Encoding"] = "gzip, deflate, br";
            request.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            request.Headers["Accept-Encoding"] = "utf-8";
            request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
            request.Headers["access-control-allow-methods"] = "[POST]";
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