namespace UnitedKingdom.Parliament.Rest;

internal class ParliamentResponse<TType>
{
    public string Format { get; set; }
    public string Version { get; set; }
    public TType Result { get; set; }
}