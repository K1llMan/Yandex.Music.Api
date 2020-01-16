using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YDeleteTrackFromPlaylistRequest : YRequest
    {
        public YDeleteTrackFromPlaylistRequest(HttpContext context) : base(context)
        {
        }
        
        public HttpWebRequest Create(string ownerId, int from, int to, int revision, string kind, string lang, string sign, string userUid, string userLogin, string experements)
        {
            var diff = "[{\"op\":\"delete\",\"from\":" + from + ",\"to\":" + to + "}]";
            var url = "https://music.yandex.ru/handlers/playlist-patch.jsx";
            
            var request = GetRequest(url, 
                new KeyValuePair<string, string>("owner", ownerId),
                new KeyValuePair<string, string>("kind", kind),
                new KeyValuePair<string, string>("revision", revision.ToString()), // ?
                new KeyValuePair<string, string>("diff", diff),
                new KeyValuePair<string, string>("lang", lang),
                new KeyValuePair<string, string>("sign", sign),
                new KeyValuePair<string, string>("experiments", experements),
                new KeyValuePair<string, string>("external-domain", "music.yandex.ru"),
                new KeyValuePair<string, string>("overembed", "false"));
            
            request.Headers[HttpRequestHeader.Accept] = "application/json, text/javascript, */*; q=0.01";
            request.Headers["Accept-Encoding"] = "gzip, deflate, br";
            request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
            request.Headers["access-control-allow-methods"] = "[POST]";
            request.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
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