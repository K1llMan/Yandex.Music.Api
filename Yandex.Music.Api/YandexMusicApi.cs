using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models;

namespace Yandex.Music.Api
{
  public class YandexMusicApi : YandexApi
  {
    private YandexMusicSettings _settings { get; set; }
    private string _login;
    private string _password;
    private CookieContainer _cookies;
    
    public IWebProxy WebProxy { get; set; }

    public YandexMusicApi()
    {
      _settings = new YandexMusicSettings();
    }

    public YandexApi UseWebProxy(IWebProxy proxy)
    {
      WebProxy = proxy;

      return this;
    }

    public bool Authorize(string login, string password)
    {
      _login = login;
      _password = password;
      
      var result = false;
      var _passportUri = _settings.GetPassportURL();
      
      var request = GetRequest(_passportUri,
        new KeyValuePair<string, string>("login", _login),
        new KeyValuePair<string, string>("passwd", _password),
        new KeyValuePair<string, string>("twoweeks", "yes"),
        new KeyValuePair<string, string>("retpath", ""));

      try
      {
        using (var response = (HttpWebResponse) request.GetResponse())
        {
          _cookies.Add(response.Cookies);
          result = true;

          if (response.ResponseUri == _passportUri)
          {
            result = false;
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        result = false;
      }

      return result;
    }

    public YandexAlbum GetAlbum(string albumId)
    {
      var request = GetRequest(_settings.GetAlbumURL(albumId),  WebRequestMethods.Http.Get);
      var album = default(YandexAlbum);
      
      using (var response = (HttpWebResponse) request.GetResponse())
      {
        var data = GetDataFromResponse(response);
        album = YandexAlbum.FromJson(data);

        _cookies.Add(response.Cookies);
      }

      return album;
    }
    
    public YandexTrack GetTrack(string trackId)
    {
      var request = GetRequest(_settings.GetTrackURL(trackId),  WebRequestMethods.Http.Get);
      var track = default(YandexTrack);
      
      using (var response = (HttpWebResponse) request.GetResponse())
      {
        var data = GetDataFromResponse(response)["track"];
        track = YandexTrack.FromJson(data);

        _cookies.Add(response.Cookies);
      }

      return track;
    }
    
    public List<YandexTrack> GetListFavorites(string login = null)
    {
      if (login == null)
        login = _login;
      
      var request = GetRequest(_settings.GetListFavoritesURL(login));
      var tracks = new List<YandexTrack>();
      
      using (var response = (HttpWebResponse) request.GetResponse())
      {
        var data = GetDataFromResponse(response);
        var jTracks = (JArray) data["tracks"];

        tracks = YandexTrack.FromJsonArray(jTracks);

        _cookies.Add(response.Cookies);
      }

      return tracks;
    }

    public YandexPlaylist GetPlaylistDejaVu()
    {
      var request = GetRequest(_settings.GetPlaylistDejaVuURL());
      var playlist = default(YandexPlaylist);
      
      using (var response = (HttpWebResponse) request.GetResponse())
      {
        var data = GetDataFromResponse(response);
        var jPlaylist = data["playlist"];
        playlist = YandexPlaylist.FromJson(jPlaylist);

        _cookies.Add(response.Cookies);
      }

      return playlist;
    }
    
    public YandexPlaylist GetPlaylistOfDay()
    {
      var request = GetRequest(_settings.GetPlaylistOfDay());
      var playlist = default(YandexPlaylist);
      
      using (var response = (HttpWebResponse) request.GetResponse())
      {
        var data = GetDataFromResponse(response);
        var jPlaylist = data["playlist"];
        playlist = YandexPlaylist.FromJson(jPlaylist);

        _cookies.Add(response.Cookies);
      }

      return playlist;
    }

    public bool ExtractTrackToFile(YandexTrack track, string folder)
    {
      try
      {
        var trackDonloadInfo = GetDownloadTrackInfo(track.StorageDir);
        var trackDownloadUrl = _settings.GetURLDownloadTrack(track, trackDonloadInfo);
        var isNetworing = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        
        using (var client = new WebClient())
        {
          client.DownloadFile(trackDownloadUrl, $"{folder}/{track.Title}.mp3");
        }

        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }

      return false;
    }

    public YandexStreamTrack ExtractStreamTrack(YandexTrack track)
    {
      var trackDonloadInfo = GetDownloadTrackInfo(track.StorageDir);
      var trackDownloadUrl = _settings.GetURLDownloadTrack(track, trackDonloadInfo);

      var isNetworing = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

      return YandexStreamTrack.Open(trackDownloadUrl, track.FileSize);
    }

    public byte[] ExtractDataTrack(YandexTrack track)
    {
      var trackDonloadInfo = GetDownloadTrackInfo(track.StorageDir);
      var trackDownloadUrl = _settings.GetURLDownloadTrack(track, trackDonloadInfo);
      byte[] bytes;
      
      using (var client = new WebClient())
      {
        bytes = client.DownloadData(trackDownloadUrl);
      }

      return bytes;
    }

    public List<YandexTrack> SearchTrack(string trackName, int pageNumber = 0)
    {
      var tracks = Search(trackName, YandexSearchType.Tracks, pageNumber).Select(x => (YandexTrack)x).ToList();

      return tracks;
    }

    public List<YandexArtist> SearchArtist(string artistName, int pageNumber = 0)
    {
      var artists = Search(artistName, YandexSearchType.Artists, pageNumber).Select(x => (YandexArtist)x).ToList();

      return artists;
    }

    public List<YandexPlaylist> SearchPlaylist(string playlistName, int pageNumber = 0)
    {
      var playlists = Search(playlistName, YandexSearchType.Playlists, pageNumber).Select(x => (YandexPlaylist)x).ToList();

      return playlists;
    }

    public List<YandexAlbum> SearchAlbums(string albumName, int pageNumber = 0)
    {
      var albums = Search(albumName, YandexSearchType.Albums, pageNumber).Select(x => (YandexAlbum)x).ToList();

      return albums;
    }
    
    public List<YandexUser> SearchUsers(string userName, int pageNumber = 0)
    {
      var users = Search(userName, YandexSearchType.Users, pageNumber).Select(x => (YandexUser)x).ToList();

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
          listResult = YandexTrack.FromJsonArray(jArray).Select(x => (IYandexSearchable) x).ToList();
        } 
        else if (searchType == YandexSearchType.Artists)
        {
          listResult = YandexArtist.FromJsonArray(jArray).Select(x => (IYandexSearchable) x).ToList();
        }
        else if (searchType == YandexSearchType.Albums)
        {
          listResult = YandexAlbum.FromJsonArray(jArray).Select(x => (IYandexSearchable) x).ToList();
        }
        else if (searchType == YandexSearchType.Playlists)
        {
          listResult = YandexPlaylist.FromJsonArray(jArray).Select(x => (IYandexSearchable) x).ToList();
        }
        else if (searchType == YandexSearchType.Users)
        {
          listResult = YandexUser.FromJsonArray(jArray).Select(x => (IYandexSearchable) x).ToList();
        }
      }

      return listResult;
    }

