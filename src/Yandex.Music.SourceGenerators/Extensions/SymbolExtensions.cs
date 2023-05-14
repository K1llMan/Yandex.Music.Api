using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using Yandex.Music.SourceGenerators.Models;

namespace Yandex.Music.SourceGenerators.Extensions
{
    public static class SymbolExtensions
    {
        public static ClassTemplateModel GetTemplateModel(this INamedTypeSymbol classSymbol)
        {
            SyntaxReference syntaxReference = classSymbol.DeclaringSyntaxReferences.First();
            ClassDeclarationSyntax syntax = (ClassDeclarationSyntax)syntaxReference.GetSyntax();
            SyntaxTree tree = syntaxReference.SyntaxTree;
            CompilationUnitSyntax root = (CompilationUnitSyntax)tree.GetRoot();

            return new ClassTemplateModel {
                ClassName = classSymbol.Name,
                ClassModifiers = syntax.Modifiers.ToFullString(),
                Namespace = classSymbol.ContainingNamespace.ToDisplayString(),
                Usings = root.Usings.Select(u => u.Name.ToFullString()).ToList(),
                DocumentationComment = classSymbol.ExtractXmlComment()
            };
        }

        public static string[] ExtractXmlComment(this ISymbol symbol)
        {
            XmlDocument doc = new();
            doc.LoadXml(symbol.GetDocumentationCommentXml());

            return doc.SelectSingleNode("member").ChildNodes
                .Cast<XmlNode>()
                .SelectMany(n => Regex.Split(n.OuterXml, "\r?\n\\s+"))
                .ToArray();
        }
    }
}