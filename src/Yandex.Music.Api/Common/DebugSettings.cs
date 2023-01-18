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
        private readonly IYDebugWriter _debugger;

        #endregion Поля

        #region Свойства

        public bool SaveResponse { get; set; }

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

            string fileName = $"{DateTime.Now:yyyy-MM-dd hh-mm-ss.fff} " +
                              $"{url.Trim('/').Replace("/", "-").Replace(":", "-")}.json";

            // Ответ сохраняется либо безусловно, либо при ошибке
            if (SaveResponse || errors.Count > 0)
            {
                _debugger.Debug(fileName, JsonConvert.SerializeObject(JsonConvert.DeserializeObject(json), Formatting.Indented)); 
            }

            // Запись ответа от API с ошибкой
            if (errors.Count > 0)
            {
                _debugger.Error($"{fileName}:{Environment.NewLine}{string.Join("\r\n", errors.Select(p => $"\t{p.Key}\r\n: {string.Join("\r\n", p.Value.Select(s => $"\t\t{s}"))}"))}");
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

        public DebugSettings(IYDebugWriter debugger)
        {
            _debugger = debugger;
        }
        
        public DebugSettings(string outputDir, string logFile)
        {
            OutputDir = outputDir;
            LogFileName = logFile;

            debugDir = Path.Combine(AppContext.BaseDirectory, OutputDir);
            //LogFileName = Path.Combine(debugDir, LogFileName);

            _debugger = new DefaultDebugWriter(outputDir, logFile);
        }

        #endregion Основные функции
    }
}