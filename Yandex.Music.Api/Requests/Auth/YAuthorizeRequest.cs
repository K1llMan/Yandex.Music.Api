using System.Collections.Generic;
using System.Net;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Auth
{
    internal class YAuthorizeRequest : YRequest
    {
        public YAuthorizeRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create()
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "mode", "auth" }
            };

            Dictionary<string, string> body = new Dictionary<string, string> {
                {"login", storage.User.Login },
                {"passwd", storage.User.Password },
                {"twoweeks", "yes"},
                {"retpath", ""}
            };

            FormRequest(YEndpoints.Passport, WebRequestMethods.Http.Post, query, body: GetQueryString(body));

            return this;
        }
    }
}