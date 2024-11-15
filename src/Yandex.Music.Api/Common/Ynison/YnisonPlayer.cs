using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json.Linq;

using Yandex.Music.Api.Models.Track;
using Yandex.Music.Api.Models.Ynison;
using Yandex.Music.Api.Models.Ynison.Messages;
using System.Net.WebSockets;

namespace Yandex.Music.Api.Common.Ynison
{
    public class YnisonPlayer : IDisposable
    {
        #region Поля

        private readonly JsonSerializerSettings jsonSettings = new() {
            Converters = new List<JsonConverter> {
                new StringEnumConverter(new UpperSnakeCaseNamingStrategy())
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
        /// API
        /// </summary>
        public YandexMusicApi API { get; internal set; }

        /// <summary>
        /// Состояние
        /// </summary>
        public YYnisonState State { get; internal set; }

        /// <summary>
        /// Текущий проигрываемый трек
        /// </summary>
        public YTrack Current => GetCurrent();

        #endregion Свойства

        #region События

        public class ReceiveEventArgs
        {
            public YYnisonState State { get; internal set; }
        }

        public delegate void OnReceiveEventHandler(YnisonPlayer player, ReceiveEventArgs args);

        /// <summary>
        /// Получение данных
        /// </summary>
        public event OnReceiveEventHandler OnReceive;


        public class CloseEventArgs
        {
            public WebSocketCloseStatus? Status { get; set; }
            public string Description { get; set; }
        }

        public delegate void OnCloseEventHandler(YnisonPlayer player, CloseEventArgs args);

        /// <summary>
        /// Получение данных
        /// </summary>
        public event OnCloseEventHandler OnClose;

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
                DeviceId = storage.DeviceId,
                Version = "0"
            };

            YYnisonUpdateFullStateMessage fullState = new () {
                UpdateFullState = new() {
                    Device = new() {
                        Capabilities = new() {
                            CanBePlayer = true
                        },
                        Info = new() {
                            DeviceId = storage.DeviceId,
                            AppName = "Yandex Music API",
                            AppVersion = "0.0.1",
                            Type = "WEB",
                            Title = "YandexMusicAPI"
                        },
                        IsShadow = true
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

        private YTrack GetCurrent()
        {
            if (State == null)
                return null;

            int index = State.PlayerState.PlayerQueue.CurrentPlayableIndex;
            if (index < 0 || index > State.PlayerState.PlayerQueue.PlayableList.Count)
                return null;

            YYnisonPlayableItem item = State.PlayerState.PlayerQueue.PlayableList[index];

            return API.Track.Get(storage, item.PlayableId)
                .Result
                .FirstOrDefault();
        }

        private void UpdateState()
        {
            YYnisonUpdatePlayerStateMessage update = new() {
                UpdatePlayerState = State.PlayerState
            };

            update.UpdatePlayerState.Status.Version = new() {
                DeviceId = storage.DeviceId
            };

            update.UpdatePlayerState.PlayerQueue.Version = new() {
                DeviceId = storage.DeviceId
            };

            try
            {
                state.Send(SerializeJson(update));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        #endregion Вспомогательные функции

        #region Основные функции

        #region Подключение

        public void Connect()
        {
            redirector.Connect(storage, "wss://ynison.music.yandex.ru/redirector.YnisonRedirectService/GetRedirectToYnison");
            redirector.OnReceive += (socket, data)=> {
                YYnisonRedirect redirectInfo = Deserialize<YYnisonRedirect>(YYnisonMessageType.Redirect, data.Data);

                if (state.IsConnected)
                    return;

                state.Connect(storage, $"wss://{redirectInfo.Host}/ynison_state.YnisonStateService/PutYnisonState", redirectInfo.RedirectTicket);
                state.OnReceive += (s, d) => {
                    YYnisonState message = DeserializeMessage<YYnisonState>(YYnisonMessageType.State, d.Data);

                    State = message;

                    OnReceive?.Invoke(this, new ReceiveEventArgs {
                        State = State
                    });
                };

                state.OnClose += (s, args) => {
                    OnClose?.Invoke(this, new CloseEventArgs {
                        Status = args.Status,
                        Description = args.Description
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

        #endregion Подключение

        #region Плеер

        /*
        public void Play()
        {

        }

        public void Stop()
        {

        }

        public void Next()
        {
            List<YYnisonPlayableItem> list = State.PlayerState.PlayerQueue.PlayableList;

            if (State.PlayerState.PlayerQueue.EntityType == YYnisonEntityType.Radio)
            {
                YYnisonPlayableItem next = State.PlayerState.PlayerQueue.Queue.WaveQueue.RecommendedPlayableList
                    .FirstOrDefault();

                list.RemoveAt(0);
                list.Add(next);

                UpdateState();
            }

            if (State.PlayerState.PlayerQueue.CurrentPlayableIndex < list.Count - 1)
            {
                State.PlayerState.PlayerQueue.CurrentPlayableIndex++;
                UpdateState();
            }
        }

        public void Previous()
        {

        }
        */

        #endregion Плеер

        internal YnisonPlayer(YandexMusicApi api, AuthStorage authStorage)
        {
            API = api;
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