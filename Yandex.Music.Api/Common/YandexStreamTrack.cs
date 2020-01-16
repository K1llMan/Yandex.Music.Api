using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Yandex.Music.Api.Common
{
  public class YandexStreamTrack : MemoryStream
  {
    public Uri Url { get; set; }
    public int? TrackSize { get; set; }
    public event EventHandler<YandexStreamTrack> Complated;
    public Task Task { get; set; }
    
    private YandexStreamTrack()
    {
    }

    private void OnComplated()
    {
      Complated?.Invoke(null, this);
    }

    public void SaveToFile(string fileName)
    {
      using (var stream = new FileStream($"{fileName}.mp3", FileMode.Create))
      {
        var length = Length;
        var data = new byte[length];
        Read(data, 0, data.Length);
        stream.Write(data, 0, data.Length);
      }

      Close();
    }

    public static YandexStreamTrack Open(Uri trackUrl, int? sizeTrack)
    {
      var streamTrack = new YandexStreamTrack
      {
        Position = 0,
        TrackSize = sizeTrack,
        Url = trackUrl
      };
      
      streamTrack.Task = Task.Factory.StartNew(() =>
      {
        var response = HttpWebRequest.Create(trackUrl).GetResponse();
        using (var stream = response.GetResponseStream())
        {
          byte[] buffer = new byte[sizeTrack ?? 0];
          int read;
          while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
          {
            var pos = streamTrack.Position;
            streamTrack.Position = streamTrack.Length;
            streamTrack.Write(buffer, 0, read);
            streamTrack.Position = pos;

          }
          streamTrack.OnComplated();
        }
      });

      return streamTrack;
    }
  }
}