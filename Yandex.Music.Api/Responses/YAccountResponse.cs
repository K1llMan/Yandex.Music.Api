using System.Collections.Generic;

namespace Yandex.Music.Api.Responses
{
    public class YAccountDisplayName
    {
        public string Name { get; set; }
        public string DefaultAvatar { get; set; }
    }

    public class YAccount
    {
        public bool Status { get; set; }
        public string UID { get; set; }
        public string Login { get; set; }
        public YAccountDisplayName DisplayName { get; set; }
    }

    public class YAccountResponse
    {
        public string DefaultUID { get; set; }
        public List<YAccount> Accounts { get; set; }
        public bool CanAddMore { get; set; }
    }
}