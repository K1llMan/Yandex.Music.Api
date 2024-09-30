namespace Yandex.Music.Api.Models.Ynison
{
    public class YYnisonDevice
    {
        public YYnisonDeviceCapabilities Capabilities { get; set; } = new();
        public YYnisonDeviceInfo Info { get; set; }
        public YYnisonDeviceVolumeInfo VolumeInfo { get; set; } = new();
        public bool IsShadow { get; set; }
    }
}