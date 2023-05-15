using System.Collections.Generic;

using Microsoft.CodeAnalysis;

namespace Yandex.Music.SourceGenerators.Models
{
    public class MethodTemplateModel : BaseTemplateModel<IMethodSymbol>
    {
        public string Accessibility { get; set; }
        public List<MethodParameterTemplateModel> Parameters { get; set; }
        public TypeTemplateModel ReturnType { get; set; }
    }
}