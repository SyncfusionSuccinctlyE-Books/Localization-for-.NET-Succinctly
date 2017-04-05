namespace ClassLibraryDevelopers
{
    /// <summary>
    /// Interface to allow the users to provide their own language providers
    /// </summary>
    public interface ILanguageProvider
    {
        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>String if found; otherwise <c>null</c>.</returns>
        string GetString(string name);
    }
}