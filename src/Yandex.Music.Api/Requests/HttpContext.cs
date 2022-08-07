using System;
using System.Net;

namespace Yandex.Music.Api.Requests
{
    public class HttpContext
    {
        public CookieContainer Cookies;

        public HttpContext()
        {
            Cookies = new CookieContainer();
        }

        public IWebProxy WebProxy { get; set; }

        public long GetTimeInterval()
        {
            DateTime dt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
            DateTime dt1970 = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan tsInterval = dt.Subtract(dt1970);
            long iMilliseconds = Convert.ToInt64(tsInterval.TotalMilliseconds);

            return iMilliseconds;
        }
    }
}