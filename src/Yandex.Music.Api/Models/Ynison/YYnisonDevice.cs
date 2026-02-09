namespace Yandex.Music.Api.Models.Ynison
{
    public class YYnisonDevice
    {
        public YYnisonDeviceInfo Info { get; set; }
        public YYnisonDeviceCapabilities Capabilities { get; set; } = new();
        public YYnisonDeviceVolumeInfo VolumeInfo { get; set; } = new();
        public bool IsShadow { get; set; }
    }
}
