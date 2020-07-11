using System;
using System.Collections.Generic;

using Xunit.Abstractions;
using Xunit.Sdk;

namespace Yandex.Music.Api.Tests.Traits
{
    public class YandexTraitDiscoverer : ITraitDiscoverer
    {
        public const string Category = "Yandex";

        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var args = (List<object>) traitAttribute.GetConstructorArguments();
            var groups = (Array) args[0];

            foreach (var nameGroup in groups) yield return new KeyValuePair<string, string>(Category, nameGroup.ToString());
        }
    }
}