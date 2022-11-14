using System.Diagnostics;
using System.Reflection.Emit;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

/// <summary>
/// A.k.a. registered interest.
/// </summary>
[DebuggerDisplay($"{{{nameof(RegisteredInterest)}}}")]
public class FinancialInterest : LinkedData
{
    public DateTimeValue[] AmendedDate { get; set; }
    public DateTimeValue Date { get; set; }
    public StringValue RegisteredInterest { get; set; }
    public StringValue RegisteredInterestCategory { get; set; }
    public BooleanValue RegisteredLate { get; set; }
}