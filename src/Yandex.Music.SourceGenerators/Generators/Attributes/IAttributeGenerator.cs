using Microsoft.CodeAnalysis;

namespace Yandex.Music.SourceGenerators.Generators.Attributes
{
    /// <summary>
    /// Генератор по атрибуту
    /// </summary>
    public interface IAttributeGenerator
    {
        void VisitNode(SyntaxNode node);
        void Generate(GeneratorExecutionContext context);
    }
}