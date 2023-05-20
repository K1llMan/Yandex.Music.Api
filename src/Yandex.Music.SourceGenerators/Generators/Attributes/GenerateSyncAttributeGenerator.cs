using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

using Yandex.Music.SourceGenerators.Common;
using Yandex.Music.SourceGenerators.Extensions;
using Yandex.Music.SourceGenerators.Models;

namespace Yandex.Music.SourceGenerators.Generators.Attributes
{
    public class GenerateSyncAttributeGenerator : AttributeGenerator<ClassDeclarationSyntax>
    {
        #region Вспомогательные функции

        private ClassTemplateModel ModifyModel(ClassTemplateModel model)
        {
            // Только публичные асинхронные методы
            Predicate<IMethodSymbol> methodPredicate = m => m.MethodKind != MethodKind.Constructor
                && m.DeclaredAccessibility == Accessibility.Public
                && (m.IsAsync || m.ReturnType.Name == "Task");

            model.Methods = model.Methods
                .Where(m => methodPredicate(m.Symbol))
                .ToList();

            return model;
        }

        private string ProcessClass(INamedTypeSymbol classSymbol)
        {
            if (!classSymbol.ContainingSymbol.Equals(classSymbol.ContainingNamespace, SymbolEqualityComparer.Default))
            {
                return null; //TODO: issue a diagnostic that it must be top level
            }

            return SourceTemplater.Render(
                "SyncClassTemplate.tmp", 
                ModifyModel(classSymbol.GetTemplateModel())
            );
        }

        #endregion Вспомогательные функции

        #region Перегруженные методы

        protected override string GetAttributeText()
        {
            return ResourceReader.GetResource("GenerateSyncAttributeTemplate.tmp");
        }

        protected override string GetHint()
        {
            return "GenerateSyncAttribute";
        }

        protected override string GetTypeName()
        {
            return "System.GenerateSyncAttribute";
        }

        protected override bool FilterNode(SyntaxNode node)
        {
            return node is ClassDeclarationSyntax { AttributeLists.Count: > 0 };
        }

        protected override void ProcessSymbols(GeneratorExecutionContext context, List<ISymbol?> symbol)
        {
            foreach (INamedTypeSymbol? type in symbol)
            {
                string data = ProcessClass(type);

                context.AddSource($"{type.Name}Sync.cs", SourceText.From(data, Encoding.UTF8));
            }
        }

        #endregion Перегруженные методы
    }
}