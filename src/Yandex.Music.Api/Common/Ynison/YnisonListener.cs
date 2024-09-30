using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;

using Yandex.Music.Api.Models.Ynison;

namespace Yandex.Music.Api.Common.Ynison
{
    public class YnisonListener : IDisposable
    {
        #region Поля

        private readonly JsonSerializerSettings jsonSettings = new() {
            Converters = new List<JsonConverter> {
                new StringEnumConverter {
                    // Важно! Унисон отдаёт данные в SnakeCase
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
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
        public string State { get; internal set; }

        #endregion Свойства

        #region События

        public class ReceiveEventArgs
        {
            public string State { get; internal set; }
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

        private string DefaultState()
        {
            YYnisonVersion version = new() {
                DeviceId = storage.DeviceId
            };

            YYnisonUpdateFullState fullState = new () {
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
            redirector = new(storage, "wss://ynison.music.yandex.ru/redirector.YnisonRedirectService/GetRedirectToYnison");
            redirector.Connect();
            redirector.OnReceive += data => {
                YYnisonRedirect redirectInfo = JsonConvert.DeserializeObject<YYnisonRedirect>(data.Data, jsonSettings);

                if (state != null)
                    return;

                state = new(storage, $"wss://{redirectInfo.Host}/ynison_state.YnisonStateService/PutYnisonState");
                state.Connect(redirectInfo.RedirectTicket);
                state.OnReceive += d => {
                    State = d.Data;

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