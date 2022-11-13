using System.ComponentModel;
using System.Text.Json.Serialization;

namespace UnitedKingdom.Parliament
{
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public interface IValue
    {
        [JsonPropertyName("_value")]
        object Value { get; set; }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class StringValue : IValue
    {
        [JsonPropertyName("_value")]
        public string Value { get; set; }
        object IValue.Value { get => Value; set => Value = (string)value; }
    }

    public class DateTimeValue : IValue
    {
        [JsonPropertyName("_value")]
        public DateTime Value { get; set; }
        [JsonPropertyName("_datatype")]
        public string DataType { get; set; }
        object IValue.Value { get => Value; set => Value = (DateTime)value; }
    }
}