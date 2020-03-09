using System.Collections.Generic;
using System.Net;

using Newtonsoft.Json;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YInsertTrackToPlaylistRequest : YRequest
    {
        public YInsertTrackToPlaylistRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(int at, string trackId, string trackAlbumId, string kind)
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
                {"owner", storage.User.Uid},
                {"kind", kind},
                {"revision", "7"}, // ?
                {"diff", diff},
                {"from", "web-own_tracks-track-track-main"},
                {"lang", storage.User.Lang},
                {"sign", storage.User.Sign},
                {"experiments", storage.User.Experiments},
                {"external-domain", "music.yandex.ru"},
                {"overembed", "false"}
            };

            var headers = new List<KeyValuePair<string, string>> {
                YRequestHeaders.Get(YHeader.Accept, storage),
                YRequestHeaders.Get(YHeader.AcceptCharset, storage),
                YRequestHeaders.Get(YHeader.AcceptEncoding, "utf-8"),
                YRequestHeaders.Get(YHeader.AcceptLanguage, storage),
                YRequestHeaders.Get(YHeader.AccessControlAllowMethods, storage),
                YRequestHeaders.Get(YHeader.ContentType, "application/x-www-form-urlencoded; charset=UTF-8"),
                YRequestHeaders.Get(YHeader.Origin, storage),
                YRequestHeaders.Get(YHeader.Referer, storage),
                YRequestHeaders.Get(YHeader.SecFetchMode, storage),
                YRequestHeaders.Get(YHeader.SecFetchSite, storage),
                YRequestHeaders.Get(YHeader.XCurrentUID, storage),
                YRequestHeaders.Get(YHeader.XRequestedWith, storage),
                YRequestHeaders.Get(YHeader.XRetpathY, storage)
            };

            FormRequest(YEndpoints.PlaylistPatch, body: GetQueryString(query), headers: headers, method: WebRequestMethods.Http.Post);

            return this;
        }
    }
}