using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yandex.Music.Api.Common.Ynison
{
    public class YnisonWebSocket: IDisposable
    {
        #region Поля

        private readonly JsonSerializerSettings jsonSettings = new() {
            Converters = new List<JsonConverter> {
                new StringEnumConverter {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            },
            NullValueHandling = NullValueHandling.Ignore
        };

        private readonly ClientWebSocket socketClient = new();

        private CancellationTokenSource cancellationTokenSource = new();
        private CancellationToken cancellation;

        private readonly StringBuilder data = new();
        private readonly int size = 4096;

        #endregion Поля

        #region Свойства

        public bool IsConnected => socketClient.State == WebSocketState.Open;

        #endregion Свойства

        #region События

        public class ReceiveEventArgs
        {
            public string Data { get; internal set; }
        }

        public delegate void OnReceiveEventHandler(YnisonWebSocket socket, ReceiveEventArgs args);
        /// <summary>
        /// Получение данных
        /// </summary>
        public event OnReceiveEventHandler OnReceive;

        public class CloseEventArgs
        {
            public WebSocketCloseStatus? Status { get; set; }
            public string Description { get; set; }
        }

        public delegate void OnCloseEventHandler(YnisonWebSocket socket, CloseEventArgs args);
        /// <summary>
        /// Закрытие соединения
        /// </summary>
        public event OnCloseEventHandler OnClose;

        #endregion События

        #region Вспомогательные функции

        private string SerializeJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, jsonSettings);
        }

        private string GetProtocolData(string deviceId, string redirectTicket)
        {
            Dictionary<string, object> deviceInfo = new() {
                { "app_name", "Chrome" },
                { "type", 1 }
            };

            Dictionary<string, string> protocol = new() {
                { "Ynison-Device-Id", deviceId },
                { "Ynison-Device-Info", SerializeJson(deviceInfo) }
            };

            if (!string.IsNullOrEmpty(redirectTicket))
                protocol.Add("Ynison-Redirect-Ticket", redirectTicket);

            return SerializeJson(protocol);
        }

        private async Task<string> ReadSocketContent()
        {
            byte[] buffer = new byte[size];
            WebSocketReceiveResult result;

            do
            {
                result = await socketClient.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                data.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));
            } while (!result.EndOfMessage);

            return data.ToString();
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public bool Connect(AuthStorage storage, string url, string redirectTicket = null)
        {
            socketClient.Options.AddSubProtocol("Bearer");

            socketClient.Options.SetRequestHeader("Sec-WebSocket-Protocol", $"Bearer, v2, {GetProtocolData(storage.DeviceId, redirectTicket)}");
            socketClient.Options.SetRequestHeader("Origin", "https://music.yandex.ru");
            socketClient.Options.SetRequestHeader("Authorization", $"OAuth {storage.Token}");

            socketClient.Options.Proxy = storage.Context.WebProxy;

            socketClient.ConnectAsync(new Uri(url), CancellationToken.None)
                .GetAwaiter()
                .GetResult();

            cancellation = cancellationTokenSource.Token;

            return socketClient.State == WebSocketState.Open;
        }

        public async Task BeginReceive()
        {
            if (socketClient.State != WebSocketState.Open)
                return;

            do
            {
                string content = await ReadSocketContent();
                OnReceive?.Invoke(this, new ReceiveEventArgs {
                    Data = content
                });

                data.Clear();
            } while (!cancellation.IsCancellationRequested && socketClient.State == WebSocketState.Open);

            OnClose?.Invoke(this, new CloseEventArgs {
                Status = socketClient.CloseStatus,
                Description = socketClient.CloseStatusDescription
            });

            await socketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
        }


        public ValueTask Send(string json)
        {
            ReadOnlyMemory<byte> message = new(Encoding.UTF8.GetBytes(json));
            return socketClient.SendAsync(message, WebSocketMessageType.Text, false, CancellationToken.None);
        }

        public Task StopReceive()
        {
            if (socketClient.State != WebSocketState.Open)
                return Task.CompletedTask;

            cancellationTokenSource.Cancel(false);

            return Task.CompletedTask;
        }

        #endregion Основные функции

        #region IDisposable

        public void Dispose()
        {
            socketClient?.Dispose();
            cancellationTokenSource?.Dispose();
        }

        #endregion IDisposable
    }
}