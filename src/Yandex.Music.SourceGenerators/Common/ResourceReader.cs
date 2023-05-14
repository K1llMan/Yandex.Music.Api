using System.IO;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Yandex.Music.SourceGenerators.Common
{
    internal class ResourceReader
    {
        public static string GetResource<TAssembly>(string endWith) => GetResource(endWith, typeof(TAssembly));

        public static string GetResource(string endWith, Type assemblyType = null)
        {
            Assembly assembly = GetAssembly(assemblyType);

            IEnumerable<string> resources = assembly.GetManifestResourceNames().Where(r => r.EndsWith(endWith));

            if (!resources.Any()) 
                throw new InvalidOperationException($"Не найдено ресурсов, оканчивающихся на '{endWith}'");

            if (resources.Count() > 1) 
                throw new InvalidOperationException($"Найдено более одного ресурсана, оканчивающегося на '{endWith}'");

            string resourceName = resources.Single();

            return ReadEmbededResource(assembly, resourceName);
        }

        private static Assembly GetAssembly(Type assemblyType)
        {
            Assembly assembly = assemblyType == null 
                ? Assembly.GetExecutingAssembly() 
                : Assembly.GetAssembly(assemblyType);

            return assembly;
        }

        private static string ReadEmbededResource(Assembly assembly, string name)
        {
            using Stream? resourceStream = assembly.GetManifestResourceStream(name);
            if (resourceStream == null) 
                return null;

            using StreamReader streamReader = new(resourceStream);
            return streamReader.ReadToEnd();
        }
    }
}