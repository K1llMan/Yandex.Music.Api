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
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            },
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        private YnisonWebSocket redirector;
        private YnisonWebSocket state;

        #endregion Поля

        #region Свойства

        /// <summary>
        /// Устройство
        /// </summary>
        public string DeviceId { get; }

        /// <summary>
        /// Состояние
        /// </summary>
        public string State { get; internal set; }

        #endregion Свойства

        #region Вспомогательные функции

        private string SerializeJson(object data)
        {
            return JsonConvert.SerializeObject(data, jsonSettings);
        }

        private string DefaultState()
        {
            return """
{
    "update_full_state": {
            "player_state": {
                "player_queue": {
                    "current_playable_index": -1,
                    "entity_id": "",
                    "entity_type": "VARIOUS",
                    "playable_list": [],
                    "options": {
                        "repeat_mode": "NONE"
                    },
                    "entity_context": "BASED_ON_ENTITY_BY_DEFAULT",
                    "version": {
                        "device_id": "csharp",
                        "version": "0",
                        "timestamp_ms": "0"
                    },
                    "from_optional": ""
                },
                "status": {
                    "duration_ms": 0,
                    "paused": true,
                    "playback_speed": 1,
                    "progress_ms": 0,
                    "version": {
                        "device_id": "csharp",
                        "version": "0",
                        "timestamp_ms": "0"
                    }
                }
            },
            "device": {
                "capabilities": {
                    "can_be_player": false,
                    "can_be_remote_controller": true,
                    "volume_granularity": 0
                },
                "info": {
                    "device_id": "csharp",
                    "type": "ANDROID",
                    "app_version": "2024.05.1 #46gpr",
                    "title": "Xiaomi",
                    "app_name": "Yandex Music"
                },
                "volume_info": {
                    "volume": 0
                },
                "is_shadow": false
            },
            "is_currently_active": false
        },
        "rid": "cade6dcf-b138-49e8-a4f5-e8f295beb963",
        "player_action_timestamp_ms": 0,
        "activity_interception_type": "DO_NOT_INTERCEPT_BY_DEFAULT"
    }
""";
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public void Connect(string token)
        {
            redirector = new("wss://ynison.music.yandex.ru/redirector.YnisonRedirectService/GetRedirectToYnison");
            redirector.Connect(token);
            redirector.OnReceive += data => {
                Console.WriteLine(data.Data);

                YYnisonRedirect redirectInfo = JsonConvert.DeserializeObject<YYnisonRedirect>(data.Data, jsonSettings);

                if (state != null)
                    return;

                state = new($"wss://{redirectInfo.Host}/ynison_state.YnisonStateService/PutYnisonState");
                state.Connect(token, redirectInfo.RedirectTicket);
                state.OnReceive += d => {
                    Console.WriteLine(d.Data);
                    State = d.Data;
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

        public YnisonListener(string device)
        {
            DeviceId = device;
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