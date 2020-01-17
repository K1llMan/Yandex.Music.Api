using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Extensions;

namespace Yandex.Music.Api.Responses
{
    public class YArtistResponse
    {
    public string Id { get;set; }
    public string Name { get; set; }
    public bool? Various { get; set; }
    public bool? Composer { get; set; }
    public YCover Cover { get; set; }
    public string[] Genres { get; set; }

    public static YArtistResponse FromJson(JToken jArtist)
    {
      var artist = new YArtistResponse
      {
        Id = jArtist.GetString("id"),
        Name = jArtist.GetString("name"),
        Various = jArtist.GetBool("various"),
        Composer = jArtist.GetBool("composer"),
        Cover = jArtist.ContainField("cover") ? YCover.FromJson(jArtist["cover"]) : null,
        Genres = new string[] { }
      };

      return artist;
    }

    public static List<YArtistResponse> FromJsonArray(JArray jArtists)
    {
      return jArtists.Select(FromJson).ToList();
    }
    }
}