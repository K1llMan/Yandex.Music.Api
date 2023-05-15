using Microsoft.CodeAnalysis;

namespace Yandex.Music.SourceGenerators.Models
{
    public class MethodParameterTemplateModel : BaseTemplateModel<IParameterSymbol>
    {
        public TypeTemplateModel Type { get; set; }
    }
}