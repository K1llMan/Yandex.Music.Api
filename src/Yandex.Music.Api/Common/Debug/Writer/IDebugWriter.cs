using System.Collections.Generic;

namespace Yandex.Music.Api.Common.Debug.Writer
{
    public interface IDebugWriter
    {
        void Error(string requestId, Dictionary<string, List<string>> errors);

        void Clear();

        string SaveResponse(string url, string message);
    }
}
