using System.Net;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YGetPlaylistDejaVuRequest : YRequest
    {
        public YGetPlaylistDejaVuRequest(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(string lang)
        {
            var request = GetRequest($"https://music.yandex.ru/handlers/playlist.jsx?owner=yamusic-dejavu&kinds=57704235&light=true&madeFor=&lang={lang}&external-domain=music.yandex.ru&overembed=false&ncrnd=0.13048851242872916");

            return request;
        }
    }
}