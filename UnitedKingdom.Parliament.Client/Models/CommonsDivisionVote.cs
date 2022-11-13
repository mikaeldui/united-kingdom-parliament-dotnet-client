namespace UnitedKingdom.Parliament
{
    public class CommonsDivisionVote : LinkedData
    {
        public Member[]? Member { get; set; }
        public string MemberParty { get; set; }
        public StringValue MemberGender { get; set; }
        public StringValue MemberPrinted { get; set; }
    }
}