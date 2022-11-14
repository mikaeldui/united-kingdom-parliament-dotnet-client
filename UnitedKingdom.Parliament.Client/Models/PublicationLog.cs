using System.Diagnostics;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

[DebuggerDisplay($"{{{nameof(Label)}}}")]
public class PublicationLog : LinkedData
{
    public StringValue Label { get; set; }
    public StringValue PaperNumber { get; set; }
    public DateTimeValue PublicationDate { get; set; }

    // Extended
    public Legislature[]? Legislature { get; set; }
    public SubType? SubType { get; set; }
}
