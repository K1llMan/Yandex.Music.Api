using System;
using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Extensions
{
  public static class JsonExtensions
  {
    public static string GetString(this JToken json, string name)
    {
      if (!json.ContainField(name))
      {
        Console.WriteLine($"Not found filed {name} into: \n{json}");
        
        return null;
      }

      return json[name].ToObject<string>();
    }
    
    public static int? GetInt(this JToken json, string name)
    {
      if (!json.ContainField(name))
      {
        Console.WriteLine($"Not found filed {name} into: \n{json}");
        
        return null;
      }

      if (json[name].ToString() == string.Empty)
      {
        return null;
      }

      return json[name].ToObject<int>();
    }
    
    public static bool? GetBool(this JToken json, string name)
    {
      if (!json.ContainField(name))
      {
        Console.WriteLine($"Not found filed {name} into: \n{json}");
        
        return null;
      }

      return json[name].ToObject<bool?>();
    }

    public static bool ContainField(this JToken json, string fieldName)
    {
      var isContains = false;
      foreach (JProperty property in json)
      {
        if (property.Name == fieldName)
        {
          isContains = true;
          break;
        }
      }

      return isContains;
    }
  }
}