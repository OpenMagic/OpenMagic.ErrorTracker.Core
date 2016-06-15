using System;
using System.Net.Mime;

namespace OpenMagic.ErrorTracker.Core.Serialization
{
    /// <summary>
    ///     Provides methods for converting between common language runtime types and string types.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        ///     Deserialize a JSON string to a .NET object.
        /// </summary>
        /// <param name="json">
        ///     The JSON string to deserialize.
        /// </param>
        /// <returns>
        ///     The deserialized object from the JSON string.
        /// </returns>
        object FromJson(string json);

        /// <summary>
        ///     Deserializes the JSON to the specified .NET type.
        /// </summary>
        /// <param name="json">
        ///     The JSON string to deserialize.
        /// </param>
        /// <param name="type">
        ///     The <see cref="T:System.Type" /> of object being deserialized.
        /// </param>
        /// <returns>
        ///     The deserialized object from the JSON string.
        /// </returns>
        object FromJson(string json, Type type);

        /// <summary>
        ///     Deserializes the JSON to the specified .NET type.
        /// </summary>
        /// <param name="json">
        ///     The JSON string to deserialize.
        /// </param>
        /// <param name="contentType">
        ///     A content-type header that contains a 'type' parameter of object being deserialized.
        ///     e.g. contentType = "application/json; type=System.Exception"
        /// </param>
        /// <returns>
        ///     The deserialized object from the JSON string.
        /// </returns>
        object FromJson(string json, string contentType);

        /// <summary>
        ///     Deserializes the JSON to the specified .NET type.
        /// </summary>
        /// <param name="json">
        ///     The JSON string to deserialize.
        /// </param>
        /// <param name="contentType">
        ///     A <see cref="ContentType">content-type header</see> that contains a 'type' parameter
        ///     of object being deserialized. e.g. contentType = "application/json; type=System.Exception"
        /// </param>
        /// <returns>
        ///     The deserialized object from the JSON string.
        /// </returns>
        object FromJson(string json, ContentType contentType);

        /// <summary>
        ///     Deserializes a JSON string to the specified .NET type.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the object to deserialize to.
        /// </typeparam>
        /// <param name="json">
        ///     The JSON string to deserialize.
        /// </param>
        /// <returns>
        ///     The deserialized object from the JSON string.
        /// </returns>
        T FromJson<T>(string json);

        /// <summary>
        ///     Serializes the specified object to a JSON string.
        /// </summary>
        /// <param name="value">
        ///     The object to serialize.
        /// </param>
        /// <returns>
        ///     A JSON string representation of the object.
        /// </returns>
        string ToJson(object value);

        /// <summary>
        ///     Serializes the specified object to a JSON string.
        /// </summary>
        /// <param name="value">
        ///     The object to serialize.
        /// </param>
        /// <param name="contentType">
        ///     Reference variable that is updated with a content-type header.
        ///     e.g. "application/json; type=System.Exception"
        /// </param>
        /// <returns>
        ///     A JSON string representation of the object.
        /// </returns>
        string ToJson(object value, out string contentType);
    }
}