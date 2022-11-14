using System.Diagnostics;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

[DebuggerDisplay($"{{{nameof(Label)}}}")]
public class Constituency : LinkedData
{
    public StringValue Label { get; set; }
}