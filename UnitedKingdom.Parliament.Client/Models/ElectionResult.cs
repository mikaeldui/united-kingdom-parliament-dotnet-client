using System.Diagnostics;
using System.Reflection.Emit;
using System.Text.Json.Serialization;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

[DebuggerDisplay($"{{{nameof(Election)}.Label}}, {{{nameof(ResultOfElection)}}}")]
public class ElectionResult : LinkedData
{
    [JsonPropertyName("candidate")]
    public CandidateElectionResult[]? Candidates { get; set; }
    public Constituency Constituency { get; set; }
    public Election Election { get; set; }
    public int Electorate { get; set; }
    public int Majority { get; set; }
    public string ResultOfElection { get; set; }
    public int Turnout { get; set; }
}

[DebuggerDisplay($"{{{nameof(FullName)}}}")]
public class CandidateElectionResult : LinkedData
{
    public StringValue FullName { get; set; }
    public int NumberOfVotes { get; set; }
    public int Order { get; set; }
    public StringValue Party { get; set; }
    public double? VoteChangePercent { get; set; }
}