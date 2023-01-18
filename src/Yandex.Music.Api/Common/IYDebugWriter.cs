namespace Yandex.Music.Api.Common
{
    public interface IYDebugWriter
    {
        void Error(string message);

        void Debug(string message);

        void Debug(string fileName, string message);
    }
}