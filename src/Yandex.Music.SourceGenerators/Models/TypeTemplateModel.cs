using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;

namespace Yandex.Music.SourceGenerators.Models
{
    public class TypeTemplateModel :  BaseTemplateModel<ITypeSymbol>
    {
        public List<TypeTemplateModel> Arguments { get; set; }

        public override string ToString()
        {
            return Arguments.Count == 0
                ? Name
                : $"{Name}<{string.Join(",", Arguments.Select(a => a.ToString()))}>";
        }
    }
}