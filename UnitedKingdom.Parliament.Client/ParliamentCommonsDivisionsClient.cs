using System.ComponentModel;
using System.Reflection;
using System.Text.Json.Serialization;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament
{
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ParliamentCommonsDivisionsClient
    {
        private readonly ParliamentRestClient _restClient;

        internal ParliamentCommonsDivisionsClient(ParliamentRestClient restClient) => _restClient = restClient;

        /// <summary>
        /// All Commons Divisions.
        /// </summary>
        public async Task<ParliamentPage<CommonsDivision>?> GetDivisionsAsync(Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetPageAsync<CommonsDivision>("commonsdivisions", options);
    }

    public class CommonsDivision
    {
        [JsonPropertyName("_about")]
        public Uri About { get; set; }
        public Date Date { get; set; }
        public string Title { get; set; }
        public string Uin { get; set; }
    }

    public class Date
    {
        [JsonPropertyName("_value")]
        public DateTime Value { get; set; }
        [JsonPropertyName("_datatype")]
        public string DataType { get; set; }
    }
}