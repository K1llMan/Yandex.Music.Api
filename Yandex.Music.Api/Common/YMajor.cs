using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Extensions;

namespace Yandex.Music.Api.Common
{
  public class YMajor
  {
    public string Id { get; set; }
    public string Name { get; set; }

    public static YMajor FromJson(JToken json)
    {
      if (json == null)
      {
        return null;
      }

      return new YMajor
      {
        Id = json["id"].ToObject<string>(),
        Name = json["name"].ToObject<string>()
      };
    }
  }
}