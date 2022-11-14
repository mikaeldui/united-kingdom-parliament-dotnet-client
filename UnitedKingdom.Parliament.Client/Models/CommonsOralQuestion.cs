namespace UnitedKingdom.Parliament
{
    public class CommonsOralQuestion : LinkedData
    {
        public DateTimeValue AnswerDate { get; set; }
        public DateTimeValue AnswerDateTime { get; set; }
        public StringValue[] AnsweringBody { get; set; }
        public CommonsOralQuestionTime CommonsQuestionTime { get; set; }
        public Location Location { get; set; }
        public StringValue QuestionsStatus { get; set; }
        public IntegerValue BallotNumber { get; set; }
        public DateTimeValue DateTabled { get; set; }
        public DateTimeValue Modified { get; set; }
        public string QuestionText { get; set; }
        public Member TablingMember { get; set; }
        public StringValue[] TablingMemberPrinted { get; set; }
        public string Uin { get; set; }
    }
}