using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UnitedKingdom.Parliament.Converters
{
    internal class ValueJsonConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (typeToConvert == typeof(string)) return true;
            if (typeToConvert == typeof(DateTime)) return true;
            if (typeToConvert == typeof(int)) return true;
            if (typeToConvert == typeof(bool)) return true;
            if (typeToConvert == typeof(Uri)) return true;
            return false;
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
