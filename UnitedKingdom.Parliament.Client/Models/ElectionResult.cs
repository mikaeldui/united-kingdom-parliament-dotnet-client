using System.Text.Json.Serialization;

namespace UnitedKingdom.Parliament
{
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

    public class CandidateElectionResult : LinkedData
    {
        public StringValue FullName { get; set; }
        public int NumberOfVotes { get; set; }
        public int Order { get; set; }
        public StringValue Party { get; set; }
        public double? VoteChangePercent { get; set; }
    }
}