using Serilog;
using Serilog.Events;
using Xunit;
using Xunit.Abstractions;
using Yandex.Music;

namespace Lofty.Modules.BddTests
{
  [CollectionDefinition("Lofi Test Harness")]
  public class LofiTestCollection : ICollectionFixture<LofiTestHarness>
  {
  }

  public class LofiTest 
  {
    public YandexApi Api { get; set; }
    public LofiTestHarness Fixture { get; set; }

    public LofiTest(LofiTestHarness fixture, ITestOutputHelper output = null)
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
    }
  }
}
