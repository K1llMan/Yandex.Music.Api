using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Yandex.Music.Api.Common.Debug.Writer;

namespace Yandex.Music.Api.Common.Debug
{
    public class DebugSettings
    {
        #region Поля

        private readonly IDebugWriter debugWriter;

        #endregion Поля

        #region Свойства

        public bool SaveResponse { get; set; }

        public bool ClearDirectory { get; set; }

        #endregion Свойства

        #region Основные функции

        public T Deserialize<T>(string url, string json, JsonSerializerSettings settings)
        {
            Dictionary<string, List<string>> errors = new();

            settings.Error = (sender, args) => {
                int pos = args.ErrorContext.Error.Message.IndexOf("Path", StringComparison.Ordinal);
                string error = pos  > 0 
                    ? args.ErrorContext.Error.Message.Substring(0, pos)
                    : args.ErrorContext.Error.Message;
                string path = pos > 0 
                    ? args.ErrorContext.Error.Message.Substring(pos) 
                    : args.ErrorContext.Path;

                if (!errors.ContainsKey(error))
                    errors[error] = new List<string>();

                errors[error].Add(path);
                args.ErrorContext.Handled = true;
            };

            settings.MissingMemberHandling = MissingMemberHandling.Error;

            T obj = JsonConvert.DeserializeObject<T>(json, settings);

            string requestId = string.Empty;

            // Ответ сохраняется либо безусловно, либо при ошибке
            if (SaveResponse || errors.Count > 0)
            {
                requestId = debugWriter.SaveResponse(url, JsonConvert.SerializeObject(JsonConvert.DeserializeObject(json), Formatting.Indented));
            }

            // Запись ответа от API с ошибкой
            if (errors.Count > 0)
            {
                debugWriter.Error(requestId, errors);
            }

            return obj;
        }

        public void Clear()
        {
            debugWriter.Clear();
        }

        public DebugSettings(IDebugWriter debugWriter)
        {
            this.debugWriter = debugWriter;
        }

        #endregion Основные функции
    }
}