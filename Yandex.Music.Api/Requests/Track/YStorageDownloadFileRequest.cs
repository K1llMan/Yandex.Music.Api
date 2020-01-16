using System.Net;
using System.Text;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YStorageDownloadFileRequest : YRequest
    {
          public YStorageDownloadFileRequest(HttpContext context) : base(context)
          {
          }

          public HttpWebRequest Create(string src, long time, string userLogin)
          {
                var url = $"{src}&format=json&external-domain=music.yandex.ru&overembed=no&__t={time}";

                var request = GetRequest(url, WebRequestMethods.Http.Get);
                request.Headers[HttpRequestHeader.Accept] = "application/json; q=1.0, text/*; q=0.8, */*; q=0.1";
//      request.Headers["Accept-Encoding"] = "gzip, deflate, br";
                request.Headers["Accept-Encoding"] = "utf-8";
                request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
//      request.Headers["access-control-allow-methods"] = "[POST]";
                request.Headers["overembed"] = time.ToString();
                request.Headers["Sec-Fetch-Mode"] = "cors";
//      request.Headers["X-Current-UID"] = userUid;
                request.Headers["X-Requested-With"] = "XMLHttpRequest";
                request.Headers["X-Retpath-Y"] = $"https%3A%2F%2Fmusic.yandex.ru%2Fusers%2F{userLogin}%2Ftracks";
                request.Headers[HttpRequestHeader.AcceptCharset] = Encoding.UTF8.HeaderName;

                request.Headers["origin"] = "https://music.yandex.ru";
                request.Headers["referer"] = $"https://music.yandex.ru/users/{userLogin}/tracks";
                request.Headers["sec-fetch-mode"] = "cors";
                request.Headers["sec-fetch-site"] = "same-site";

                return request;
          }
    }
}