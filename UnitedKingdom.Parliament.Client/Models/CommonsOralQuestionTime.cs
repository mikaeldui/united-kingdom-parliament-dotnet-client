namespace UnitedKingdom.Parliament
{
    public class CommonsOralQuestionTime : LinkedData
    {
        public QuestionTimeAnswerBody[]? AnswerBody { get; set; }
        public DateTimeValue? AnswerDateTime { get; set; }
        public Location? Location { get; set; }
        public StringValue QuestionType { get; set; }
        public DateTimeValue Date { get; set; }
        public DateTimeValue Modified { get; set; }
        public string[] Session { get; set; }
        public StringValue SessionNumber { get; set; }
        public string Title { get; set; }
    }

    public class QuestionTimeAnswerBody : LinkedData
    {
        public string AnswerBodyName { get; set; }
        public string AnswerBodyTarget { get; set; }
    }
}