using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using Yandex.Music.SourceGenerators.Models;

namespace Yandex.Music.SourceGenerators.Extensions
{
    public static class SymbolExtensions
    {
        private static string GetTypeName(ITypeSymbol typeSymbol)
        {
            if (typeSymbol.SpecialType != SpecialType.None)
                return typeSymbol.ToString();

            if (typeSymbol is IArrayTypeSymbol arrayTypeSymbol)
                return GetTypeName(arrayTypeSymbol.ElementType);

            return typeSymbol.Name;
        }

        public static TypeTemplateModel GetTemplateModel(this ITypeSymbol typeSymbol)
        {
            TypeTemplateModel model = new() {
                Symbol = typeSymbol,
                Name = GetTypeName(typeSymbol),
                DocumentationComment = typeSymbol.ExtractXmlComment()
            };

            if (typeSymbol is INamedTypeSymbol namedTypeSymbol)
                model.Arguments = namedTypeSymbol.TypeArguments
                        .Select(t => t.GetTemplateModel())
                        .ToList();

            if (typeSymbol is IArrayTypeSymbol arrayTypeSymbol)
                model.IsArray = true;

            return model;
        }

        public static MethodParameterTemplateModel GetTemplateModel(this IParameterSymbol parameterSymbol)
        {
            return new MethodParameterTemplateModel {
                Symbol = parameterSymbol,
                Name = parameterSymbol.Name,
                DocumentationComment = parameterSymbol.ExtractXmlComment(),
                Type = parameterSymbol.Type.GetTemplateModel()
            };
        }

        public static MethodTemplateModel GetTemplateModel(this IMethodSymbol methodSymbol)
        {
            return new MethodTemplateModel {
                Symbol = methodSymbol,
                Name = methodSymbol.Name,
                DocumentationComment = methodSymbol.ExtractXmlComment(),
                Accessibility = methodSymbol.DeclaredAccessibility.ToString().ToLower(),
                Parameters = methodSymbol.Parameters
                    .Select(p => p.GetTemplateModel())
                    .ToList(),
                ReturnType = methodSymbol.ReturnType.GetTemplateModel()
            };
        }

        public static ClassTemplateModel GetTemplateModel(this INamedTypeSymbol classSymbol)
        {
            SyntaxReference syntaxReference = classSymbol.DeclaringSyntaxReferences.First();
            ClassDeclarationSyntax syntax = (ClassDeclarationSyntax)syntaxReference.GetSyntax();
            SyntaxTree tree = syntaxReference.SyntaxTree;
            CompilationUnitSyntax root = (CompilationUnitSyntax)tree.GetRoot();

            List<IMethodSymbol> methods = classSymbol.GetMembers()
                .OfType<IMethodSymbol>()
                .ToList();

            return new ClassTemplateModel {
                Symbol = classSymbol,
                Name = classSymbol.Name,
                DocumentationComment = classSymbol.ExtractXmlComment(),
                Modifiers = syntax.Modifiers.ToFullString().Trim(),
                Methods = methods
                    .Select(m => m.GetTemplateModel())
                    .ToList(),
                Namespace = classSymbol.ContainingNamespace.ToDisplayString(),
                Usings = root.Usings.Select(u => u.Name.ToFullString()).ToList(),
            };
        }

        public static string[] ExtractXmlComment(this ISymbol symbol)
        {
            string xmlString = symbol.GetDocumentationCommentXml();

            if (string.IsNullOrEmpty(xmlString))
                return new string[] { };

            XmlDocument doc = new();
            doc.LoadXml(symbol.GetDocumentationCommentXml());

            return doc.SelectSingleNode("member").ChildNodes
                .Cast<XmlNode>()
                .SelectMany(n => Regex.Split(n.OuterXml, "\r?\n\\s+"))
                .ToArray();
        }
    }
}