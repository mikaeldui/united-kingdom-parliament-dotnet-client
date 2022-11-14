using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace UnitedKingdom.Parliament.Converters;

public class SingleOrArrayConverter<TItem> : SingleOrArrayConverter<List<TItem>, TItem>
{
    public SingleOrArrayConverter() : this(true) { }
    public SingleOrArrayConverter(bool canWrite) : base(canWrite) { }
}

public class SingleOrArrayConverterFactory : JsonConverterFactory
{
    public bool CanWrite { get; }

    public SingleOrArrayConverterFactory() : this(true) { }

    public SingleOrArrayConverterFactory(bool canWrite) => CanWrite = canWrite;

    public override bool CanConvert(Type typeToConvert)
    {
        var itemType = GetItemType(typeToConvert);
        if (itemType == null)
            return false;
        if (itemType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(itemType))
            return false;
        if (typeToConvert.GetConstructor(Type.EmptyTypes) == null || typeToConvert.IsValueType)
            return false;
        return true;
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var itemType = GetItemType(typeToConvert);
        var converterType = typeof(SingleOrArrayConverter<,>).MakeGenericType(typeToConvert, itemType);
        return (JsonConverter)Activator.CreateInstance(converterType, new object[] { CanWrite });
    }

    static Type GetItemType(Type type)
    {
        // Quick reject for performance
        if (type.IsPrimitive || type == typeof(string))
            return null;
        while (type != null)
        {
            if (type.IsGenericType)
            {
                var genType = type.GetGenericTypeDefinition();
                if (genType == typeof(List<>))
                    return type.GetGenericArguments()[0];
                if (type.IsArray)
                    return type.GetElementType();
                // Add here other generic collection types as required, e.g. HashSet<> or ObservableCollection<> or etc.
            }
            type = type.BaseType;
        }
        return null;
    }
}

public class SingleOrArrayConverter<TCollection, TItem> : JsonConverter<TCollection> where TCollection : class, ICollection<TItem>
{
    public SingleOrArrayConverter() : this(true) { }
    public SingleOrArrayConverter(bool canWrite) => CanWrite = canWrite;

    public bool CanWrite { get; }

    public override TCollection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.StartArray:
                var list = typeToConvert.IsArray ? (ICollection<TItem>) new List<TItem>() : Activator.CreateInstance<TCollection>();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndArray)
                        break;
                    list.Add(JsonSerializer.Deserialize<TItem>(ref reader, options));
                }
                return (TCollection)(typeToConvert.IsArray ? (ICollection<TItem>) list.ToArray() : (TCollection) list);
            default:
                {
                    if (typeToConvert.IsArray)
                    {
                        return (TCollection) (ICollection<TItem>) new TItem[] { JsonSerializer.Deserialize<TItem>(ref reader, options) };
                    }
                    else
                    {
                        var collection = Activator.CreateInstance<TCollection>();
                        collection.Add(JsonSerializer.Deserialize<TItem>(ref reader, options));
                        return collection;
                    }
                }
        }
    }

    public override void Write(Utf8JsonWriter writer, TCollection value, JsonSerializerOptions options)
    {
        if (CanWrite && value.Count == 1)
        {
            JsonSerializer.Serialize(writer, value.First(), options);
        }
        else
        {
            writer.WriteStartArray();
            foreach (var item in value)
                JsonSerializer.Serialize(writer, item, options);
            writer.WriteEndArray();
        }
    }
}