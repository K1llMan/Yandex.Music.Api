namespace Yandex.Music.Api.Models.Ynison.Messages
{
    public class YYnisonUpdatePlayerStateMessage : YYnisonUpdateMessage
    {
        public YYnisonPlayerState UpdatePlayerState { get; set; }
    }
}