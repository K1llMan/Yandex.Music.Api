using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.Common
{
    public class YCover
    {
                public string Type { get; set; }
                public bool? Custom { get; set; }

        protected YCover()
        {
            
        }

        internal static YCover FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            var type = json.SelectToken("type")?.ToObject<string>();

            if (json.SelectToken("error") != null)
            {
                return new YCoverError
                {
                    Error = json.SelectToken("error")?.ToObject<string>()
                };
            }
            else if (type == "mosaic")
            {
                return new YCoverMosaic
                {
                    Type = json.SelectToken("type")?.ToObject<string>(),
                    ItemsUri = json.SelectToken("itemsUri")?.Select(f => f.ToObject<string>()).ToList(),
                    Custom = json.SelectToken("custom").ToObject<bool>()
                };
            }
            else if (type == "pic")
            {
                return new YCoverPic
                {
                    Type = json.SelectToken("type")?.ToObject<string>(),
                    Dir = json.SelectToken("dir")?.ToObject<string>(),
                    Version = json.SelectToken("version")?.ToObject<string>(),
                    Uri = json.SelectToken("uri")?.ToObject<string>(),
                    Custom = json.SelectToken("custom")?.ToObject<bool>()
                };
            }
            else if (type == "from-album-cover")
            {
                return new YCoverFromAlbum
                {
                    Type = json.SelectToken("type")?.ToObject<string>(),
                    Prefix = json.SelectToken("prefix")?.ToObject<string>(),
                    Url = json.SelectToken("uri")?.ToObject<string>()
                };
            }

            return null;
        }
    }
}
