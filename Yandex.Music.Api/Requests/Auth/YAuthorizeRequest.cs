using System.Collections.Generic;
using System.Net;

namespace Yandex.Music.Api.Requests.Auth
{
    internal class YAuthorizeRequest : YRequest
    {
        public YAuthorizeRequest(HttpContext context) : base(context)
        {
        }
        
        public HttpWebRequest Create(string login, string password)
        {
            return GetRequest("https://pda-passport.yandex.ru/passport?mode=auth",
                new KeyValuePair<string, string>("login", login),
                new KeyValuePair<string, string>("passwd", password),
                new KeyValuePair<string, string>("twoweeks", "yes"),
                new KeyValuePair<string, string>("retpath", ""));
        }
    }
}