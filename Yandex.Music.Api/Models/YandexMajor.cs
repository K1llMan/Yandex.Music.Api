using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Extensions;

namespace Yandex.Music.Api.Models
{
  public class YandexMajor
  {
    public string Id { get; set; }
    public string Name { get; set; }

    public static YandexMajor FromJson(JToken jMajor)
    {
      if (!jMajor.Contains("major"))
      {
        return null;
      }

      var majot = new YandexMajor
      {
        Id = jMajor.GetString("id"),
        Name = jMajor.GetString("name")
      };
      
      return majot;
    }
  }
}