namespace UnitedKingdom.Parliament
{
    public class ElectionResult : LinkedData
    {
        public Constituency Constituency { get; set; }
        public Election Election { get; set; }
        public int Electorate { get; set; }
        public int Majority { get; set; }
        public string ResultOfElection { get; set; }
        public int Turnout { get; set; }
    }
}