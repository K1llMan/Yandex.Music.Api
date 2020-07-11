using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests
{
    [Collection("Yandex Test Harness"), Order(0)]
    [TestBeforeAfter]
    public class YAuthStorageTest : YandexTest
    {
        public YAuthStorageTest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }

        private readonly string fileName = "test.tmp";
        private readonly string fileNameCrypto = "testCrypto.tmp";

        [Fact]
        [YandexTrait(TraitGroup.Storage)]
        [Order(1)]
        public void Load_ValidData_True()
        {
            Fixture.Storage.Load(fileName).Should().BeTrue();
        }

        [Fact]
        [YandexTrait(TraitGroup.Storage)]
        [Order(1)]
        public void LoadCrypto_ValidData_True()
        {
            Fixture.Storage.Load(fileNameCrypto).Should().BeTrue();
        }

        [Fact]
        [YandexTrait(TraitGroup.Storage)]
        [Order(0)]
        public void Save_ValidData_True()
        {
            Fixture.Storage.Save(fileName).Should().BeTrue();
        }

        [Fact]
        [YandexTrait(TraitGroup.Storage)]
        [Order(0)]
        public void SaveCrypto_ValidData_True()
        {
            Fixture.Storage.Save(fileNameCrypto).Should().BeTrue();
        }
    }
}