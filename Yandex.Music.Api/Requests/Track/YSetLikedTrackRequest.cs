using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YSetLikedTrackRequest : YRequest
    {
        public YSetLikedTrackRequest(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(bool status, string trackKey, long time, string sign, string userUid,
            string userLogin)
        {
            var trackPair = trackKey.Split(':');
            var trackId = trackPair.FirstOrDefault();
            var albumId = trackPair.LastOrDefault();

            var take = "liked";
            if (!status)
            {
                take = "unlike";
            }

            var url =
                $"https://music.yandex.ru/api/v2.1/handlers/radio/radio/history/feedback/{take}/{trackKey}?__t={time}";
            var request = GetRequest(url, 
                new KeyValuePair<string, string>("timestamp", time.ToString()),
                new KeyValuePair<string, string>("from", "web-radio-user-saved"),
                new KeyValuePair<string, string>("batchId", "undefined"),
                new KeyValuePair<string, string>("trackId", trackId),
                new KeyValuePair<string, string>("albumId", albumId),
                new KeyValuePair<string, string>("totalPlayed", "0.1"),
                new KeyValuePair<string, string>("sign", sign),
                new KeyValuePair<string, string>("external-domain", "music.yandex.ru"),
                new KeyValuePair<string, string>("overembed", "no"));
            
            request.Headers[HttpRequestHeader.Accept] = "application/json; q=1.0, text/*; q=0.8, */*; q=0.1";
//      request.Headers["Accept-Encoding"] = "gzip, deflate, br";
            request.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            request.Headers["Accept-Encoding"] = "utf-8";
            request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
            request.Headers["access-control-allow-methods"] = "[POST]";
            request.Headers["overembed"] = time.ToString();
            request.Headers["Sec-Fetch-Mode"] = "cors";
            request.Headers["X-Current-UID"] = userUid;
            request.Headers["X-Requested-With"] = "XMLHttpRequest";
            request.Headers["X-Retpath-Y"] = $"https%3A%2F%2Fmusic.yandex.ru%2Fusers%2F{userLogin}%2Ftracks";
            request.Headers[HttpRequestHeader.AcceptCharset] = Encoding.UTF8.HeaderName;

            request.Headers["origin"] = "https://music.yandex.ru";
            request.Headers["referer"] = $"https://music.yandex.ru/users/{userLogin}/tracks";
            request.Headers["sec-fetch-mode"] = "cors";
            request.Headers["sec-fetch-site"] = "same-site";

            return request;
        }
    }
}