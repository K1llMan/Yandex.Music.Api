using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;

namespace Yandex.Music.SourceGenerators.Models
{
    public class MethodTemplateModel : BaseTemplateModel<IMethodSymbol>
    {
        public string Accessibility { get; set; }
        public List<MethodParameterTemplateModel> Parameters { get; set; }
        public TypeTemplateModel ReturnType { get; set; }

        // Scriban не поддерживает вызов методов объектов
        public string ParametersDeclaration => string.Join(", ", Parameters);
        public string ParametersNames => string.Join(", ", Parameters.Select(p => p.Name));
    }
}