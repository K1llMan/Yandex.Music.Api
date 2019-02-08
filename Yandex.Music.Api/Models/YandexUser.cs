using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Extensions;

namespace Yandex.Music.Api.Models
{
  public class YandexUser : IYandexSearchable
  {
    public string Uid { get; set; }
    public string Login { get; set; }
    public string Name { get; set; }
    public List<string> Regions { get; set; }

    public static YandexUser FromJson(JToken jUser)
    {
      var user = new YandexUser
      {
        Uid = jUser.GetString("uid"),
        Login = jUser.GetString("login"),
        Name = jUser.GetString("name"),
        Regions = jUser.ContainField("regions") ? 
          jUser["regions"].ToObject<JArray>().Select(x => x.ToString()).ToList()
          : null
      };
      
      return user;
    }

    public static List<YandexUser> FromJsonArray(JToken jUsers)
    {
      return jUsers.Select(FromJson).ToList();
    }
  }
}