using System;
using System.IO;
using Newtonsoft.Json;

namespace Yandex.Music.Api.Common
{
    internal class DefaultDebugWriter : IYDebugWriter
    {
        private readonly string _logFileName;
        private readonly string _debugDir;

        public DefaultDebugWriter(string debugDir, string logFileName)
        {
            _logFileName = logFileName;
            _debugDir = debugDir;

            if (!Directory.Exists(debugDir))
                Directory.CreateDirectory(debugDir);

            if (File.Exists(logFileName))
                File.Delete(logFileName);
        }

        public void Error(string message)
        {
            using FileStream logFs = new(_logFileName, FileMode.Append);
            using StreamWriter logSr = new(logFs);
            logSr.WriteLine(message);
        }

        public void Debug(string message)
        {
            throw new NotImplementedException();
        }

        public void Debug(string fileName, string message)
        {
            var fn = Path.Combine(_debugDir, fileName);

            using FileStream fs = new(fn, FileMode.Create);
            using StreamWriter sr = new(fs);
            sr.Write(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(message), Formatting.Indented));
        }
    }
}