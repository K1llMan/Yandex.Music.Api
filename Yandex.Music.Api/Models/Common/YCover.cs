using System.Linq;

using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Models.Common
{
    public class YCover
    {
        #region Поля

        internal static YCover FromJson(JToken json)
        {
            if (json == null) return null;

            var type = json.SelectToken("type")?.ToObject<string>();

            if (json.SelectToken("error") != null)
                return new YCoverError {
                    Error = json.SelectToken("error")?.ToObject<string>()
                };
            if (type == "mosaic")
                return new YCoverMosaic {
                    Type = json.SelectToken("type")?.ToObject<string>(),
                    ItemsUri = json.SelectToken("itemsUri")?.Select(f => f.ToObject<string>()).ToList(),
                    Custom = json.SelectToken("custom").ToObject<bool>()
                };
            if (type == "pic")
                return new YCoverPic {
                    Type = json.SelectToken("type")?.ToObject<string>(),
                    Dir = json.SelectToken("dir")?.ToObject<string>(),
                    Version = json.SelectToken("version")?.ToObject<string>(),
                    Uri = json.SelectToken("uri")?.ToObject<string>(),
                    Custom = json.SelectToken("custom")?.ToObject<bool>()
                };
            if (type == "from-album-cover")
                return new YCoverFromAlbum {
                    Type = json.SelectToken("type")?.ToObject<string>(),
                    Prefix = json.SelectToken("prefix")?.ToObject<string>(),
                    Url = json.SelectToken("uri")?.ToObject<string>()
                };

            return null;
        }

        #endregion

        #region Свойства

        public bool? Custom { get; set; }

        public string Type { get; set; }

        #endregion

        protected YCover()
        {
        }
    }
}