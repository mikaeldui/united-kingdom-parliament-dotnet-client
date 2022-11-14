namespace UnitedKingdom.Parliament.Models;

public abstract class QuestionBase : LinkedData
{
    public DateTimeValue AnswerDate { get; set; }
    public StringValue[] AnsweringBody { get; set; }
    public string QuestionText { get; set; }
    public DateTimeValue DateTabled { get; set; }
    public Member TablingMember { get; set; }
    public StringValue[] TablingMemberPrinted { get; set; }
    public string Uin { get; set; }
}
