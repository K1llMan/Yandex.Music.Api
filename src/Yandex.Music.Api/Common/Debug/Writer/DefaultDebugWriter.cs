using System;
using System.IO;
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

            if (!Directory.Exists(debugDir))
                Directory.CreateDirectory(debugDir);
        }

        public void Error(string message)
        {
            var logFile = Path.Combine(debugDir, logFileName);
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

            var responseFile = Path.Combine(debugDir, fileName);

            using FileStream fs = new(responseFile, FileMode.Create);
            using StreamWriter sr = new(fs);
            sr.Write(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(message), Formatting.Indented));

            return fileName;
        }
    }
}