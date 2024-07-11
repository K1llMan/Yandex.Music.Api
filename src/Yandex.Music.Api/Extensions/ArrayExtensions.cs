namespace Yandex.Music.Api.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] EmptyArray<T>()
        {
#if NETCOREAPP
            return System.Array.Empty<T>();
#else
            return new T[0];
#endif
        }
    }
}
