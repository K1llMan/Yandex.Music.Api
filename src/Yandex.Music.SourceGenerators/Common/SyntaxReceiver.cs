using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Threading.Tasks;

using Yandex.Music.SourceGenerators.Generators.Attributes;

namespace Yandex.Music.SourceGenerators.Common
{
    /// <summary>
    /// Создаётся по требованию при каждом проходе генератора
    /// </summary>
    internal class SyntaxReceiver : ISyntaxReceiver
    {
        #region Поля

        private List<IAttributeGenerator> generatorsList;

        #endregion Поля

        #region Основные функции

        /// <summary>
        /// Вызывается для каждого узла при компиляции, можно использовать полезную для генерации информацию
        /// </summary>
        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            Parallel.ForEach(generatorsList, g => g.VisitNode(syntaxNode));
        }

        public SyntaxReceiver(List<IAttributeGenerator> generators)
        {
            generatorsList = generators;
        }

        #endregion Основные функции
    }
}