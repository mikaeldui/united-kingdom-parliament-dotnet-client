using System.Diagnostics;
using System.Text.Json.Serialization;

namespace UnitedKingdom.Parliament;

[DebuggerDisplay($"{{{nameof(Title)}}}")]
public class CommonsDivision : LinkedData
{
    public DateTimeValue Date { get; set; }
    public string Title { get; set; }
    public string Uin { get; set; }

    // Extended

    public StringValue[]? AbstainCount { get; set; }
    public StringValue[]? AyesCount { get; set; }
    public bool? DeferredVote { get; set; }
    public StringValue[]? DidNotVoteCount { get; set; }
    public StringValue[]? ErrorVoteCount { get; set; }
    public StringValue[]? Margin { get; set; }
    public StringValue[]? NoesVoteCount { get; set; }
    public StringValue[]? NoneligibleCount { get; set; }
    public StringValue[]? SuspendedOrExpelledVotesCount { get; set; }
    public string? DivisionNumber { get; set; }
    public Uri[]? Legislature { get; set; }
    public string[]? Session { get; set; }
    [JsonPropertyName("vote")]
    public CommonsDivisionVote[]? Votes { get; set; }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}