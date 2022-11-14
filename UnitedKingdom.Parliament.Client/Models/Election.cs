using System.Diagnostics;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

[DebuggerDisplay($"{{{nameof(Label)}}}")]
public class Election : LinkedData
{
    public DateTimeValue Date { get; set; }
    public string ElectionType { get; set; }
    public StringValue Label { get; set; }
}