    protected YandexTrackDownloadInfo GetDownloadTrackInfo(string storageDir)
    {
      var fileName = GetDownloadTrackInfoFileName(storageDir);
      var request = GetRequest(_settings.GetDownloadTrackInfoURL(storageDir, fileName));
      var trackDownloadInfo = new YandexTrackDownloadInfo();

      using (var response = (HttpWebResponse) request.GetResponse())
      {
        using (var stream = response.GetResponseStream())
        {
          var reader = new StreamReader(stream);
          var sourceText = reader.ReadToEnd();
          
          var xElem = XDocument.Parse(sourceText).Root;
          var elements = new Dictionary<string, string>();
          for (var x = (XElement) xElem.FirstNode; x != null; x = (XElement) x.NextNode)
          {
            elements.Add(x.Name.LocalName, x.Value);
          }
          _cookies.Add(response.Cookies);

          trackDownloadInfo.Host = elements["host"];
          trackDownloadInfo.Path = elements["path"];
          trackDownloadInfo.Ts = elements["ts"];
          trackDownloadInfo.Region = elements["region"];
          trackDownloadInfo.S = elements["s"];
        }
      }

      return trackDownloadInfo;
    }

    protected string GetDownloadTrackInfoFileName(string storageDir)
    {
      var request = GetRequest(_settings.GetURLDownloadFile(storageDir), WebRequestMethods.Http.Get);
      var fileName = "";
      var trackLength = 0;
      
      using (var response = (HttpWebResponse) request.GetResponse())
      {
        using (var stream = response.GetResponseStream())
        {
          var reader = new StreamReader(stream);
          var sourceText = reader.ReadLine();
          sourceText = reader.ReadLine();

          var xElem = XDocument.Parse(sourceText).Root;
          var attrs = xElem.Attributes()
            .Where(a => !a.IsNamespaceDeclaration)
            .Select(a => new XAttribute(a.Name.LocalName, a.Value))
            .ToList();

          _cookies.Add(response.Cookies);
          fileName = attrs.First().Value;
          trackLength = int.Parse(attrs.Last().Value.ToString());
        }
      }

      return fileName;
    }

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
      
