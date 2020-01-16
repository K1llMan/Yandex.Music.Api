using System;
using System.Net;

namespace Yandex.Music.Api.Requests
{
    public class HttpContext
    {
        public CookieContainer Cookies;
        public IWebProxy WebProxy { get; set; }

        public long GetTimeInterval()
        {
            var dt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
            var dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var tsInterval = dt.Subtract(dt1970);
            var iMilliseconds = Convert.ToInt64(tsInterval.TotalMilliseconds);

            return iMilliseconds;
        }
    }
}