using System;
using Newtonsoft.Json;

namespace Thingsboard.Net.Flurl.Utilities;

public class GuidNullableConverter : JsonConverter<Guid?>
{
    public override Guid? ReadJson(JsonReader reader, Type objectType, Guid? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null || reader.Value == null)
            return null;

        if (Guid.TryParse(reader.Value.ToString(), out var guid))
            return guid;

        return null;
    }

    public override void WriteJson(JsonWriter writer, Guid? value, JsonSerializer serializer)
    {
        writer.WriteValue(value?.ToString());
    }
}