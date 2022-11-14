using System.Diagnostics;
using System.Reflection.Emit;

namespace UnitedKingdom.Parliament.Models;

[DebuggerDisplay($"{{{nameof(TablingMember)}.Label}} to {{{nameof(AnsweringBody)}}}: {{{nameof(QuestionText)}}}")]
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