      if (WebProxy != null)
      {
        request.Proxy = WebProxy;
      }

      request.Method = method;
      if (_cookies == null)
      {
        _cookies = new CookieContainer();
      }

      request.CookieContainer = _cookies;
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

    public YandexAccountResult GetAccounts()
    {
      try
      {
        var uri = new Uri("https://music.yandex.ru/handlers/accounts.jsx?lang=ru&external-domain=music.yandex.ru&overembed=false&ncrnd=0.7168345644602356");
        var request = GetRequest(uri);
        var result = "";

        using (var response = (HttpWebResponse) request.GetResponse())
        {
          using (var stream = response.GetResponseStream())
          {
            var reader = new StreamReader(stream);

            result = reader.ReadToEnd();
          }

          _cookies.Add(response.Cookies);
        }

        var json = JToken.Parse(result);
        var yandexAccounts = new YandexAccountResult
        {
          DefaultUID = json["default_uid"].ToObject<string>(),
          Accounts = json["accounts"].Select(x => new YandexAccount
          {
            Status = x["status"].ToObject<bool>(),
            UID = x["uid"].ToObject<string>(),
            Login = x["login"].ToObject<string>(),
            DisplayName = new YandexAccount.YandexAccountDisplayName
            {
              Name = x["displayName"]["name"].ToObject<string>(),
              DefaultAvatar = x["displayName"]["default_avatar"].ToObject<string>()
            }
          }).ToList(),
          CanAddMore = json["can-add-more"].ToObject<bool>()
        };

        return yandexAccounts;
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

    public YandexGetLibraryResult GetLibrary(string ownerUid)
    {
      var url = $"https://music.yandex.ru/handlers/library.jsx?owner=Winster332&filter=playlists&likeFilter=all&lang=ru&external-domain=music.yandex.ru&overembed=false&ncrnd=0.17447934315877878";
      
      var request = GetRequest(new Uri(url),WebRequestMethods.Http.Get);
      request.Headers[HttpRequestHeader.Accept] = "application/json, text/javascript, */*; q=0.01";
      request.Headers["Accept-Encoding"] = "gzip, deflate, br";
      request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
      request.Headers["access-control-allow-methods"] = "[POST]";
      request.Headers["Sec-Fetch-Mode"] = "cors";
      request.Headers["X-Current-UID"] = ownerUid;
      request.Headers["X-Requested-With"] = "XMLHttpRequest";
      request.Headers["X-Retpath-Y"] = "https%3A%2F%2Fmusic.yandex.ru%2Fusers%2FWinster332%2Fplaylists";

      request.Headers["origin"] = "https://music.yandex.ru";
      request.Headers["referer"] = "https://music.yandex.ru/users/Winster332/playlists";
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

        _cookies.Add(response.Cookies);
      }

      var json = JToken.Parse(result);

      var playlists = new List<YandexGetLibraryResult.YandexLibraryPlaylist>();
      
      foreach (var x in json["playlists"])
      {
        var playlistOwner = new YandexOwner
        {
          Uid = x["owner"]["uid"].ToObject<string>(),
          Login = x["owner"]["login"].ToObject<string>(),
          Name = x["owner"]["name"].ToObject<string>(),
          Sex = x["owner"]["sex"]?.ToObject<string>(),
          Verified = x["owner"]["verified"]?.ToObject<bool>()
        };

        var tracks = x.SelectToken("tracks")?.Select(f =>
          new YandexGetLibraryResult.YandexLibraryPlaylist.YandexLibraryPlaylistTrack
          {
            Id = f["id"]?.ToObject<long?>(),
            Timestamp = f["timestamp"]?.ToObject<string>(),
            AlbumId = f["albumId"]?.ToObject<long?>()
          }).ToList();

        var libraryCover = default(YandexGetLibraryResult.YandexLibraryPlaylist.YandexLibraryPlaylistCover);
        
        if (x.SelectToken("cover")?.SelectToken("type").ToObject<string>() == "mosaic")
        {
          libraryCover = new YandexGetLibraryResult.YandexLibraryPlaylist.YandexLibraryPlaylistCoverMosaic
          {
            Type = x["cover"]["type"].ToObject<string>(),
            ItemsUri = x["cover"]["itemsUri"].Select(f => f.ToObject<string>()).ToList(),
            Custom = x["cover"]["custom"].ToObject<bool>()
          };
        } else if (x.SelectToken("cover")?.SelectToken("type").ToObject<string>() == "pic")
        {
          libraryCover = new YandexGetLibraryResult.YandexLibraryPlaylist.YandexLibraryPlaylistCoverPic
          {
            Type = x["cover"]["type"].ToObject<string>(),
            Dir = x["cover"]["dir"].ToObject<string>(),
            Version = x["cover"]["version"].ToObject<string>(),
            Uri = x["cover"]["uri"].ToObject<string>(),
            Custom = x["cover"]["custom"].ToObject<bool>()
          };
        }

        var playlist = new YandexGetLibraryResult.YandexLibraryPlaylist
        {
          Owner = playlistOwner,
          Available = x["available"]?.ToObject<bool>(),
          Uid = x["uid"]?.ToObject<long>(),
          Kind = x["kind"]?.ToObject<long>(),
          Title = x["title"]?.ToObject<string>(),
          Revision = x["revision"]?.ToObject<long>(),
          Snapshot = x["snapshot"]?.ToObject<long>(),
          TrackCount = x["trackCount"]?.ToObject<long>(),
          Visibility = x["visibility"]?.ToObject<string>(),
          Collective = x["collective"]?.ToObject<bool>(),
          Created = x["created"]?.ToObject<string>(),
          Modified = x["modified"]?.ToObject<string>(),
          IsBanner = x["isBanner"]?.ToObject<bool>(),
          IsPremiere = x["isPremiere"]?.ToObject<bool>(),
          DurationMs = x["durationMs"]?.ToObject<long>(),
          Cover = libraryCover,
          OgImage = x["ogImage"]?.ToObject<string>(),
          Tracks = tracks,
          Tags = x["tags"]?.ToString(),
          Prerolls = x["prerolls"]?.ToString(),
        };
        playlists.Add(playlist);
      }

      var libraryOwner = new YandexOwner
      {
        Uid = json["owner"]["uid"].ToObject<string>(),
        Login = json["owner"]["login"].ToObject<string>(),
        Name = json["owner"]["name"].ToObject<string>(),
        Sex = string.Empty,
        Verified = null
      };

      var profiles = json["profiles"].Select(x => new YandexGetLibraryResult.YandexLibraryProfile
      {
        Provider = x["provider"].ToObject<string>(),
        Addresses = x["addresses"].Select(f => f.ToObject<string>()).ToList()
      }).ToList();

      var counts = new YandexGetLibraryResult.YandexLibraryCounter
      {
        LikedArtists = json["counts"]["likedArtists"].ToObject<long>(),
        LikedAlbums = json["counts"]["likedAlbums"].ToObject<long>(),
      };
      
      return new YandexGetLibraryResult
      {
        Success               = json["success"].ToObject<bool>(),
        BookmarksPlaylistsIds = json["bookmarksPlaylistsIds"].ToString(),
        Bookmarks             = json["bookmarks"].ToString(),
        PlaylistIds           = json["playlistIds"].Select(x => x.ToObject<long>()).ToList(),
        Playlists             = playlists,
        Verified              = json["verified"].ToObject<bool>(),
        Owner                 = libraryOwner,
        Visibility            = json["visibility"].ToObject<bool>(),
        Profiles              = profiles,
        Counts                = counts,
        HasTracks             = json["hasTracks"].ToObject<bool>(),
        IsRadioAvailable      = json["isRadioAvailable"].ToObject<bool>()
      };
    }
    
    public YandexAuthV2Result GetAuthV2()
    {
      var request = GetRequest(new Uri($"https://music.yandex.ru/api/v2.1/handlers/auth?external-domain=music.yandex.ru&overembed=no&__t={GetTInterval()}"),
          WebRequestMethods.Http.Get);
      request.Headers[HttpRequestHeader.Accept] = "application/json; q=1.0, text/*; q=0.8, */*; q=0.1";
      request.Headers["Accept-Encoding"] = "gzip, deflate, br";
      request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
      request.Headers["access-control-allow-methods"] = "[POST]";
      request.Headers["Sec-Fetch-Mode"] = "cors";
      request.Headers["X-Requested-With"] = "XMLHttpRequest";
      request.Headers["X-Retpath-Y"] = "https%3A%2F%2Fmusic.yandex.ru%2Fusers%2FWinster332%2Fplaylists";

      request.Headers["origin"] = "https://music.yandex.ru";
      request.Headers["referer"] = "https://music.yandex.ru/users/Winster332/playlists";
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

        _cookies.Add(response.Cookies);
      }

      var json = JToken.Parse(result);

      return new YandexAuthV2Result
      {
        Csrf = json["csrf"].ToObject<string>(),
        FreshCsrf = json["freshCsrf"].ToObject<string>(),
        Uid = json["uid"].ToObject<string>(),
        Login = json["login"].ToObject<string>(),
        YandexuId = json["yandexuid"].ToObject<string>(),
        Logged = json["logged"].ToObject<bool>(),
        Premium = json["premium"].ToObject<bool>(),
        Lang = json["lang"].ToObject<string>(),
        Timestamp = json["timestamp"].ToObject<long>(),
        Experements = json["experiments"].ToString(),
        BadRegion = json["badRegion"].ToObject<bool>(),
        NotFree = json["notFree"].ToObject<bool>(),
        DeviceId = json["device_id"].ToObject<string>()
      };
    }

