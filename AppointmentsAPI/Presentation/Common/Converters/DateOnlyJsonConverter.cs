﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace ServicesAPI.Common.Converters;

public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    private readonly string _format = "dd.MM.yyyy";

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.ParseExact(reader.GetString(), _format);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_format));
    }
}