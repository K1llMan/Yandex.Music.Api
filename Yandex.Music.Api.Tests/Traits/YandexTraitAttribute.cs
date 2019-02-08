using System;
using Xunit.Sdk;

namespace Lofty.Modules.BddTests.Traits
{
  [TraitDiscoverer("Lofty.Modules.BddTests.Traits.YandexTraitDiscoverer", "Lofty.Modules.BddTests")]
  [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
  public class YandexTraitAttribute : Attribute, ITraitAttribute
  {
    public YandexTraitAttribute(params TraitGroup[] group)
    {
    }
  }
}
