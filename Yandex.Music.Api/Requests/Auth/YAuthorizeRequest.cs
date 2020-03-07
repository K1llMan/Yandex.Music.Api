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
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "mode", "auth" }
            };

            Dictionary<string, string> body = new Dictionary<string, string> {
                {"login", login},
                {"passwd", password},
                {"twoweeks", "yes"},
                {"retpath", ""}
            };

            return GetRequest(YEndpoints.Passport, WebRequestMethods.Http.Post, query, GetQueryString(body));
        }
    }
}