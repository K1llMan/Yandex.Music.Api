using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Yandex.Music.Api.Common.Providers
{
    /// <summary>
    /// Провайдер запросов данными из файла
    /// </summary>
    public class MockRequestProvider: CommonRequestProvider
    {
        #region Основные функции

        public MockRequestProvider(AuthStorage authStorage): base(authStorage)
        {
            storage = authStorage;
        }

        #endregion Основные функции

        #region IRequestProvider

        public override Task<HttpResponseMessage> GetWebResponseAsync(HttpRequestMessage message)
        {
            throw new NotImplementedException();
        }

        #endregion IRequestProvider
    }
}