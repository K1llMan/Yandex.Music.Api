namespace Yandex.Music.Api.Models.Ynison
{
    public class YYnisonDeviceFull : YYnisonDevice
    {
        public YYnisonSession Session { get; set; }
        public decimal Volume { get; set; }
        // Эта опция даёт ошибку 500 при попытке отправки на инициализации
        public bool IsOffline { get; set; }
    }
}
