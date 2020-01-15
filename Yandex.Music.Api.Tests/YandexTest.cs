using System.IO;
using Newtonsoft.Json.Linq;
using Serilog;
using Serilog.Events;
using Xunit;
using Xunit.Abstractions;

namespace Yandex.Music.Api.Tests
{
  [CollectionDefinition("Yandex Test Harness")]
  public class YandexTestCollection : ICollectionFixture<YandexTestHarness>
  {
  }

  public class YandexTest 
  {
    public AppSettings AppSettings { get; set; }
    public YandexApi Api { get; set; }
    public YandexTestHarness Fixture { get; set; }

    public YandexTest(YandexTestHarness fixture, ITestOutputHelper output = null)
    {
      Fixture = fixture;

      Api = new YandexMusicApi();
      
      if (output != null)
      {
        Log.Logger = new LoggerConfiguration()
          .WriteTo
          .TestOutput(output, LogEventLevel.Verbose)
          .CreateLogger();
      }

      AppSettings = GetAppSettings();
    }

    private AppSettings GetAppSettings()
    {
      var fileSource = string.Empty;
      
      using (var stream = new FileStream("appsettings.json", FileMode.Open))
      {
        using (var reader = new StreamReader(stream))
        {
          fileSource = reader.ReadToEnd();
        }
      }

      var json = JToken.Parse(fileSource);

      return new AppSettings
      {
        Login = json["login"].ToObject<string>(),
        Password = json["password"].ToObject<string>()
      };
    }
  }
}