    public YandexAuthResult GetAuth(string ownerUid)
    {
      var request = GetRequest(
        new Uri(
          $"https://music.yandex.ru/handlers/auth.jsx?lang=ru&external-domain=music.yandex.ru&overembed=false&ncrnd=0.1822837925478349"),
        WebRequestMethods.Http.Get);
      request.Headers[HttpRequestHeader.Accept] = "application/json, text/javascript, */*; q=0.01";
      request.Headers["Accept-Encoding"] = "gzip, deflate, br";
      request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
      request.Headers["access-control-allow-methods"] = "[POST]";
      request.Headers["Sec-Fetch-Mode"] = "cors";
      request.Headers["X-Current-UID"] = ownerUid;
      request.Headers["X-Requested-With"] = "XMLHttpRequest";
      request.Headers["X-Retpath-Y"] = "https%3A%2F%2Fmusic.yandex.ru%2Fusers%2FWinster332%2Fplaylists";

      request.Headers["origin"] = "https://music.yandex.ru";
      request.Headers["referer"] = "https://music.yandex.ru/users/Winster332/playlists";
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

        _cookies.Add(response.Cookies);
      }

      var json = JToken.Parse(result);

      var authUserPlus = new YandexAuthResult.YandexAuthUser.YandexAuthPlus
      {
        HasPlus = json["user"]["plus"]["hasPlus"].ToObject<bool>(),
        IsTutorialCompleted = json["user"]["plus"]["isTutorialCompleted"].ToObject<bool>(),
        Migrated = json["user"]["plus"]["migrated"].ToObject<bool>()
      };
      var authUserSubscription = new YandexAuthResult.YandexAuthUser.YandexAuthSubscription
      {
        NonAutoRenewable = new YandexAuthResult.YandexAuthUser.YandexAuthSubscriptionNonAutoRenewable
        {
          Start = json["user"]["subscription"]["nonAutoRenewable"]["start"].ToObject<string>(),
          End = json["user"]["subscription"]["nonAutoRenewable"]["end"].ToObject<string>()
        },
        CanStartTrial = json["user"]["subscription"]["canStartTrial"].ToObject<bool>(),
        Mcdonalds = json["user"]["subscription"]["mcdonalds"].ToObject<bool>()
      };
      var authUserSettings = new YandexAuthResult.YandexAuthUser.YandexAuthSettings
      {
        Uid = json["user"]["settings"]["uid"].ToObject<string>(),
        LastFmScrobblingEnabled = json["user"]["settings"]["lastFmScrobblingEnabled"].ToObject<bool>(),
        FacebookScrobblingEnabled = json["user"]["settings"]["facebookScrobblingEnabled"].ToObject<bool>(),
        ShuffleEnabled = json["user"]["settings"]["shuffleEnabled"].ToObject<bool>(),
        AddNewTrackOnPlaylistTop = json["user"]["settings"]["addNewTrackOnPlaylistTop"].ToObject<bool>(),
        VolumePercents = json["user"]["settings"]["volumePercents"].ToObject<int>(),
        UserMusicVisibility = json["user"]["settings"]["userMusicVisibility"].ToObject<string>(),
        UserSocialVisibility = json["user"]["settings"]["userSocialVisibility"].ToObject<string>(),
        AdsDisabled = json["user"]["settings"]["adsDisabled"].ToObject<bool>(),
        Modified = json["user"]["settings"]["modified"].ToObject<string>(),
        RbtDisabled = json["user"]["settings"]["rbtDisabled"].ToObject<bool>(),
        Theme = json["user"]["settings"]["theme"].ToObject<string>(),
        PromosDisabled = json["user"]["settings"]["promosDisabled"].ToObject<bool>(),
        AutoPlayRadio = json["user"]["settings"]["autoPlayRadio"].ToObject<bool>(),
      };

