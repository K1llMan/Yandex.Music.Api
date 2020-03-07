using System.Collections.Generic;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Account
{
    internal class YGetAccountRequest : YRequest
    {
        public YGetAccountRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create()
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "lang", storage.User.Lang },
                { "external-domain", "music.yandex.ru" },
                { "overembed", "false" },
                { "ncrnd", "0.7168345644602356" }
            };

            FormRequest(YEndpoints.Accounts, query: query);

            return this;
        }
    }
}