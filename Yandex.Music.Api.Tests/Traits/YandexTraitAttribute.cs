using System;
using Xunit.Sdk;

namespace Yandex.Music.Api.Tests.Traits
{
  [TraitDiscoverer("Yandex.Music.Api.Tests.Traits.YandexTraitDiscoverer", "Yandex.Music.Api.Tests")]
  [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
  public class YandexTraitAttribute : Attribute, ITraitAttribute
  {
    public YandexTraitAttribute(params TraitGroup[] group)
    {
    }
  }
}
