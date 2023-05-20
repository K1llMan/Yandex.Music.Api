using Microsoft.CodeAnalysis;

namespace Yandex.Music.SourceGenerators.Models
{
    public class MethodParameterTemplateModel : BaseTemplateModel<IParameterSymbol>
    {
        public TypeTemplateModel Type { get; set; }

        public override string ToString()
        {
            string defaultValue = "";

            if (Symbol.HasExplicitDefaultValue)
            {
                defaultValue = " = " + Symbol.ExplicitDefaultValue switch {
                    "" => "\"\"",
                    null => "null",
                    _ when Symbol.ExplicitDefaultValue is bool => Symbol.ExplicitDefaultValue.ToString().ToLower(),
                    _ => Symbol.ExplicitDefaultValue.ToString()
                };
            }

            return Symbol + defaultValue;
        }
    }
}