using Microsoft.CodeAnalysis;

namespace Yandex.Music.SourceGenerators.Models
{
    public class BaseTemplateModel<T> where T : ISymbol
    {
        public T Symbol { get; set; }
        public string Name { get; set; }
        public string[] DocumentationComment { get; set; }
    }
}