using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Yandex.Music.Api.Requests
{
    internal class YRequest
    {
        protected HttpContext httpContext;

        public YRequest(HttpContext context)
        {
            httpContext = context;
        }

        #region Вспомогательные функции

        protected string GetQueryString(Dictionary<string, string> query)
        {
            return string.Join("&", query.Select(p => $"{p.Key}={p.Value}"));
        }

        #endregion Вспомогательные функции

        protected virtual HttpWebRequest GetRequest(string url, string method = WebRequestMethods.Http.Get,
            Dictionary<string, string> query = null, string body = null)
        {
            var queryStr = string.Empty;
            if (query != null && query.Count > 0)
                queryStr = "?" + GetQueryString(query);

            var uri = new Uri($"{url}{queryStr}");
            var request = WebRequest.CreateHttp(uri);

            if (httpContext.WebProxy != null)
                request.Proxy = httpContext.WebProxy;

            request.Method = method;
            if (httpContext.Cookies == null)
                httpContext.Cookies = new CookieContainer();

            if (!string.IsNullOrEmpty(body))
                using (var sw = new StreamWriter(request.GetRequestStream(), Encoding.UTF8)) {
                    sw.Write(body);
                }

            request.CookieContainer = httpContext.Cookies;
            request.KeepAlive = true;
            request.Headers[HttpRequestHeader.AcceptCharset] = Encoding.UTF8.WebName;
            request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            return request;
        }

        /*
        protected virtual HttpWebRequest GetRequest(string url, HttpMethod method)
        {
            var uri = new Uri(url);
            var request = WebRequest.CreateHttp(uri);

            if (httpContext.WebProxy != null) request.Proxy = httpContext.WebProxy;

            request.Method = method;
            if (httpContext.Cookies == null) httpContext.Cookies = new CookieContainer();

            request.CookieContainer = httpContext.Cookies;
            request.KeepAlive = true;
            request.Headers[HttpRequestHeader.AcceptCharset] = Encoding.UTF8.WebName;
            request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            return request;
        }*/
    }
}