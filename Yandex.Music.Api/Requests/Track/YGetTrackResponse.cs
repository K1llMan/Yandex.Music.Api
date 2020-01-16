using System.Net;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YGetTrackResponse : YRequest
    {
        public YGetTrackResponse(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(string trackId, string lang)
        {
            var request = GetRequest($"https://music.yandex.ru/handlers/track.jsx?track={trackId}&lang={lang}&external-domain=music.yandex.ru&overembed=false", WebRequestMethods.Http.Get);

            return request;
        }
    }
}