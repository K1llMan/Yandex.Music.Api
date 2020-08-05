using System.Collections.Generic;
using System.Net;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Playlist;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YPlaylistChangeRequest : YRequest
    {
        #region Поля

        private JsonSerializerSettings settings = new JsonSerializerSettings {
            Converters = new List<JsonConverter> {
                new StringEnumConverter {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            },
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        #endregion Поля

        public YPlaylistChangeRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest Create(YPlaylist playlist, List<YPlaylistChange> changes)
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "kind", playlist.Kind },
                { "revision", playlist.Revision.ToString() },
                { "diff", JsonConvert.SerializeObject(changes, settings) }
            };

            var headers = new List<KeyValuePair<string, string>> {
                YRequestHeaders.Get(YHeader.ContentType, "application/x-www-form-urlencoded")
            };

            FormRequest($"{YEndpoints.API}/users/{storage.User.Uid}/playlists/{playlist.Kind}/change", 
                body: GetQueryString(query), headers: headers, method: WebRequestMethods.Http.Post);

            return this;
        }
    }
}