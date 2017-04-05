using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;

namespace ClassLibraryDevelopers
{
    /// <summary>
    /// Used to map a string table.
    /// </summary>
    public class StringTableProvider : ILanguageProvider
    {
        private readonly ResourceManager _resourceManager;

        public StringTableProvider(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>String if found; otherwise <c>null</c>.</returns>
        public string GetString(string name)
        {
            return _resourceManager.GetString(name);
        }
    }
}
