using System.Net;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YTrackDownloadInfoRequest : YRequest
    {
        public YTrackDownloadInfoRequest(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(string trackKey, long time, string userUid, string userLogin)
        {
            var url =
                $"https://music.yandex.ru/api/v2.1/handlers/track/{trackKey}/web-own_tracks-track-track-main/download/m?hq=0&external-domain=music.yandex.ru&overembed=no&__t={time}";

            var request = GetRequest(url, WebRequestMethods.Http.Get);
            request.Headers[HttpRequestHeader.Accept] = "application/json; q=1.0, text/*; q=0.8, */*; q=0.1";
            request.Headers["Accept-Encoding"] = "gzip, deflate, br";
            request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
//      request.Headers["access-control-allow-methods"] = "[POST]";
            request.Headers["Sec-Fetch-Mode"] = "cors";
            request.Headers["X-Current-UID"] = userUid;
            request.Headers["X-Requested-With"] = "XMLHttpRequest";
            request.Headers["X-Retpath-Y"] = $"https%3A%2F%2Fmusic.yandex.ru%2Fusers%2F{userLogin}%2Ftracks";

            request.Headers["origin"] = "https://music.yandex.ru";
            request.Headers["referer"] = $"https://music.yandex.ru/users/{userLogin}/tracks";
            request.Headers["sec-fetch-mode"] = "cors";
            request.Headers["sec-fetch-site"] = "same-site";

            return request;
        }
    }
}