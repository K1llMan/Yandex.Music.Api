using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Extensions;

namespace Yandex.Music.Api.Models.Playlist
{
  public class YPlaylistCover
  {
    public string Type { get; set; }
    public string Prefix { get; set; }
    public string Url { get; set; }
    public bool? Custom { get; set; }
    public string Dir { get; set; }
    public string Version { get; set; }

    public static YPlaylistCover FromJson(JToken jCover)
    {
      var cover = new YPlaylistCover
      {
        Type = jCover.GetString("type"),
        Prefix = jCover.GetString("prefix"),
        Url = jCover.GetString("uri"),
        Custom = jCover.GetBool("custom"),
        Dir = jCover.GetString("dir"),
        Version = jCover.GetString("version")
      };
      return cover;
    }
  }
}
