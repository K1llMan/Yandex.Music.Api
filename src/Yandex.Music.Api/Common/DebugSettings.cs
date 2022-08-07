using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

namespace Yandex.Music.Api.Common
{
    public class DebugSettings
    {
        #region Поля

        private readonly string debugDir;
        private readonly string logFileName;

        #endregion Поля

        #region Свойства

        public bool ClearDirectory { get; set; }

        public string LogFileName { get; }

        public string OutputDir { get; }

        #endregion Свойства

        #region Основные функции

        public T Deserialize<T>(string url, string json, JsonSerializerSettings settings)
        {
            Dictionary<string, List<string>> errors = new();

            settings.Error = (sender, args) =>  {
                int pos = args.ErrorContext.Error.Message.IndexOf("Path", StringComparison.Ordinal);
                string error = args.ErrorContext.Error.Message.Substring(0, pos);
                string path = args.ErrorContext.Error.Message.Substring(pos);

                if (!errors.ContainsKey(error))
                    errors[error] = new List<string>();

                errors[error].Add(path);
                args.ErrorContext.Handled = true;
            };

            settings.MissingMemberHandling = MissingMemberHandling.Error;

            T obj = JsonConvert.DeserializeObject<T>(json, settings);

            // Запись ответа от API с ошибкой
            if (errors.Count > 0) {
                if (!Directory.Exists(OutputDir))
                    Directory.CreateDirectory(OutputDir);

                string fileName = Path.Combine(debugDir, $"{DateTime.Now:yyyy-MM-dd hh-mm-ss.fff} " +
                    $"{url.Trim('/').Replace("/", "-").Replace(":", "-")}.json");

                using FileStream fs = new(fileName, FileMode.Create);
                using StreamWriter sr = new(fs);
                sr.Write(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(json), Formatting.Indented));

                using FileStream logFs = new(logFileName, FileMode.Append);
                using StreamWriter logSr = new(logFs);
                logSr.WriteLine($"{fileName}:");
                logSr.WriteLine(string.Join("\r\n", errors.Select(p =>
                    $"\t{p.Key}\r\n: {string.Join("\r\n", p.Value.Select(s => $"\t\t{s}"))}")));
            }

            return obj;
        }

        public void Clear()
        {
            if (!Directory.Exists(debugDir))
                return;

            foreach (string file in Directory.GetFiles(debugDir))
                File.Delete(file);
        }

        public DebugSettings(string outputDir, string logFile)
        {
            OutputDir = outputDir;
            LogFileName = logFile;

            debugDir = Path.Combine(AppContext.BaseDirectory, OutputDir);
            logFileName = Path.Combine(debugDir, LogFileName);

            if (File.Exists(logFileName))
                File.Delete(logFileName);
        }

        #endregion Основные функции
    }
}