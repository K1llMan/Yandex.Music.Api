using System.Net;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YGetPlaylistOfDayRequest : YRequest
    {
        public YGetPlaylistOfDayRequest(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(string lang)
        {
            var request = GetRequest($"https://music.yandex.ru/handlers/playlist.jsx?owner=yamusic-daily&kinds=57151881&light=true&madeFor=&lang={lang}&external-domain=music.yandex.ru&overembed=false&ncrnd=0.9083773647705418");
            
            return request;
        }
    }
}