using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Yandex.Music.Api.Common.Debug.Writer
{
    public class DefaultDebugWriter : IDebugWriter
    {
        private readonly string logFileName;
        private readonly string debugDir;

        public DefaultDebugWriter(string debugDir, string logFileName)
        {
            this.logFileName = logFileName;
            this.debugDir = debugDir;

            if (!Directory.Exists(this.debugDir))
                Directory.CreateDirectory(this.debugDir);
        }

        public void Error(string requestId, Dictionary<string, List<string>> errors)
        {
            string message = $"{requestId}:" +
                $"{Environment.NewLine}{string.Join("\r\n", errors.Select(p => $"\t{p.Key}\r\n{string.Join("\r\n", p.Value.Select(s => $"\t\t{s}"))}"))}";

            string logFile = Path.Combine(debugDir, logFileName);
            using FileStream logFs = new(logFile, FileMode.Append);
            using StreamWriter logSr = new(logFs);
            logSr.WriteLine(message);
        }

        public void Clear()
        {
            if (!Directory.Exists(debugDir))
                return;

            foreach (string file in Directory.GetFiles(debugDir))
                File.Delete(file);
        }

        public string SaveResponse(string url, string message)
        {
            string fileName = $"{DateTime.Now:yyyy-MM-dd hh-mm-ss.fff} " +
                $"{url.Trim('/').Replace("/", "-").Replace(":", "-")}.json";

            string responseFile = Path.Combine(debugDir, fileName);

            using FileStream fs = new(responseFile, FileMode.Create);
            using StreamWriter sr = new(fs);
            sr.Write(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(message), Formatting.Indented));

            return fileName;
        }
    }
}