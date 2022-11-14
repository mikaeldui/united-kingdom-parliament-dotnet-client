using System.Diagnostics;
using System.Reflection.Emit;

namespace UnitedKingdom.Parliament;

[DebuggerDisplay($"{{{nameof(PrefLabel)}}}")]
public class Location : LinkedData
{
    public StringValue PrefLabel { get; set; }
}