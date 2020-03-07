using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YInsertTrackToPlaylistRequest : YRequest
    {
        public YInsertTrackToPlaylistRequest(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(string ownerId, int at, string trackId, string trackAlbumId, string kind,
            string lang,
            string sign, string userUid, string userLogin, string experements)
        {
            var diff = JsonConvert.SerializeObject(new[] {
                new Dictionary<string, object> {
                    {"op", "insert"},
                    {"at", at}, {
                        "tracks", new[] {
                            new Dictionary<string, object> {
                                {"id", trackId},
                                {"albumId", trackAlbumId}
                            }
                        }
                    }
                }
            });

            var query = new Dictionary<string, string> {
                {"owner", ownerId},
                {"kind", kind},
                {"revision", "7"}, // ?
                {"diff", diff},
                {"from", "web-own_tracks-track-track-main"},
                {"lang", lang},
                {"sign", sign},
                {"experiments", experements},
                {"external-domain", "music.yandex.ru"},
                {"overembed", "false"}
            };

            var request = GetRequest(YEndpoints.PlaylistPatch, body: GetQueryString(query));

            request.Headers[HttpRequestHeader.Accept] = "application/json; q=1.0, text/*; q=0.8, */*; q=0.1";
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