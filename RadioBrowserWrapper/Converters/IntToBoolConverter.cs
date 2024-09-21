using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Converters
{
    /// <summary>
    /// Represents a converter for converting an integer to a boolean.
    /// </summary>
    internal class IntToBoolConverter : JsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
                return reader.GetInt32() == 1;

            return false;
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value ? 1 : 0);
        }
    }
}
