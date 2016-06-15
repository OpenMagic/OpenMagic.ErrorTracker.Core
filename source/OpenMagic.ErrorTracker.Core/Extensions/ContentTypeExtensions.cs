using System;
using System.Net.Mime;

namespace OpenMagic.ErrorTracker.Core.Extensions
{
    public static class ContentTypeExtensions
    {
        public static string GetTypeParameter(this ContentType contentType)
        {
            return contentType.GetParameter("type");
        }

        public static string GetParameter(this ContentType contentType, string name)
        {
            if (contentType.Parameters == null)
            {
                throw new ArgumentException($"Cannot get parameter '{name}' because there are no parameters.", nameof(name));
            }

            if (contentType.Parameters.ContainsKey(name))
            {
                return contentType.Parameters[name];
            }

            throw new ArgumentException($"Cannot get parameter '{name}' because it is not one of '{string.Join(", ", contentType.Parameters.Keys)}'.", nameof(name));
        }
    }
}