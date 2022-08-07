using System.Collections.Generic;
using System.Net;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Playlist;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YPlaylistChangeRequest : YRequest<YResponse<YPlaylist>>
    {
        #region Поля

        private JsonSerializerSettings settings = new()
        {
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

        public YRequest<YResponse<YPlaylist>> Create(YPlaylist playlist, List<YPlaylistChange> changes)
        {
            Dictionary<string, string> query = new()
            {
                { "kind", playlist.Kind },
                { "revision", playlist.Revision.ToString() },
                { "diff", JsonConvert.SerializeObject(changes, settings) }
            };

            List<KeyValuePair<string, string>> headers = new()
            {
                YRequestHeaders.Get(YHeader.ContentType, "application/x-www-form-urlencoded")
            };

            FormRequest($"{YEndpoints.API}/users/{storage.User.Uid}/playlists/{playlist.Kind}/change", 
                body: GetQueryString(query), headers: headers, method: WebRequestMethods.Http.Post);

            return this;
        }
    }
}