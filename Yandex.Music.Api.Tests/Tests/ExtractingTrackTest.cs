using System;
using System.IO;
using System.Linq;
using System.Threading;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Yandex.Music.Api.Responses;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests
{
  [Collection("Yandex Test Harness")]
  public class ExtractingTrackTest : YandexTest
  {
    public const string FolderData = "data";
    public readonly string PathFile;
    public YTrackResponse Track { get; set; }
    
    public ExtractingTrackTest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
    {
      if (!Directory.Exists(FolderData))
        Directory.CreateDirectory(FolderData);
      
//      Api.Authorize(AppSettings.Login, AppSettings.Password);
//      var f = Api.GetListFavorites();
//      Track = Api.GetListFavorites().FirstOrDefault();
//      PathFile = $"{FolderData}/{Track.Title}.mp3";
    }

    [Fact, YandexTrait(TraitGroup.ExtractTrack)]
    public void DownloadTrack_DownloadFile_OneTrack()
    {
//      Api.DownloadTrackToFile(trackIdAndAlbumsId);
        Api.Authorize(AppSettings.Login, AppSettings.Password);

        Track = Api.GetPlaylistFavorites().FirstOrDefault();
        var streamTrack = Api.ExtractStreamTrack(Track.GetKey(), Track.FileSize.Value);

        streamTrack.Complated += (sender, track) =>
        {
            var fileName = $"{Track.Artists.FirstOrDefault().Name} - {Track.Title}";

            streamTrack.SaveToFile(fileName);
        };
        Thread.Sleep(30000);
//      Console.WriteLine("123");

//      isDownloaded.Should().BeTrue();

//      var isFileExist = File.Exists(PathFile);
//      isFileExist.Should().BeTrue();

//      int? fileSize = 0;
//      using (var stream = File.Open(PathFile, FileMode.Open))
//      {
//        var stLength = stream.Length;
//        var buffer = new byte[stLength];
//        stream.Read(buffer, 0, (int) stLength);
//        fileSize = buffer.Length;
//      }

//      fileSize.Should().BeGreaterOrEqualTo(Track.FileSize.Value);

//      File.Delete(PathFile);
    }
    
    [Fact, YandexTrait(TraitGroup.ExtractTrack)]
    public void ExtractingTrack_DownloadFile_OneTrack()
    {
//      var isDownloaded = Api.ExtractTrackToFile(Track, FolderData);
//      isDownloaded.Should().BeTrue();

      var isFileExist = File.Exists(PathFile);
      isFileExist.Should().BeTrue();

      int? fileSize = 0;
      using (var stream = File.Open(PathFile, FileMode.Open))
      {
        var stLength = stream.Length;
        var buffer = new byte[stLength];
        stream.Read(buffer, 0, (int) stLength);
        fileSize = buffer.Length;
      }

      fileSize.Should().BeGreaterOrEqualTo(Track.FileSize.Value);
      
      File.Delete(PathFile);
    }

    [Fact, YandexTrait(TraitGroup.ExtractTrack)]
    public void ExtractingTrack_ExtractByteData_ReturnByteTrack()
    {
//      var byteData = Api.ExtractDataTrack(Track);
//      byteData.Length.Should().BeGreaterOrEqualTo(Track.FileSize.Value);
    }
    
    [Fact, YandexTrait(TraitGroup.ExtractTrack)]
    public void ExtractingTrack_ExtractStream_ReturnStream()
    {
//      var stream = Api.ExtractStreamTrack(Track);
//      var isComplated = false;
//      var fileSizeFromStream = 0;

//      stream.Complated += (sender, track) =>
//      {
//        var stLength = stream.Length;
//        var buffer = new byte[stLength];
//        stream.Read(buffer, 0, (int) stLength);
//        fileSizeFromStream = buffer.Length;


//        isComplated = true;
//      };
      
//      Thread.Sleep(200);
//      stream.Length.Should().NotBe(0);

//      Task.WaitAll(stream.Task);

//      isComplated.Should().BeTrue();
//      fileSizeFromStream.Should().BeGreaterOrEqualTo(Track.FileSize.Value);
    }
  }
}