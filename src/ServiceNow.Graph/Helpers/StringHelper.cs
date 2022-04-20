using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;

namespace ServiceNow.Graph.Helpers
{
    /// <summary>
    /// Helper class for string casing.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Converts the type string to title case.
        /// </summary>
        /// <param name="typeString">The type string.</param>
        /// <returns>The converted string.</returns>
        public static string ConvertTypeToTitleCase(string typeString)
        {
            if (string.IsNullOrEmpty(typeString)) return typeString;
            typeString = MapSectionPrefix(typeString);
            var stringSegments = typeString.Split('_').Select(
                segment => string.Concat(segment.Substring(0, 1).ToUpperInvariant(), segment.Substring(1)));
            return string.Join(".", stringSegments);
        }

        /// <summary>
        /// Converts the type string to lower camel case.
        /// </summary>
        /// <param name="typeString">The type string.</param>
        /// <returns>The converted string.</returns>
        public static string ConvertTypeToLowerCamelCase(string typeString)
        {
            if (string.IsNullOrEmpty(typeString)) return typeString;
            typeString = MapSectionPrefix(typeString);
            var stringSegments = typeString.Split('_').Select(
                segment => string.Concat(segment.Substring(0, 1).ToLowerInvariant(), segment.Substring(1)));
            return string.Join(".", stringSegments);
        }

        /// <summary>
        /// Get's the string value of the SecureString
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The string value of the SecureString</returns>
        public static string SecureStringToString(SecureString value)
        {
            var valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        /// <summary>
        /// Converts the identifier string to lower camel case.
        /// </summary>
        /// <param name="identifierString">The identifier string.</param>
        /// <returns>The converted string.</returns>
        public static string ConvertIdentifierToLowerCamelCase(string identifierString)
        {
            if (string.IsNullOrEmpty(identifierString)) return identifierString;
            return string.Concat(identifierString.Substring(0, 1).ToLowerInvariant(), identifierString.Substring(1));
        }

        private static string MapSectionPrefix(string typeString)
        {
            var firstPrefix = Constants.SectionMapping.Keys.FirstOrDefault(typeString.StartsWith);
            if (firstPrefix == null) return typeString;
            var replace = typeString.Replace(firstPrefix, "");
            Constants.SectionMapping.TryGetValue(firstPrefix, out var mapping);
            if (replace.Length == 0) return mapping;
            return string.Concat(mapping,
                string.Concat(replace.Substring(0, 1).ToUpperInvariant(), replace.Substring(1)));
        }
    }
}
