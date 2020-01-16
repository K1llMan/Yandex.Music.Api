using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models;
using Yandex.Music.Api.Requests;
using Yandex.Music.Api.Requests.Auth;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api
{
  public class YandexMusicApi : IYandexMusicApi
  {
    private YandexMusicSettings _settings { get; set; }
    public YUser User { get; set; }
    private HttpContext _httpContext;

    public YandexMusicApi()
    {
      _settings = new YandexMusicSettings();
      _httpContext = new HttpContext();
    }

    public IYandexMusicApi UseWebProxy(IWebProxy proxy)
    {
      _httpContext.WebProxy = proxy;

      return this;
    }

    public YAuthorizeResponse Authorize(string login, string password)
    {
      var request = new YAuthorizeRequest(_httpContext).Create(login, password);

      try
      {
        using (var response = (HttpWebResponse) request.GetResponse())
        {
          _httpContext.Cookies.Add(response.Cookies);

          if (response.ResponseUri == new Uri("https://pda-passport.yandex.ru/passport?mode=auth"))
          {
            return new YAuthorizeResponse
            {
              IsAuthorized = false,
              User = null
            };
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        
        return new YAuthorizeResponse
        {
          IsAuthorized = false,
          User = null
        };
      }

      User = new YUser
      {
        Login = login,
        Password = password
      };

      var authInfo = GetUserAuth();
      var authUserDetails = GetUserAuthDetails();
      var authUser = authUserDetails.User;

      User = new YUser
      {
        Uid = authUser.Uid,
        Login = authUser.Login,
        Password = password,
        Name = authUser.Name,
        Sign = authUser.Sign,
        DeviceId = authUser.DeviceId,
        FirstName = authUser.FirstName,
        LastName = authUser.LastName,
        Experiments = authUserDetails.Experiments,
        Lang = authInfo.Lang,
        Timestamp = authInfo.Timestamp,
        YandexId = authInfo.YandexuId
      };

      return new YAuthorizeResponse
      {
        IsAuthorized = true,
        User = User
      };
    }

    public YAlbumResponse GetAlbum(string albumId)
    {
      var request = GetRequest(_settings.GetAlbumURL(albumId),  WebRequestMethods.Http.Get);
      var album = default(YAlbumResponse);
      
      using (var response = (HttpWebResponse) request.GetResponse())
      {
        var data = GetDataFromResponse(response);
        album = YAlbumResponse.FromJson(data);

        _httpContext.Cookies.Add(response.Cookies);
      }

      return album;
    }
    
    public YTrackResponse GetTrack(string trackId)
    {
      var request = GetRequest(_settings.GetTrackURL(trackId),  WebRequestMethods.Http.Get);
      var track = default(YTrackResponse);
      
      using (var response = (HttpWebResponse) request.GetResponse())
      {
        var data = GetDataFromResponse(response)["track"];
        track = YTrackResponse.FromJson(data);

        _httpContext.Cookies.Add(response.Cookies);
      }

      return track;
    }
    
    public List<YTrackResponse> GetListFavorites(string login = null)
    {
      if (login == null)
        login = User.Login;
      
      var request = GetRequest(_settings.GetListFavoritesURL(login));
      var tracks = new List<YTrackResponse>();
      
      using (var response = (HttpWebResponse) request.GetResponse())
      {
        var data = GetDataFromResponse(response);
        var jTracks = (JArray) data["tracks"];

        tracks = YTrackResponse.FromJsonArray(jTracks);

        _httpContext.Cookies.Add(response.Cookies);
      }

      return tracks;
    }

    public YPlaylistResponse GetPlaylistDejaVu()
    {
      var request = GetRequest(_settings.GetPlaylistDejaVuURL());
      var playlist = default(YPlaylistResponse);
      
      using (var response = (HttpWebResponse) request.GetResponse())
      {
        var data = GetDataFromResponse(response);
        var jPlaylist = data["playlist"];
        playlist = YPlaylistResponse.FromJson(jPlaylist);

        _httpContext.Cookies.Add(response.Cookies);
      }

      return playlist;
    }
    
    public YPlaylistResponse GetPlaylistOfDay()
    {
      var request = GetRequest(_settings.GetPlaylistOfDay());
      var playlist = default(YPlaylistResponse);
      
      using (var response = (HttpWebResponse) request.GetResponse())
      {
        var data = GetDataFromResponse(response);
        var jPlaylist = data["playlist"];
        playlist = YPlaylistResponse.FromJson(jPlaylist);

        _httpContext.Cookies.Add(response.Cookies);
      }

      return playlist;
    }

    public DownloadTrackMainResponse GetMetadataTrackForDownload(string trackKey, Int64 time)
    {
      var url = $"https://music.yandex.ru/api/v2.1/handlers/track/{trackKey}/web-own_tracks-track-track-main/download/m?hq=0&external-domain=music.yandex.ru&overembed=no&__t={time}";
      
      var request = GetRequest(new Uri(url), WebRequestMethods.Http.Get);
      request.Headers[HttpRequestHeader.Accept] = "application/json; q=1.0, text/*; q=0.8, */*; q=0.1";
      request.Headers["Accept-Encoding"] = "gzip, deflate, br";
      request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
//      request.Headers["access-control-allow-methods"] = "[POST]";
      request.Headers["Sec-Fetch-Mode"] = "cors";
      request.Headers["X-Current-UID"] = User.Uid;
      request.Headers["X-Requested-With"] = "XMLHttpRequest";
      request.Headers["X-Retpath-Y"] = $"https%3A%2F%2Fmusic.yandex.ru%2Fusers%2F{User.Login}%2Ftracks";

      request.Headers["origin"] = "https://music.yandex.ru";
      request.Headers["referer"] = $"https://music.yandex.ru/users/{User.Login}/tracks";
      request.Headers["sec-fetch-mode"] = "cors";
      request.Headers["sec-fetch-site"] = "same-site";

      var data = default(JToken);
      
      using (var response = (HttpWebResponse) request.GetResponse())
      {
        data = GetDataFromResponse(response);
        
        _httpContext.Cookies.Add(response.Cookies);
      }

      return new DownloadTrackMainResponse
      {
        Codec = data["codec"].ToObject<string>(),
        Bitrate = data["bitrate"].ToObject<int>(),
        Src = data["src"].ToObject<string>(),
        Gain = data["gain"].ToObject<bool>(),
        Preview = data["preview"].ToObject<bool>(),
      };
    }

    public string BuildLinkForDownloadTrack(DownloadTrackMainResponse mainDownloadResponse, StorageFileDownloadResponse storageDownloadResponse)
    {
      var path = storageDownloadResponse.Path;
      var host = storageDownloadResponse.Host;
      var ts = storageDownloadResponse.Ts;
      var s = storageDownloadResponse.S;
      var codec = mainDownloadResponse.Codec;
      
      var secret = $"XGRlBW9FXlekgbPrRHuSiA{path.Substring(1, path.Length-1)}{s}";
      var md5 = MD5.Create();
      var md5Hash = md5.ComputeHash(Encoding.UTF8.GetBytes(secret));
      var hmacsha1 = new HMACSHA1();
      var hmasha1Hash = hmacsha1.ComputeHash(md5Hash);
      var sign = BitConverter.ToString(hmasha1Hash).Replace("-", "").ToLower();
      
      var link = $"https://{host}/get-{codec}/{sign}/{ts}/{path}";

      return link;
    }

    public StorageFileDownloadResponse GetDownloadFilInfo(DownloadTrackMainResponse metadataInfo, Int64 time)
    {
      var url = $"{metadataInfo.Src}&format=json&external-domain=music.yandex.ru&overembed=no&__t={time}";
      
      var request = GetRequest(new Uri(url), WebRequestMethods.Http.Get);
      request.Headers[HttpRequestHeader.Accept] = "application/json; q=1.0, text/*; q=0.8, */*; q=0.1";
//      request.Headers["Accept-Encoding"] = "gzip, deflate, br";
      request.Headers["Accept-Encoding"] = "utf-8";
      request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
//      request.Headers["access-control-allow-methods"] = "[POST]";
      request.Headers["overembed"] = time.ToString();
      request.Headers["Sec-Fetch-Mode"] = "cors";
//      request.Headers["X-Current-UID"] = userUid;
      request.Headers["X-Requested-With"] = "XMLHttpRequest";
      request.Headers["X-Retpath-Y"] = $"https%3A%2F%2Fmusic.yandex.ru%2Fusers%2F{User.Login}%2Ftracks";
      request.Headers[HttpRequestHeader.AcceptCharset] = Encoding.UTF8.HeaderName;

      request.Headers["origin"] = "https://music.yandex.ru";
      request.Headers["referer"] = $"https://music.yandex.ru/users/{User.Login}/tracks";
      request.Headers["sec-fetch-mode"] = "cors";
      request.Headers["sec-fetch-site"] = "same-site";

      var data = default(JToken);

      using (var response = (HttpWebResponse) request.GetResponse())
      {
        var result = "";

        using (var stream = response.GetResponseStream())
        {
          var reader = new StreamReader(stream);

          result = reader.ReadToEnd();
        }

        data = JToken.Parse(result);

        _httpContext.Cookies.Add(response.Cookies);
      }

      return new StorageFileDownloadResponse
      {
        S = data["s"].ToObject<string>(),
        Ts = data["ts"].ToObject<string>(),
        Path = data["path"].ToObject<string>(),
        Host = data["host"].ToObject<string>(),
      };
    }
    
    public void DownloadTrackToFile(string trackKey, string filePath)
    {
      var time = GetTInterval();
      var mainDownloadResponse = GetMetadataTrackForDownload(trackKey, time);
      var storageDownloadResponse = GetDownloadFilInfo(mainDownloadResponse, time);
      
      var fileLink = BuildLinkForDownloadTrack(mainDownloadResponse, storageDownloadResponse);
      
      try
      {
        using (var client = new WebClient())
        {
          client.DownloadFile(fileLink, filePath);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }

//    public bool ExtractTrackToFile(YandexTrack track, string folder)
//    {
//      try
//      {
//        var trackDonloadInfo = GetDownloadTrackInfo(track.StorageDir);
//        var trackDownloadUrl = _settings.GetURLDownloadTrack(track, trackDonloadInfo);
//        var isNetworing = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        
//        using (var client = new WebClient())
//        {
//          client.DownloadFile(trackDownloadUrl, $"{folder}/{track.Title}.mp3");
//        }

//        return true;
//      }
//      catch (Exception ex)
//      {
//        Console.WriteLine(ex.ToString());
//      }

//      return false;
//    }

//    public YandexStreamTrack ExtractStreamTrack(YandexTrack track)
//    {
//      var trackDonloadInfo = GetDownloadTrackInfo(track.StorageDir);
//      var trackDownloadUrl = _settings.GetURLDownloadTrack(track, trackDonloadInfo);

//      var isNetworing = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

//      return YandexStreamTrack.Open(trackDownloadUrl, track.FileSize);
//    }

//    public byte[] ExtractDataTrack(YandexTrack track)
//    {
//      var trackDonloadInfo = GetDownloadTrackInfo(track.StorageDir);
//      var trackDownloadUrl = _settings.GetURLDownloadTrack(track, trackDonloadInfo);
//      byte[] bytes;
      
//      using (var client = new WebClient())
//      {
//        bytes = client.DownloadData(trackDownloadUrl);
//      }

//      return bytes;
//    }

    public List<YTrackResponse> SearchTrack(string trackName, int pageNumber = 0)
    {
      var tracks = Search(trackName, YandexSearchType.Tracks, pageNumber).Select(x => (YTrackResponse)x).ToList();

      return tracks;
    }

    public List<YArtistResponse> SearchArtist(string artistName, int pageNumber = 0)
    {
      var artists = Search(artistName, YandexSearchType.Artists, pageNumber).Select(x => (YArtistResponse)x).ToList();

      return artists;
    }

    public List<YPlaylistResponse> SearchPlaylist(string playlistName, int pageNumber = 0)
    {
      var playlists = Search(playlistName, YandexSearchType.Playlists, pageNumber).Select(x => (YPlaylistResponse)x).ToList();

      return playlists;
    }

    public List<YAlbumResponse> SearchAlbums(string albumName, int pageNumber = 0)
    {
      var albums = Search(albumName, YandexSearchType.Albums, pageNumber).Select(x => (YAlbumResponse)x).ToList();

      return albums;
    }
    
    public List<YUserResponse> SearchUsers(string userName, int pageNumber = 0)
    {
      var users = Search(userName, YandexSearchType.Users, pageNumber).Select(x => (YUserResponse)x).ToList();

      return users;
    }

    public List<IYandexSearchable> Search(string searchText, YandexSearchType searchType, int page = 0)
    {
      var listResult = new List<IYandexSearchable>();

      var request = GetRequest(_settings.GetSearchURL(searchText, searchType, page), WebRequestMethods.Http.Get);

      using (var response = (HttpWebResponse) request.GetResponse())
      {
        var json = GetDataFromResponse(response);
        var fieldName = searchType.ToString().ToLower();
        var jArray = (JArray) json[fieldName]["items"];
        
        if (searchType == YandexSearchType.Tracks)
        {
          listResult = YTrackResponse.FromJsonArray(jArray).Select(x => (IYandexSearchable) x).ToList();
        } 
        else if (searchType == YandexSearchType.Artists)
        {
          listResult = YArtistResponse.FromJsonArray(jArray).Select(x => (IYandexSearchable) x).ToList();
        }
        else if (searchType == YandexSearchType.Albums)
        {
          listResult = YAlbumResponse.FromJsonArray(jArray).Select(x => (IYandexSearchable) x).ToList();
        }
        else if (searchType == YandexSearchType.Playlists)
        {
          listResult = YPlaylistResponse.FromJsonArray(jArray).Select(x => (IYandexSearchable) x).ToList();
        }
        else if (searchType == YandexSearchType.Users)
        {
          listResult = YUserResponse.FromJsonArray(jArray).Select(x => (IYandexSearchable) x).ToList();
        }
      }

      return listResult;
    }

//    protected YandexTrackDownloadInfo GetDownloadTrackInfo(string storageDir)
//    {
//      var fileName = GetDownloadTrackInfoFileName(storageDir);
//      var request = GetRequest(_settings.GetDownloadTrackInfoURL(storageDir, fileName));
//      var trackDownloadInfo = new YandexTrackDownloadInfo();

//      using (var response = (HttpWebResponse) request.GetResponse())
//      {
//        using (var stream = response.GetResponseStream())
//        {
//          var reader = new StreamReader(stream);
//          var sourceText = reader.ReadToEnd();
          
//          var xElem = XDocument.Parse(sourceText).Root;
//          var elements = new Dictionary<string, string>();
//          for (var x = (XElement) xElem.FirstNode; x != null; x = (XElement) x.NextNode)
//          {
//            elements.Add(x.Name.LocalName, x.Value);
//          }
//          _cookies.Add(response.Cookies);

//          trackDownloadInfo.Host = elements["host"];
//          trackDownloadInfo.Path = elements["path"];
//          trackDownloadInfo.Ts = elements["ts"];
//          trackDownloadInfo.Region = elements["region"];
//          trackDownloadInfo.S = elements["s"];
//        }
//      }

//      return trackDownloadInfo;
//    }

//    protected string GetDownloadTrackInfoFileName(string storageDir)
//    {
//      var url = _settings.GetURLDownloadFile(storageDir);
//      var request = GetRequest(url, WebRequestMethods.Http.Get);
//      var fileName = "";
//      var trackLength = 0;
      
//      using (var response = (HttpWebResponse) request.GetResponse())
//      {
//        using (var stream = response.GetResponseStream())
//        {
//          var reader = new StreamReader(stream);
//          var sourceText = reader.ReadLine();
//          sourceText = reader.ReadLine();

//          var xElem = XDocument.Parse(sourceText).Root;
//          var attrs = xElem.Attributes()
//            .Where(a => !a.IsNamespaceDeclaration)
//            .Select(a => new XAttribute(a.Name.LocalName, a.Value))
//            .ToList();

//          _cookies.Add(response.Cookies);
//          fileName = attrs.First().Value;
//          trackLength = int.Parse(attrs.Last().Value.ToString());
//        }
//      }

//      return fileName;
//    }

    protected JToken GetDataFromResponse(HttpWebResponse response)
    {
      var result = "";

      using (var stream = response.GetResponseStream())
      {
        var reader = new StreamReader(stream);

        result = reader.ReadToEnd();
      }
      
      return JToken.Parse(result);
    }
    
    protected virtual HttpWebRequest GetRequest(Uri uri, string method)
    {
      var request = HttpWebRequest.CreateHttp(uri);
      
      if (_httpContext.WebProxy != null)
      {
        request.Proxy = _httpContext.WebProxy;
      }

      request.Method = method;
      if (_httpContext.Cookies == null)
      {
        _httpContext.Cookies = new CookieContainer();
      }

      request.CookieContainer = _httpContext.Cookies;
      request.KeepAlive = true;
      request.Headers[HttpRequestHeader.AcceptCharset] = Encoding.UTF8.WebName;
      request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";
      request.AutomaticDecompression = DecompressionMethods.GZip;

      return request;
    }

    protected virtual HttpWebRequest GetRequest(Uri uri, params KeyValuePair<string, string>[] headers)
    {
      var request = GetRequest(uri, WebRequestMethods.Http.Post);
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

    public YAccountResponse GetAccounts()
    {
      try
      {
        var uri = new Uri($"https://music.yandex.ru/handlers/accounts.jsx?lang={User.Lang}&external-domain=music.yandex.ru&overembed=false&ncrnd=0.7168345644602356");
        var request = GetRequest(uri);
        var result = "";

        using (var response = (HttpWebResponse) request.GetResponse())
        {
          using (var stream = response.GetResponseStream())
          {
            var reader = new StreamReader(stream);

            result = reader.ReadToEnd();
          }

          _httpContext.Cookies.Add(response.Cookies);
        }

        var json = JToken.Parse(result);
        var account = YAccountResponse.FromJson(json);

        return account;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }

      return null;
    }

    public Int64 GetTInterval()
    {
      DateTime dt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
      DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
      TimeSpan tsInterval = dt.Subtract(dt1970);
      Int64 iMilliseconds = Convert.ToInt64(tsInterval.TotalMilliseconds);

      return iMilliseconds;
    }

    public YLibraryResponse GetLibrary(string ownerUid)
    {
      var url = $"https://music.yandex.ru/handlers/library.jsx?owner={User.Login}&filter=playlists&likeFilter=all&lang={User.Lang}&external-domain=music.yandex.ru&overembed=false&ncrnd=0.17447934315877878";
      
      var request = GetRequest(new Uri(url),WebRequestMethods.Http.Get);
      request.Headers[HttpRequestHeader.Accept] = "application/json, text/javascript, */*; q=0.01";
      request.Headers["Accept-Encoding"] = "gzip, deflate, br";
      request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
      request.Headers["access-control-allow-methods"] = "[POST]";
      request.Headers["Sec-Fetch-Mode"] = "cors";
      request.Headers["X-Current-UID"] = ownerUid;
      request.Headers["X-Requested-With"] = "XMLHttpRequest";
      request.Headers["X-Retpath-Y"] = $"https%3A%2F%2Fmusic.yandex.ru%2Fusers%2F{User.Login}%2Fplaylists";

      request.Headers["origin"] = "https://music.yandex.ru";
      request.Headers["referer"] = $"https://music.yandex.ru/users/{User.Login}/playlists";
      request.Headers["sec-fetch-mode"] = "cors";
      request.Headers["sec-fetch-site"] = "same-site";

      var result = string.Empty;

      using (var response = (HttpWebResponse) request.GetResponse())
      {
        using (var stream = response.GetResponseStream())
        {
          var reader = new StreamReader(stream);

          result = reader.ReadToEnd();
        }

        _httpContext.Cookies.Add(response.Cookies);
      }

      var json = JToken.Parse(result);
      var library = YLibraryResponse.FromJson(json);

      return library;
    }
    
    public YAuthInfoResponse GetUserAuth()
    {
      var request = GetRequest(new Uri($"https://music.yandex.ru/api/v2.1/handlers/auth?external-domain=music.yandex.ru&overembed=no&__t={GetTInterval()}"),
          WebRequestMethods.Http.Get);
      request.Headers[HttpRequestHeader.Accept] = "application/json; q=1.0, text/*; q=0.8, */*; q=0.1";
      request.Headers["Accept-Encoding"] = "gzip, deflate, br";
      request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
      request.Headers["access-control-allow-methods"] = "[POST]";
      request.Headers["Sec-Fetch-Mode"] = "cors";
      request.Headers["X-Requested-With"] = "XMLHttpRequest";
      request.Headers["X-Retpath-Y"] = $"https%3A%2F%2Fmusic.yandex.ru%2Fusers%2F{User.Login}%2Fplaylists";

      request.Headers["origin"] = "https://music.yandex.ru";
      request.Headers["referer"] = $"https://music.yandex.ru/users/{User.Login}/playlists";
      request.Headers["sec-fetch-mode"] = "cors";
      request.Headers["sec-fetch-site"] = "same-site";

      var result = string.Empty;

      using (var response = (HttpWebResponse) request.GetResponse())
      {
        using (var stream = response.GetResponseStream())
        {
          var reader = new StreamReader(stream);

          result = reader.ReadToEnd();
        }

        _httpContext.Cookies.Add(response.Cookies);
      }

      var json = JToken.Parse(result);
      var authInfoResponse = YAuthInfoResponse.FromJson(json);

      return authInfoResponse;
    }

    public YAuthInfoUserResponse GetUserAuthDetails()
    {
      var request = GetRequest(
        new Uri(
          $"https://music.yandex.ru/handlers/auth.jsx?lang={User.Lang}&external-domain=music.yandex.ru&overembed=false&ncrnd=0.1822837925478349"),
        WebRequestMethods.Http.Get);
      request.Headers[HttpRequestHeader.Accept] = "application/json, text/javascript, */*; q=0.01";
      request.Headers["Accept-Encoding"] = "gzip, deflate, br";
      request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
      request.Headers["access-control-allow-methods"] = "[POST]";
      request.Headers["Sec-Fetch-Mode"] = "cors";
      request.Headers["X-Current-UID"] = User.Uid;
      request.Headers["X-Requested-With"] = "XMLHttpRequest";
      request.Headers["X-Retpath-Y"] = $"https%3A%2F%2Fmusic.yandex.ru%2Fusers%2F{User.Login}%2Fplaylists";

      request.Headers["origin"] = "https://music.yandex.ru";
      request.Headers["referer"] = $"https://music.yandex.ru/users/{User.Login}/playlists";
      request.Headers["sec-fetch-mode"] = "cors";
      request.Headers["sec-fetch-site"] = "same-site";

      var result = string.Empty;

      using (var response = (HttpWebResponse) request.GetResponse())
      {
        using (var stream = response.GetResponseStream())
        {
          var reader = new StreamReader(stream);

          result = reader.ReadToEnd();
        }

        _httpContext.Cookies.Add(response.Cookies);
      }

      var json = JToken.Parse(result);
      var authInfoUserResponse = YAuthInfoUserResponse.FromJson(json);

      return authInfoUserResponse;
    }

    public YPlaylistChangeResponse CreatePlaylist(string name)
    {
//      var getCookiet = GetYandexCookie();
//      var auth2 = GetAuthV2();
//      var accounts = GetAccounts();
//      var library = GetLibrary(accounts.DefaultUID);
//      var auth = GetUserAuthDetails(accounts.DefaultUID);

      try
      {
        var uri = new Uri("https://music.yandex.ru/handlers/change-playlist.jsx");
        var request = GetRequest(uri,
          new KeyValuePair<string, string>("action", "add"),
          new KeyValuePair<string, string>("title", name),
          new KeyValuePair<string, string>("lang", "ru"),
          new KeyValuePair<string, string>("sign", User.Sign),
          new KeyValuePair<string, string>("experiments", User.Experiments),
          new KeyValuePair<string, string>("external-domain", "music.yandex.ru"),
          new KeyValuePair<string, string>("overembed", "false")
        );
        request.Headers[HttpRequestHeader.Accept] = "application/json, text/javascript, */*; q=0.01";
        request.Headers["Accept-Encoding"] = "gzip, deflate, br";
        request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
        request.Headers["access-control-allow-methods"] = "[POST]";
        request.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";

        request.Headers["X-Current-UID"] = User.Uid;
        request.Headers["X-Requested-With"] = "XMLHttpRequest";
        request.Headers["X-Retpath-Y"] = $"https%3A%2F%2Fmusic.yandex.ru%2Fusers%2F{User.Login}%2Fplaylists";

        request.Headers["origin"] = "https://music.yandex.ru";
        request.Headers["referer"] = $"https://music.yandex.ru/users/{User.Login}/playlists";
        request.Headers["sec-fetch-mode"] = "cors";
        request.Headers["sec-fetch-site"] = "same-site";

        var result = string.Empty;

        using (var response = (HttpWebResponse) request.GetResponse())
        {
          using (var stream = response.GetResponseStream())
          {
            var reader = new StreamReader(stream);

            result = reader.ReadToEnd();
          }

          _httpContext.Cookies.Add(response.Cookies);
        }

        var json = JToken.Parse(result);
        return YPlaylistChangeResponse.FromJson(json);
      }
      catch (WebException ex)
      {
        Console.WriteLine(ex);
      }

      return new YPlaylistChangeResponse
      {
        Success = false,
        Playlist = null
      };
    }

    public bool RemovePlaylist(long kind)
    {
      try
      {
//        var accounts = GetAccounts();
//        var auth = GetUserAuthDetails(accounts.DefaultUID);

        var uri = new Uri("https://music.yandex.ru/handlers/change-playlist.jsx");
        var request = GetRequest(uri,
          new KeyValuePair<string, string>("action", "delete"),
          new KeyValuePair<string, string>("kind", kind.ToString()),
          new KeyValuePair<string, string>("lang", "ru"),
          new KeyValuePair<string, string>("sign", User.Sign),
          new KeyValuePair<string, string>("experiments", User.Experiments),
          new KeyValuePair<string, string>("external-domain", "music.yandex.ru"),
          new KeyValuePair<string, string>("overembed", "false")
        );
        request.Headers[HttpRequestHeader.Accept] = "application/json, text/javascript, */*; q=0.01";
        request.Headers["Accept-Encoding"] = "gzip, deflate, br";
        request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
        request.Headers["access-control-allow-methods"] = "[POST]";
        request.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";

        request.Headers["X-Current-UID"] = User.Uid;
        request.Headers["X-Requested-With"] = "XMLHttpRequest";
        request.Headers["X-Retpath-Y"] = $"https%3A%2F%2Fmusic.yandex.ru%2Fusers%2F{User.Login}%2Fplaylists";

        request.Headers["origin"] = "https://music.yandex.ru";
        request.Headers["referer"] = $"https://music.yandex.ru/users/{User.Login}/playlists";
        request.Headers["sec-fetch-mode"] = "cors";
        request.Headers["sec-fetch-site"] = "same-site";
        
        request.GetResponse();
        
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }

      return false;
    }

    public YGetCookieResponse GetYandexCookie()
    {
      try
      {
        var request = GetRequest(new Uri("https://matchid.adfox.yandex.ru/getcookie"), WebRequestMethods.Http.Get);
        
//        request.ProtocolVersion = new Version(2, 0);
//        request.Headers.Add(":method", "GET");
//        request.Headers.Add(":authority", "matchid.adfox.yandex.ru");
//        request.Headers.Add(":path", "/getcookie");
//        request.Headers.Add(":scheme", "https");
        
        request.Headers["origin"] = "https://music.yandex.ru";
        request.Headers["referer"] = $"https://music.yandex.ru/users/{User.Login}/playlists";
        request.Headers["sec-fetch-mode"] = "cors";
        request.Headers["sec-fetch-site"] = "same-site";

        var result = "";
        
        using (var response = (HttpWebResponse) request.GetResponse())
        {
          using (var stream = response.GetResponseStream())
          {
            var reader = new StreamReader(stream);

            result = reader.ReadToEnd();
          }

          _httpContext.Cookies.Add(response.Cookies);
        }

        var json = JToken.Parse(result);
        return YGetCookieResponse.FromJson(json);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }

      return null;
    }
  }
}