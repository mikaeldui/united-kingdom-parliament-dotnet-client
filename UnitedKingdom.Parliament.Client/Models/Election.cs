namespace UnitedKingdom.Parliament;

public class Election : LinkedData
{
    public DateTimeValue Date { get; set; }
    public string ElectionType { get; set; }
    public StringValue Label { get; set; }
}