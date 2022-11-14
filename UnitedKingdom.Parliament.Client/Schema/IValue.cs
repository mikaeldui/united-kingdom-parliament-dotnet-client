using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;
using UnitedKingdom.Parliament.Converters;

namespace UnitedKingdom.Parliament;

[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
public interface IValue
{
    [JsonPropertyName("_value")]
    object Value { get; set; }
}

[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
[DebuggerDisplay($"{{{nameof(Value)}}}")]
public abstract class ValueBase<TType> : IValue
{
    [JsonPropertyName("_value")]
    public virtual TType Value { get; set; }

    [JsonPropertyName("_datatype")]
    public string DataType { get; set; }
    object IValue.Value { get => Value; set => Value = (TType)value; }

    public override string ToString() => Value.ToString();
}

[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
public class StringValue : ValueBase<string> { }

[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
public class DateTimeValue : ValueBase<DateTime> { }

[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
public class IntegerValue : ValueBase<int> { }

[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
public class BooleanValue : ValueBase<bool> 
{
    [JsonPropertyName("_value"), JsonConverter(typeof(BoolStringJsonConverter))]
    public bool Value { get; set; }
}

[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
public class UriValue : ValueBase<Uri> { }