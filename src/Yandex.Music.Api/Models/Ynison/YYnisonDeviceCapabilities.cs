namespace Yandex.Music.Api.Models.Ynison
{
    public class YYnisonDeviceCapabilities
    {
        public bool CanBePlayer { get; set; }
        public bool CanBeRemoteController { get; set; } = true;
        public decimal VolumeGranularity { get; set; }
    }
}