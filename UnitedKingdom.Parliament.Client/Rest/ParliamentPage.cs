using System.Text.Json.Serialization;

namespace UnitedKingdom.Parliament.Rest
{
    public class ParliamentPage<TType>
    {
        [JsonPropertyName("_about")]
        public Uri About { get; set; }
        public Uri Definition { get; set; }
        public Uri ExtendedMetadataVersion { get; set; }
        public Uri First { get; set; }
        public Uri HasPart { get; set; }
        /// <summary>
        /// Can be one of multiple URLs.
        /// </summary>
        public object IsPartOf { get; set; }
        public TType? PrimaryTopic { get; set; }
        public TType[]? Items { get; set; }
        public int ItemsPerPage { get; set; }
        public Uri Next { get; set; }
        public int Page { get; set; }
        public int StartIndex { get; set; }
        public int TotalResults { get; set; }
        /// <summary>
        /// Can be one or multiple URLs.
        /// </summary>
        public object Type { get; set; }
    }
}