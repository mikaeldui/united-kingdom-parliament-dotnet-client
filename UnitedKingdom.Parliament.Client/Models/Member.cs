using System.Diagnostics;
using System.Text.Json.Serialization;
using UnitedKingdom.Parliament.Converters;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

[DebuggerDisplay($"{{{nameof(FullName)}}}")]
public class Member : LinkedData
{
    public StringValue FullName { get; set; }
    public StringValue Label { get; set; }

    // Extended

    public StringValue? AdditionalName { get; set; }
    public Constituency? Constituency { get; set; }
    public StringValue? FamilyName { get; set; }
    public StringValue? Gender { get; set; }
    public StringValue? GivenName { get; set; }
    public Uri? HomePage { get; set; }
    public StringValue? Party { get; set; }
    public UriValue? Twitter { get; set; }

    // Financial Interests
    [JsonPropertyName("hasRegisteredInterest"), JsonConverter(typeof(SingleOrArrayConverter<FinancialInterest[], FinancialInterest>))]
    public FinancialInterest[]? FinancialInterests { get; set; }
}