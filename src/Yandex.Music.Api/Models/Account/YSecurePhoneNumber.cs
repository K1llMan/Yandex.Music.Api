using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account;

public class YSecurePhoneNumber
{
    [JsonProperty("masked_e164")]
    public string MaskedE164 { get; set; }
    
    [JsonProperty("masked_international")]
    public string MaskedInternational { get; set; }
    
    [JsonProperty("masked_original")]
    public string MaskedOriginal { get; set; }
}