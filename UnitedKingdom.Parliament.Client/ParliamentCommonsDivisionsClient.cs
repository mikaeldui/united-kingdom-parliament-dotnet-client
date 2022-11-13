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
        public async Task<ParliamentListPage<CommonsDivision>?> GetDivisionsAsync(Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetListPageAsync<CommonsDivision>("commonsdivisions", options);

        /// <summary>
        /// Commons Division by ID.
        /// </summary>
        public async Task<CommonsDivision?> GetDivisionAsync(int id) =>
            await _restClient.GetItemAsync<CommonsDivision>("commonsdivisions/" + id);

        /// <summary>
        /// Commons Division.
        /// </summary>
        public async Task<CommonsDivision?> GetDivisionAsync(CommonsDivision division) =>
            await GetDivisionAsync(division.GetId());

        /// <summary>
        /// Commons Divisions by Session.
        /// </summary>
        public async Task<ParliamentListPage<CommonsDivision>?> GetDivisionsBySessionAsync(string session, Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetListPageAsync<CommonsDivision>("commonsdivisions?session=" + session, options);

        /// <summary>
        /// Commons Divisions by UIN.
        /// </summary>
        public async Task<ParliamentListPage<CommonsDivision>?> GetDivisionsByUinAsync(string uin, Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetListPageAsync<CommonsDivision>("commonsdivisions?uin=" + uin, options);


        /// <summary>
        /// Commons Division Vote by ID.
        /// </summary>
        public async Task<CommonsDivisionVote?> GetDivisionVoteAsync(int divisionId, int voteId) =>
            await _restClient.GetItemAsync<CommonsDivisionVote>($"resources/{divisionId}/vote/{voteId}");
    }
}