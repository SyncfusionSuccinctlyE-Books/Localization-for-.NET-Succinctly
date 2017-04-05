using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryDevelopers
{
    /// <summary>
    /// A simplified provider for translated strings.
    /// </summary>
    /// <remarks>A real implementation could for instance provide caching.</remarks>
public class LanguageProvider
{
    private static List<ILanguageProvider> _providers = new List<ILanguageProvider>();
    private static ILanguageProvider _default = new StringTableProvider(InternalResources.ResourceManager);

    /// <summary>
    /// Gets the string.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>Localized string if found; otherwise the requested name.</returns>
    public static string GetString(string name)
    {
        var providers = _providers;
        foreach (var provider in providers)
        {
            var str = provider.GetString(name);
            if (str != null)
                return str;

        }

        return _default.GetString(name) ?? name;
    }

    /// <summary>
    /// Register a new provider.
    /// </summary>
    /// <param name="provider"></param>
    public static void Register(ILanguageProvider provider)
    {
        var providers = new List<ILanguageProvider>(_providers) {provider};
        _providers = providers;
    }
}
}
