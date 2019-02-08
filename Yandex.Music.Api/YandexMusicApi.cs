using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Extensions;

namespace Yandex.Music
{
  public class YandexMusicApi : YandexApi
  {
    public static string Name => Assembly.GetEntryAssembly().GetName().Name;
    public static string Title => Assembly.GetEntryAssembly().GetTitle();
    public static string Description => Assembly.GetEntryAssembly().GetDescription();
    public static string Version => Assembly.GetEntryAssembly().GetVersion();
    public YandexMusicSettings _settings { get; set; }

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
  }
}