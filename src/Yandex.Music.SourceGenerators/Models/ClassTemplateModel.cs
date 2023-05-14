using System.Collections.Generic;

namespace Yandex.Music.SourceGenerators.Models
{
    public class ClassTemplateModel
    {
        public string ClassName { get; set; }
        public string ClassModifiers { get; set; }
        public string Namespace { get; set; }
        public List<string> Usings { get; set; }
        public string[] DocumentationComment { get; set; }
    }
}