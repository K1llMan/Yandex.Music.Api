using System;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using Scriban;

namespace Yandex.Music.SourceGenerators.Common
{
    public static class SourceTemplater
    {
        public static string Render(string templateName, object model)
        {
            string templateString = ResourceReader.GetResource(templateName);

            Template template = Template.Parse(templateString);

            if (template.HasErrors)
            {
                string errors = string.Join(" | ", template.Messages.Select(x => x.Message));
                throw new InvalidOperationException($"Ошибка обработки шаблона: {errors}");
            }

            string render = template.Render(model, memberRenamer: member => member.Name);

            return SyntaxFactory.ParseCompilationUnit(render)
                .NormalizeWhitespace()
                .GetText()
                .ToString();
        }
    }
}