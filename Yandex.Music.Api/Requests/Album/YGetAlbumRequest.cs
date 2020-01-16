using System.Net;

namespace Yandex.Music.Api.Requests.Album
{
    internal class YGetAlbumRequest : YRequest
    {
        public YGetAlbumRequest(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(string albumId, string lang)
        {
            var request =
                GetRequest(
                    $"https://music.yandex.ru/handlers/album.jsx?album={albumId}&lang={lang}&external-domain=music.yandex.ru&overembed=false",
                    WebRequestMethods.Http.Get);
            
            return request;
        }
    }
}