      var authUser = new YandexAuthResult.YandexAuthUser
      {
        Sign = json["user"]["sign"].ToObject<string>(),
        Sk = json["user"]["sk"].ToObject<string>(),
        Premium = json["user"]["premium"].ToObject<bool>(),
        Plus = authUserPlus,
        SubeditorLevel = json["user"]["subeditorLevel"].ToObject<int>(),
        Subeditor = json["user"]["subeditor"].ToObject<bool>(),
        IsMobileUser = json["user"]["isMobileUser"].ToObject<bool>(),
        Subscription = authUserSubscription,
        AdDisableable = json["user"]["adDisableable"].ToObject<bool>(),
        IsPremium = json["user"]["isPremium"].ToObject<bool>(),
        _statusFetched = json["user"]["_statusFetched"].ToObject<bool>(),
        DeviceId = json["user"]["device_id"].ToObject<string>(),
        OnlyDeviceId = json["user"]["onlyDeviceId"].ToObject<bool>(),
        KpOttSubscription = json["user"]["kpOttSubscription"].ToObject<string>(),
        HavePlus = json["user"]["havePlus"].ToObject<bool>(),
        HasAvatar = json["user"]["hasAvatar"].ToObject<bool>(),
        SignUpMethod = json["user"]["signUpMethod"].ToObject<string>(),
        IsHosted = json["user"]["isHosted"].ToObject<bool>(),
        IsYandex = json["user"]["isYandex"].ToObject<bool>(),
        ContactPhone = json["user"]["contactPhone"].ToObject<string>(),
        LastName = json["user"]["lastName"].ToObject<string>(),
        FirstName = json["user"]["firstName"].ToObject<string>(),
        Name = json["user"]["name"].ToObject<string>(),
        Login = json["user"]["login"].ToObject<string>(),
        Uid = json["user"]["uid"].ToObject<string>(),
        Settings = authUserSettings,
        HasEmail = json["user"]["hasEmail"].ToObject<bool>(),

      };

