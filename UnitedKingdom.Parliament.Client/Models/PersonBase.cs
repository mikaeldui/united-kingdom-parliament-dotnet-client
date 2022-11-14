using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

public abstract class PersonBase : LinkedData
{
    public StringValue? GivenName { get; set; }
    public StringValue? FamilyName { get; set; }
}
