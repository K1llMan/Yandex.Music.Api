using System.Net;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YGetPlaylistFavoritesRequest : YRequest
    {
        public YGetPlaylistFavoritesRequest(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(string login, string lang)
        {
            var request = GetRequest(
                $"https://music.yandex.ru/handlers/library.jsx?owner={login}&filter=tracks&likeFilter=favorite&sort=&dir=&lang={lang}&external-domain=music.yandex.ru&overembed=false&ncrnd=0.7506943983987266");

            return request;
        }
    }
}