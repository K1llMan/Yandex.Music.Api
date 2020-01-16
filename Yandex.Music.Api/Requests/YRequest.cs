using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;

namespace Yandex.Music.Api.Requests
{
  internal class YRequest
  {
    protected HttpContext HttpContext;
    
    public YRequest(HttpContext context)
    {
      HttpContext = context;
    }
    protected virtual HttpWebRequest GetRequest(string url, string method)
    {
      var uri = new Uri(url);
      var request = HttpWebRequest.CreateHttp(uri);

      if (HttpContext.WebProxy != null)
      {
        request.Proxy = HttpContext.WebProxy;
      }

      request.Method = method;
      if (HttpContext.Cookies == null)
      {
        HttpContext.Cookies = new CookieContainer();
      }

      request.CookieContainer = HttpContext.Cookies;
      request.KeepAlive = true;
      request.Headers[HttpRequestHeader.AcceptCharset] = Encoding.UTF8.WebName;
      request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";
      request.AutomaticDecompression = DecompressionMethods.GZip;

      return request;
    }

    protected virtual HttpWebRequest GetRequest(string url, params KeyValuePair<string, string>[] headers)
    {
      var request = GetRequest(url, WebRequestMethods.Http.Post);
      var data = new StringBuilder(1024);

      for (var i = 0; i < headers.Length - 1; i++)
      {
        data.AppendFormat("{0}={1}&",
          HttpUtility.HtmlEncode(headers[i].Key),
          HttpUtility.HtmlEncode(headers[i].Value));
      }

      if (headers.Length > 0)
      {
        data.AppendFormat("{0}={1}",
          HttpUtility.HtmlEncode(headers[headers.Length - 1].Key),
          HttpUtility.HtmlEncode(headers[headers.Length - 1].Value));
      }

      var rawData = Encoding.UTF8.GetBytes(data.ToString());
      request.ContentLength = rawData.Length;
      request.GetRequestStream().Write(rawData, 0, rawData.Length);

      return request;
    }
  }
}