namespace UnitedKingdom.Parliament;

public class LordsBillAmendment : LinkedData
{
    public StringValue AmendmentClause { get; set; }
    public LordsBillAmendmentElement[] AmendmentElement { get; set; }
    public StringValue AmendmentPosition { get; set; }
    public StringValue AmendmentType { get; set; }
    public Uri Bill { get; set; }
    public StringValue BillStagePrinted { get; set; }
    public StringValue BkbId { get; set; }
    public StringValue Decision { get; set; }
    public bool IsGovernmentAmendment { get; set; }
    public StringValue Label { get; set; }
    public StringValue LineNumber { get; set; }
    public Member[] Member { get; set; }
    public StringValue NumberingRepresentation { get; set; }
    public StringValue PageNumber { get; set; }
    public int[] Position { get; set; }
    public LordsBillAmendmentSupporter[] Supporters { get; set; }
    public BooleanValue Withdrawn { get; set; }
    public BooleanValue WithdrawnWithoutNotice { get; set; }
}