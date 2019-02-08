using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Extensions;

namespace Yandex.Music
{
  public class YandexArtist : IYandexSearchable
  {
    public string Id { get;set; }
    public string Name { get; set; }
    public bool? Various { get; set; }
    public bool? Composer { get; set; }
    public YandexCover Cover { get; set; }
    public string[] Genres { get; set; }

    public static YandexArtist FromJson(JToken jArtist)
    {
      var artist = new YandexArtist
      {
        Id = jArtist.GetString("id"),
        Name = jArtist.GetString("name"),
        Various = jArtist.GetBool("various"),
        Composer = jArtist.GetBool("composer"),
        Cover = jArtist.ContainField("cover") ? YandexCover.FromJson(jArtist["cover"]) : null,
        Genres = new string[] { }
      };

      return artist;
    }

    public static List<YandexArtist> FromJsonArray(JArray jArtists)
    {
      return jArtists.Select(FromJson).ToList();
    }
  }

}