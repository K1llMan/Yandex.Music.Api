using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yandex.Music.SourceGenerators.Generators.Attributes
{
    public class AsyncifyAttributeGenerator : AttributeGenerator<MethodDeclarationSyntax>
    {
        #region Вспомогательные функции

        private void ProcessMethod(StringBuilder source, IMethodSymbol methodSymbol)
        {
            if (methodSymbol.IsAsync)
            {
                // Already async, maybe emit a diagnostic?
                return;
            }

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

        private string ProcessClass(INamedTypeSymbol classSymbol, List<IMethodSymbol> methods)
        {
            if (!classSymbol.ContainingSymbol.Equals(classSymbol.ContainingNamespace, SymbolEqualityComparer.Default))
            {
                return null; //TODO: issue a diagnostic that it must be top level
            }

            string namespaceName = classSymbol.ContainingNamespace.ToDisplayString();

            // begin building the generated source
            StringBuilder source = new($@"
using System.Threading.Tasks;

namespace {namespaceName}
{{
    public partial class {classSymbol.Name}
    {{
");

            // create properties for each field 
            foreach (IMethodSymbol? methodSymbol in methods)
            {
                ProcessMethod(source, methodSymbol);
            }

            source.Append("} }");
            return source.ToString();
        }

        #endregion Вспомогательные функции

        #region Перегруженные методы

        protected override string GetAttributeText()
        {
            return @"
namespace System
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    sealed class AsyncifyAttribute : Attribute
    {
        public AsyncifyAttribute()
        {
        }
    }
}
";
        }

        protected override string GetHint()
        {
            return "AsyncifyAttribute";
        }

        protected override string GetTypeName()
        {
            return "System.AsyncifyAttribute";
        }

        protected override bool FilterNode(SyntaxNode node)
        {
            return node is MethodDeclarationSyntax { AttributeLists.Count: > 0 };
        }

        protected override void ProcessSymbols(GeneratorExecutionContext context, List<ISymbol?> symbol)
        {
            foreach (IGrouping<INamedTypeSymbol, IMethodSymbol>? group in symbol.OfType<IMethodSymbol>().GroupBy(f => f.ContainingType))
            {
                string classSource = ProcessClass(group.Key, group.ToList());
                context.AddSource($"{group.Key.Name}_asyncify.cs", SourceText.From(classSource, Encoding.UTF8));
            }
        }
        #endregion Перегруженные методы
    }
}