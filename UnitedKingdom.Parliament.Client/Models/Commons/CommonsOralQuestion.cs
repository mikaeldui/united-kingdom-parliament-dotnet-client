using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

public class CommonsOralQuestion : QuestionBase
{
    public DateTimeValue AnswerDateTime { get; set; }
    public CommonsOralQuestionTime CommonsQuestionTime { get; set; }
    public Location Location { get; set; }
    public StringValue QuestionsStatus { get; set; }
    public IntegerValue BallotNumber { get; set; }
    public DateTimeValue Modified { get; set; }
}
