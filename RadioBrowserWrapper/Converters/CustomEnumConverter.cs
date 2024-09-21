using System;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;
using RadioBrowserWrapper.Enums;

namespace RadioBrowserWrapper.Converters
{
    /// <summary>
    /// Represents an attribute that defines the value of an enum member.
    /// </summary>
    /// <typeparam name="T">Enum type</typeparam>
    public class CustomEnumConverter<T> : JsonConverter<T> where T : Enum
    {
        /// <inheritdoc />
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumType = typeof(T);
            var enumString = reader.GetString();

            foreach (var field in enumType.GetFields())
            {
                var attribute = field.GetCustomAttribute<EnumMemberValueAttribute>();
                if (attribute != null && attribute.Value == enumString)
                {
                    return (T)field.GetValue(null);
                }
            }

            throw new JsonException($"Unable to convert \"{enumString}\" to enum \"{enumType}\".");
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var enumType = typeof(T);
            var field = enumType.GetField(value.ToString());

            var attribute = field.GetCustomAttribute<EnumMemberValueAttribute>();
            if (attribute != null)
            {
                writer.WriteStringValue(attribute.Value);
            }
            else
            {
                // Fall back to the default enum name if no attribute is found
                writer.WriteStringValue(value.ToString());
            }
        }
    }
}
