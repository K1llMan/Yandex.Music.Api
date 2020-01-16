using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Responses
{
    public class YAccountResponse
    {
        public string DefaultUID { get; set; }
        public List<YandexAccount> Accounts { get; set; }
        public bool CanAddMore { get; set; }

        public static YAccountResponse FromJson(JToken json)
        {
            var yandexAccounts = new YAccountResponse
            {
                DefaultUID = json["default_uid"].ToObject<string>(),
                Accounts = json["accounts"].Select(x => new YAccountResponse.YandexAccount
                {
                    Status = x["status"].ToObject<bool>(),
                    UID = x["uid"].ToObject<string>(),
                    Login = x["login"].ToObject<string>(),
                    DisplayName = new YAccountResponse.YandexAccount.YandexAccountDisplayName
                    {
                        Name = x["displayName"]["name"].ToObject<string>(),
                        DefaultAvatar = x["displayName"]["default_avatar"].ToObject<string>()
                    }
                }).ToList(),
                CanAddMore = json["can-add-more"].ToObject<bool>()
            };

            return yandexAccounts;
        }

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
    }
}
