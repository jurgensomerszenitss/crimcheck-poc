using Newtonsoft.Json;
using System;

namespace Grader.Api.Business.Maps
{
    public class JsonUrlConverter : JsonConverter<string>
    {

        public override string ReadJson(JsonReader reader, Type objectType, string existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, string value, JsonSerializer serializer)
        {
            writer.WriteValue($"{Environment.URI}/{value}");
        }
    }
}
