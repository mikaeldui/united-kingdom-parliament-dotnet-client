using System.Text.Json.Serialization;

namespace UnitedKingdom.Parliament
{
    public abstract class ParliamentPageBase : LinkedData
    {
        public object Definition { get; set; }
        public Uri ExtendedMetadataVersion { get; set; }
    }
    
    public class ParliamentListPage<TType> : ParliamentPageBase
    {
        public TType[]? Items { get; set; }
        public Uri First { get; set; }
        public Uri HasPart { get; set; }
        /// <summary>
        /// Can be one of multiple URLs.
        /// </summary>
        public object IsPartOf { get; set; }
        public int ItemsPerPage { get; set; }
        public Uri Next { get; set; }
        public int Page { get; set; }
        public int StartIndex { get; set; }
        public int TotalResults { get; set; }
    }


    public class ParliamentItemPage<TType> : ParliamentPageBase
    {
        public TType? PrimaryTopic { get; set; }
    }
}