namespace Yandex.Music.Api.Common.Debug.Writer
{
    public interface IDebugWriter
    {
        void Error(string message);

        void Clear();

        string SaveResponse(string url, string message);
    }
}