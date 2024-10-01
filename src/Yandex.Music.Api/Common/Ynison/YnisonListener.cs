using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

using Yandex.Music.Api.Models.Ynison;
using Yandex.Music.Api.Models.Ynison.Messages;

namespace Yandex.Music.Api.Common.Ynison
{
    public class YnisonListener : IDisposable
    {
        #region Поля

        private readonly JsonSerializerSettings jsonSettings = new() {
            Converters = new List<JsonConverter> {
                new StringEnumConverter()
            },
            
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver {
                // Важно! Унисон отдаёт данные в SnakeCase
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        private AuthStorage storage;
        private YnisonWebSocket redirector;
        private YnisonWebSocket state;

        #endregion Поля

        #region Свойства

        /// <summary>
        /// Состояние
        /// </summary>
        public YYnisonState State { get; internal set; }

        #endregion Свойства

        #region События

        public class ReceiveEventArgs
        {
            public YYnisonState State { get; internal set; }
        }

        public delegate void OnReceiveEventHandler(ReceiveEventArgs args);

        /// <summary>
        /// Получение данных
        /// </summary>
        public event OnReceiveEventHandler OnReceive;

        #endregion События

        #region Вспомогательные функции

        private string SerializeJson(object data)
        {
            return JsonConvert.SerializeObject(data, jsonSettings);
        }

        private T Deserialize<T>(YYnisonMessageType messageType, string data)
        {
            return storage.Debug != null
                ? storage.Debug.Deserialize<T>($"Ynison{messageType}", data, jsonSettings)
                : JsonConvert.DeserializeObject<T>(data, jsonSettings);
        }

        private T DeserializeMessage<T>(YYnisonMessageType messageType, string data)
        {
            JObject o = JObject.Parse(data);
            // Сообщение с ошибкой
            if (o.ContainsKey("error"))
            {
                YYnisonErrorMessage exception = Deserialize<YYnisonErrorMessage>(YYnisonMessageType.Error, data);
                throw exception ?? new Exception("Ошибка десериализации ответа с ошибкой.");
            }

            return Deserialize<T>(messageType, data);
        }

        private string DefaultState()
        {
            YYnisonVersion version = new() {
                DeviceId = storage.DeviceId
            };

            YYnisonUpdateFullStateMessage fullState = new () {
                UpdateFullState = new() {
                    Device = new() {
                        Info = new() {
                            DeviceId = storage.DeviceId,
                            AppName = "Yandex Music API",
                            AppVersion = "0.0.1",
                            Type = "WEB",
                            Title = "YandexMusicAPI"
                        }
                    },
                    PlayerState = new() {
                        PlayerQueue = new() {
                            Version = version
                        },
                        Status = new() {
                            Version = version
                        }
                    }
                }
            };

            return SerializeJson(fullState);
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public void Connect()
        {
            redirector.Connect(storage, "wss://ynison.music.yandex.ru/redirector.YnisonRedirectService/GetRedirectToYnison");
            redirector.OnReceive += data => {
                YYnisonRedirect redirectInfo = Deserialize<YYnisonRedirect>(YYnisonMessageType.Redirect, data.Data);

                if (state.IsConnected)
                    return;

                state.Connect(storage, $"wss://{redirectInfo.Host}/ynison_state.YnisonStateService/PutYnisonState", redirectInfo.RedirectTicket);
                state.OnReceive += d => {
                    YYnisonState s = DeserializeMessage<YYnisonState>(YYnisonMessageType.State, d.Data);

                    State = s;

                    OnReceive?.Invoke(new ReceiveEventArgs {
                        State = State
                    });
                };
                state.BeginReceive();
                // Отправка изначального состояния
                state.Send(DefaultState());
            };

            redirector.BeginReceive();
        }

        public void Disconnect()
        {
            state?.StopReceive();
            redirector?.StopReceive();
        }

        public YnisonListener(AuthStorage authStorage)
        {
            storage = authStorage;

            redirector = new();
            state = new();
        }

        #endregion Основные функции

        #region IDisposable

        public void Dispose()
        {
            redirector?.StopReceive();
            redirector?.Dispose();
        }

        #endregion IDisposable
    }
}