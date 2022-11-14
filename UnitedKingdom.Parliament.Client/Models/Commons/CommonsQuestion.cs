namespace UnitedKingdom.Parliament;

public abstract class CommonsQuestionBase : LinkedData
{
    public DateTimeValue AnswerDate { get; set; }
    public StringValue[] AnsweringBody { get; set; }
    public string QuestionText { get; set; }
    public DateTimeValue DateTabled { get; set; }
    public Member TablingMember { get; set; }
    public StringValue[] TablingMemberPrinted { get; set; }
    public string Uin { get; set; }
}

public class CommonsOralQuestion : CommonsQuestionBase
{
    public DateTimeValue AnswerDateTime { get; set; }
    public CommonsOralQuestionTime CommonsQuestionTime { get; set; }
    public Location Location { get; set; }
    public StringValue QuestionsStatus { get; set; }
    public IntegerValue BallotNumber { get; set; }
    public DateTimeValue Modified { get; set; }
}

public class CommonsWrittenQuestion : CommonsQuestionBase
{
    public string Title { get; set; }
}