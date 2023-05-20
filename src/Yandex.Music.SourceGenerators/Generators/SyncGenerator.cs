using Microsoft.CodeAnalysis;

using System.Collections.Generic;

using Yandex.Music.SourceGenerators.Common;
using Yandex.Music.SourceGenerators.Generators.Attributes;

namespace Yandex.Music.SourceGenerators.Generators
{
    [Generator]
    class SyncGenerator : ISourceGenerator
    {
        #region Поля

        private List<IAttributeGenerator> generators = new() {
            new GenerateSyncAttributeGenerator()
        };

        #endregion Поля

        public void Execute(GeneratorExecutionContext context)
        {
            // retreive the populated receiver 
            if (context.SyntaxReceiver is not SyntaxReceiver)
                return;

            foreach (IAttributeGenerator generator in generators)
            {
                generator.Generate(context);
            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            /*        
            #if DEBUG
            if (!Debugger.IsAttached)
                Debugger.Launch();
            #endif 
            */
            // Register a factory that can create our custom syntax receiver
            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver(generators));
        }
    }
}
