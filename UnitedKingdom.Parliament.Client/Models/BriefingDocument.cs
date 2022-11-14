using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

public class BriefingDocument : LinkedData
{
    public string AttachmentTitle { get; set; }
    public Uri FileUrl { get; set; }
    public string MediaType { get; set; }
    public int[] SizeOfFile { get; set; }
}