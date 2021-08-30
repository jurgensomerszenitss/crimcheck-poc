using Newtonsoft.Json;
using System;

namespace Grader.Api.Business.Maps
{
    public class JsonMediaUrlConverter : JsonConverter<string>
    {

        public override string ReadJson(JsonReader reader, Type objectType, string existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, string value, JsonSerializer serializer)
        {
            if (!string.IsNullOrWhiteSpace(value))
                writer.WriteValue($"{Environment.URI}/media/{value}");
            else
                writer.WriteValue(value);
        }
    }
}
