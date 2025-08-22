using System;
using System.Linq;
using System.Reflection;

internal static class AssemblyExtensions
{
    public static string? GetVersion(this Assembly assembly)
    {
        var version = GetAssemblyAttribute<AssemblyInformationalVersionAttribute>(assembly);
        return version is null ? null : version.InformationalVersion;
    }
}
