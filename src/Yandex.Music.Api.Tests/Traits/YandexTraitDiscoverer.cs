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
            List<object> args = (List<object>)traitAttribute.GetConstructorArguments();
            Array groups = (Array)args[0];

            foreach (object nameGroup in groups)
                yield return new KeyValuePair<string, string>(Category, nameGroup.ToString());
        }
    }
}
