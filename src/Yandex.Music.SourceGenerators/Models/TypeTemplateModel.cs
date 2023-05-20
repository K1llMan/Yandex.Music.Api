using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;

namespace Yandex.Music.SourceGenerators.Models
{
    public class TypeTemplateModel :  BaseTemplateModel<ITypeSymbol>
    {
        public List<TypeTemplateModel> Arguments { get; set; }
        public bool IsArray { get; set; }

        public override string ToString()
        {
            if (Arguments != null && Arguments.Count > 0)
                return $"{Name}<{string.Join(",", Arguments.Select(a => a.ToString()))}>";

            return IsArray ?
                $"{Name}[]" 
                : Name;
        }
    }
}