using System.ComponentModel;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament
{
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ParliamentElectionClient
    {
        private readonly ParliamentRestClient _restClient;

        internal ParliamentElectionClient(ParliamentRestClient restClient) => _restClient = restClient;

        #region Elections

        /// <summary>
        /// Eleciton items.
        /// </summary>
        public async Task<ParliamentListPage<Election>?> GetElectionsAsync(Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetListPageAsync<Election>("elections", options);

        #region Get Election

        /// <summary>
        /// Election by ID.
        /// </summary>
        public async Task<Election?> GetElectionAsync(int id) =>
            await _restClient.GetItemAsync<Election>("elections/" + id);

        /// <summary>
        /// Election by ID.
        /// </summary>
        public async Task<Election?> GetElectionAsync(Election election) =>
            await GetElectionAsync(election.GetId());

        #endregion Get Election

        #endregion Elections

        #region Election Results

        public async Task<ParliamentListPage<ElectionResult>?> GetElectionResultsAsync(Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetListPageAsync<ElectionResult>("electionresults", options);

        #endregion Election Results
    }
}