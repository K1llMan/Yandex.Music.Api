using System.Collections.Generic;

namespace Yandex.Music.Api.Models
{
    public class YandexAccount
    {
        public bool Status { get; set; }
        public string UID { get; set; }
        public string Login { get; set; }
        public YandexAccountDisplayName DisplayName { get; set; }
        
        public class YandexAccountDisplayName
        {
            public string Name { get; set; }
            public string DefaultAvatar { get; set; }
        }
    }

    public class YandexAccountResult
    {
        public string DefaultUID { get; set; }
        public List<YandexAccount> Accounts { get; set; }
        public bool CanAddMore { get; set; }
    }
}