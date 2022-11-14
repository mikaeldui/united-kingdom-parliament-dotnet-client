using System.ComponentModel;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

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

    /// <summary>
    /// Election Result items.
    /// </summary>
    public async Task<ParliamentListPage<ElectionResult>?> GetElectionResultsAsync(Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<ElectionResult>("electionresults", options);

    #region Get Election Result by ID

    /// <summary>
    /// Election Result by ID.
    /// </summary>
    public async Task<ElectionResult?> GetElectionResultAsync(int electionResultId) =>
        await _restClient.GetItemAsync<ElectionResult>("electionresults/" + electionResultId);

    /// <summary>
    /// Election Result by ID.
    /// </summary>
    public async Task<ElectionResult?> GetElectionResultAsync(ElectionResult electionResult) =>
        await GetElectionResultAsync(electionResult.GetId());

    #endregion

    #region Election Results by Election

    /// <summary>
    /// Election Result items.
    /// </summary>
    public async Task<ParliamentListPage<ElectionResult>?> GetElectionResultsByElectionAsync(int electionId, Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<ElectionResult>("electionresults?electionId=" + electionId, options);

    /// <summary>
    /// Election Result items.
    /// </summary>
    public async Task<ParliamentListPage<ElectionResult>?> GetElectionResultsByElectionAsync(Election election, Action<ParliamentPageOptions>? options = null) =>
        await GetElectionResultsByElectionAsync(election.GetId(), options);

    #endregion

    #region Election Results by Constituency

    /// <summary>
    /// Election Results by Constituency.
    /// </summary>
    public async Task<ParliamentListPage<ElectionResult>?> GetElectionResultsByConstituencyAsync(int constituencyId, Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<ElectionResult>("electionresults?constituencyId=" + constituencyId, options);

    /// <summary>
    /// Election Results by Constituency.
    /// </summary>
    public async Task<ParliamentListPage<ElectionResult>?> GetElectionResultsByConstituencyAsync(Constituency constituency, Action<ParliamentPageOptions>? options = null) =>
        await GetElectionResultsByConstituencyAsync(constituency.GetId(), options);

    #endregion

    #region Candidate Election Result

    /// <summary>
    /// Candidate Election Result by ID.
    /// </summary>
    /// <param name="candidateId">Can be <see cref="CandidateElectionResult.Order"/>.</param>
    public async Task<CandidateElectionResult?> GetCandidateElectionResultAsync(int electionResultId, int candidateId) =>
        await _restClient.GetItemAsync<CandidateElectionResult>($"resources/{electionResultId}/candidates/{candidateId}");

    /// <summary>
    /// Candidate Election Result by ID.
    /// </summary>
    public async Task<CandidateElectionResult?> GetCandidateElectionResultAsync(ElectionResult electionResult, int candidateId) =>
        await GetCandidateElectionResultAsync(electionResult.GetId(), candidateId);

    /// <summary>
    /// Candidate Election Result by ID.
    /// </summary>
    public async Task<CandidateElectionResult?> GetCandidateElectionResultAsync(ElectionResult electionResult, CandidateElectionResult candidateElectionResult) =>
        await GetCandidateElectionResultAsync(electionResult.GetId(), candidateElectionResult.GetId());

    /// <summary>
    /// Candidate Election Result by ID.
    /// </summary>
    public async Task<CandidateElectionResult?> GetCandidateElectionResultAsync(int electionResultId, CandidateElectionResult candidateElectionResult) =>
        await GetCandidateElectionResultAsync(electionResultId, candidateElectionResult.GetId());

    #endregion

    #endregion Election Results
}