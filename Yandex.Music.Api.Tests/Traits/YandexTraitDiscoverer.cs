using System;
using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Lofty.Modules.BddTests.Traits
{
  public class YandexTraitDiscoverer : ITraitDiscoverer
  {
    public const string Category = "Lofi.Yandex";

    public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
    {
      var args = (List<Object>) traitAttribute.GetConstructorArguments();
      var groups = (Array) args[0];

      foreach (var nameGroup in groups)
      {
        yield return new KeyValuePair<string, string>(Category, nameGroup.ToString());
      }
    }
  }
}
