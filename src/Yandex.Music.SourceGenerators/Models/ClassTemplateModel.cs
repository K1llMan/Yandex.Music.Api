using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace Yandex.Music.SourceGenerators.Models
{
    public class ClassTemplateModel : BaseTemplateModel<INamedTypeSymbol>
    {
        public string Modifiers { get; set; }
        public string Namespace { get; set; }
        public List<string> Usings { get; set; }
        public List<MethodTemplateModel> Methods { get; set; }
    }
}