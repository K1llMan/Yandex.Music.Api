using System.Reflection;

namespace Yandex.Music.Extensions
{
  public static class AssemblyExtensions
  {
    public static string GetDescription(this Assembly assembly)
    {
      return assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;
    }

    public static string GetTitle(this Assembly assembly)
    {
      return assembly.GetCustomAttribute<AssemblyTitleAttribute>()?.Title;
    }

    public static string GetVersion(this Assembly assembly)
    {
      return assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
    }
  }
}