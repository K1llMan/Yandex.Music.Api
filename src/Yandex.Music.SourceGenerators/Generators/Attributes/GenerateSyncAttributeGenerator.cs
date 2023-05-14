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

        private void ProcessMethod(StringBuilder source, IMethodSymbol methodSymbol)
        {
            // SayHello => SayHelloAsync
            string asyncMethodName = $"{methodSymbol.Name}Async";
            string staticModifier = methodSymbol.IsStatic ? "static" : string.Empty;

            // void => Task, bool => Task<bool>
            string asyncReturnType = methodSymbol.ReturnType.Name == "Void" ?
                "Task" :
                $"Task<{methodSymbol.ReturnType.Name}>";

            // int number, string name
            string parameters = string.Join(",", methodSymbol.Parameters.Select(p => $"{p.Type} {p.Name}"));
            // number, name
            string arguments = string.Join(",", methodSymbol.Parameters.Select(p => p.Name));

            source.Append($@"
            /// <summary>
            /// Асинхронный {methodSymbol.Name}
            /// </summary>
            public {staticModifier} {asyncReturnType} {asyncMethodName}({parameters})
            {{
                return Task.Run(() => {methodSymbol.Name}({arguments}));
            }}
            ");
        }

        private string ProcessClass(INamedTypeSymbol classSymbol)
        {
            if (!classSymbol.ContainingSymbol.Equals(classSymbol.ContainingNamespace, SymbolEqualityComparer.Default))
            {
                return null; //TODO: issue a diagnostic that it must be top level
            }

            return SourceTemplater.Render("SyncClassTemplate.tmp", classSymbol.GetTemplateModel());
            /*
            // begin building the generated source
            string namespaceName = classSymbol.ContainingNamespace.ToDisplayString();

            StringBuilder source = new($@"
{usings}

namespace {namespaceName}
{{
    public partial class {classSymbol.Name}
    {{
");

            foreach (ISymbol? member in classSymbol.GetMembers())
            {
                if (member is IMethodSymbol method)
                {
                    if (!method.Name.EndsWith("Async") && method.ReturnType.Name != "Task" && !method.IsAsync)
                        continue;

                    ProcessMethod(source, method);
                }

                source.Append("} }");
            }
            */
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