      return new YandexAuthResult
      {
        User = authUser,
        Experiments = json["experiments"].ToObject<string>()
      };
    }

    public YandexChangePlaylistResult CreatePlaylist(string name)
    {
//      var getCookiet = GetYandexCookie();
//      var auth2 = GetAuthV2();
      var accounts = GetAccounts();
//      var library = GetLibrary(accounts.DefaultUID);
      var auth = GetAuth(accounts.DefaultUID);

      try
      {
        var uri = new Uri("https://music.yandex.ru/handlers/change-playlist.jsx");
        var request = GetRequest(uri,
          new KeyValuePair<string, string>("action", "add"),
          new KeyValuePair<string, string>("title", name),
          new KeyValuePair<string, string>("lang", "ru"),
          new KeyValuePair<string, string>("sign", auth.User.Sign),
          new KeyValuePair<string, string>("experiments", auth.Experiments),
          new KeyValuePair<string, string>("external-domain", "music.yandex.ru"),
          new KeyValuePair<string, string>("overembed", "false")
        );
        request.Headers[HttpRequestHeader.Accept] = "application/json, text/javascript, */*; q=0.01";
        request.Headers["Accept-Encoding"] = "gzip, deflate, br";
        request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
        request.Headers["access-control-allow-methods"] = "[POST]";
        request.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";

        request.Headers["X-Current-UID"] = accounts.DefaultUID;
        request.Headers["X-Requested-With"] = "XMLHttpRequest";
        request.Headers["X-Retpath-Y"] = "https%3A%2F%2Fmusic.yandex.ru%2Fusers%2FWinster332%2Fplaylists";

        request.Headers["origin"] = "https://music.yandex.ru";
        request.Headers["referer"] = "https://music.yandex.ru/users/Winster332/playlists";
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

          _cookies.Add(response.Cookies);
        }

        var json = JToken.Parse(result);
        var x = json["playlist"];
        
        var playlistOwner = new YandexOwner
        {
          Uid = x["owner"]["uid"].ToObject<string>(),
          Login = x["owner"]["login"].ToObject<string>(),
          Name = x["owner"]["name"].ToObject<string>(),
          Sex = x["owner"]["sex"]?.ToObject<string>(),
          Verified = x["owner"]["verified"]?.ToObject<bool>()
        };

        var tracks = x.SelectToken("tracks")?.Select(f =>
          new YandexGetLibraryResult.YandexLibraryPlaylist.YandexLibraryPlaylistTrack
          {
            Id = f["id"]?.ToObject<long?>(),
            Timestamp = f["timestamp"]?.ToObject<string>(),
            AlbumId = f["albumId"]?.ToObject<long?>()
          }).ToList();

        var libraryCover = default(YandexGetLibraryResult.YandexLibraryPlaylist.YandexLibraryPlaylistCover);

        if (x.SelectToken("cover")?.SelectToken("error") != null)
        {
          libraryCover = new YandexGetLibraryResult.YandexLibraryPlaylist.YandexLibraryPlaylistCoverError
          {
            Error = x["cover"]["error"].ToObject<string>()
          };
        } else if (x.SelectToken("cover")?.SelectToken("type").ToObject<string>() == "mosaic")
        {
          libraryCover = new YandexGetLibraryResult.YandexLibraryPlaylist.YandexLibraryPlaylistCoverMosaic
          {
            Type = x["cover"]["type"].ToObject<string>(),
            ItemsUri = x["cover"]["itemsUri"].Select(f => f.ToObject<string>()).ToList(),
            Custom = x["cover"]["custom"].ToObject<bool>()
          };
        } else if (x.SelectToken("cover")?.SelectToken("type").ToObject<string>() == "pic")
        {
          libraryCover = new YandexGetLibraryResult.YandexLibraryPlaylist.YandexLibraryPlaylistCoverPic
          {
            Type = x["cover"]["type"].ToObject<string>(),
            Dir = x["cover"]["dir"].ToObject<string>(),
            Version = x["cover"]["version"].ToObject<string>(),
            Uri = x["cover"]["uri"].ToObject<string>(),
            Custom = x["cover"]["custom"].ToObject<bool>()
          };
        }
        
        
        var playlist = new YandexGetLibraryResult.YandexLibraryPlaylist
        {
          Owner = playlistOwner,
          Available = x["available"]?.ToObject<bool>(),
          Uid = x["uid"]?.ToObject<long>(),
          Kind = x["kind"]?.ToObject<long>(),
          Title = x["title"]?.ToObject<string>(),
          Revision = x["revision"]?.ToObject<long>(),
          Snapshot = x["snapshot"]?.ToObject<long>(),
          TrackCount = x["trackCount"]?.ToObject<long>(),
          Visibility = x["visibility"]?.ToObject<string>(),
          Collective = x["collective"]?.ToObject<bool>(),
          Created = x["created"]?.ToObject<string>(),
          Modified = x["modified"]?.ToObject<string>(),
          IsBanner = x["isBanner"]?.ToObject<bool>(),
          IsPremiere = x["isPremiere"]?.ToObject<bool>(),
          DurationMs = x["durationMs"]?.ToObject<long>(),
          Cover = libraryCover,
          OgImage = x["ogImage"]?.ToObject<string>(),
          Tracks = tracks,
          Tags = x["tags"]?.ToString(),
          Prerolls = x["prerolls"]?.ToString(),
        };

        return new YandexChangePlaylistResult
        {
          Success = json["success"].ToObject<bool>(),
          Playlist = playlist
        };
      }
      catch (WebException ex)
      {
        using (var stream = ex.Response.GetResponseStream())
        {
          var reader = new StreamReader(stream);

          var result = reader.ReadToEnd();
        }

        Console.WriteLine(ex);
      }

      return new YandexChangePlaylistResult
      {
        Success = false,
        Playlist = null
      };
    }

    public YandexGetCookieResult GetYandexCookie()
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
        request.Headers["referer"] = "https://music.yandex.ru/users/Winster332/playlists";
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

          _cookies.Add(response.Cookies);
        }

        var json = JToken.Parse(result);

        return new YandexGetCookieResult
        {
          CryptoId = json["cryptouid"].ToObject<string>(),
          CryptoSign = json["cryptouid_sign"].ToObject<string>()
        };
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }

      return null;
    }
  }
}