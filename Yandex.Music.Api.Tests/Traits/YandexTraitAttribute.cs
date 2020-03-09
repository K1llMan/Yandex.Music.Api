using System;

using Xunit.Sdk;

namespace Yandex.Music.Api.Tests.Traits
{
    [TraitDiscoverer("Yandex.Music.API.Tests.Traits.YandexTraitDiscoverer", "Yandex.Music.API.Tests")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class YandexTraitAttribute : Attribute, ITraitAttribute
    {
        public YandexTraitAttribute(params TraitGroup[] group)
        {
        }
    }
}