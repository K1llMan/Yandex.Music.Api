using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq;

namespace Yandex.Music.SourceGenerators.Generators.Attributes
{
    public abstract class AttributeGenerator<T>: IAttributeGenerator where T: MemberDeclarationSyntax
    {
        #region Поля

        protected List<T> syntaxNodes = new();

        #endregion Поля

        #region Вспомогательные функции

        private Compilation GetCompilation(GeneratorExecutionContext context)
        {
            CSharpParseOptions options = (context.Compilation as CSharpCompilation).SyntaxTrees[0].Options as CSharpParseOptions;

            context.AddSource(GetHint(), GetSource());
            return context.Compilation.AddSyntaxTrees(CSharpSyntaxTree.ParseText(GetSource(), options));
        }

        private List<ISymbol?> FilterMembersByAttr(Compilation compilation, INamedTypeSymbol attribute)
        {
            return syntaxNodes
                .Select(node => compilation
                    .GetSemanticModel(node.SyntaxTree)
                    .GetDeclaredSymbol(node)
                )
                .Where(t => t != null && 
                    t.GetAttributes().Any(ad => ad.AttributeClass != null && ad.AttributeClass.Equals(attribute, SymbolEqualityComparer.Default))
                )
                .ToList();
        }

        protected virtual string GetHint()
        {
            throw new NotImplementedException();
        }

        protected virtual SourceText GetSource()
        {
            return SourceText.From(GetAttributeText(), Encoding.UTF8);
        }

        protected virtual string GetTypeName()
        {
            throw new NotImplementedException();
        }

        protected virtual string GetAttributeText()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Фильтр узлов для генерации
        /// </summary>
        /// <param name="node">Синтаксический узел</param>
        protected virtual bool FilterNode(SyntaxNode node)
        {
            throw new NotImplementedException();
        }

        protected virtual void ProcessSymbols(GeneratorExecutionContext context, List<ISymbol?> symbol)
        {
            throw new NotImplementedException();
        }

        #endregion Вспомогательные функции


        #region Основные функции

        public void VisitNode(SyntaxNode node)
        {
            if (FilterNode(node))
                syntaxNodes.Add((T)node);
        }

        public void Generate(GeneratorExecutionContext context)
        {
            Compilation compilation = GetCompilation(context);

            // get the newly bound attribute, and INotifyPropertyChanged
            INamedTypeSymbol attribute = compilation.GetTypeByMetadataName(GetTypeName());

            if (attribute == null)
                return;

            ProcessSymbols(context, FilterMembersByAttr(compilation, attribute));
        }

        #endregion Основные функции
    }
}