using System.ComponentModel;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

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

    #region Get Division Vote

    /// <summary>
    /// Commons Division Vote by ID.
    /// </summary>
    public async Task<CommonsDivisionVote?> GetDivisionVoteAsync(int divisionId, int voteId) =>
        await _restClient.GetItemAsync<CommonsDivisionVote>($"resources/{divisionId}/vote/{voteId}");

    /// <summary>
    /// Commons Division Vote by ID.
    /// </summary>
    public async Task<CommonsDivisionVote?> GetDivisionVoteAsync(CommonsDivision division, int voteId) =>
        await _restClient.GetItemAsync<CommonsDivisionVote>($"resources/{division.GetId()}/vote/{voteId}");

    /// <summary>
    /// Commons Division Vote by ID.
    /// </summary>
    public async Task<CommonsDivisionVote?> GetDivisionVoteAsync(CommonsDivision division, CommonsDivisionVote vote) =>
        await _restClient.GetItemAsync<CommonsDivisionVote>($"resources/{division.GetId()}/vote/{vote.GetId()}");
    
    /// <summary>
    /// Commons Division Vote by ID.
    /// </summary>
    public async Task<CommonsDivisionVote?> GetDivisionVoteAsync(int divisionId, CommonsDivisionVote vote) =>
        await _restClient.GetItemAsync<CommonsDivisionVote>($"resources/{divisionId}/vote/{vote.GetId()}");

    #endregion Get Division Vote

    #region Get Divisions where Member voted No

    /// <summary>
    /// Commons Divisions where Member voted No
    /// </summary>
    public async Task<ParliamentListPage<CommonsDivision>?> GetDivisionsWhereMemberVotedNoAsync(int mnisId, Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<CommonsDivision>("commonsdivisions/no?mnisId=" + mnisId, options);

    /// <summary>
    /// Commons Divisions where Member voted No
    /// </summary>
    public async Task<ParliamentListPage<CommonsDivision>?> GetDivisionsWhereMemberVotedNoAsync(Member member, Action<ParliamentPageOptions>? options = null) =>
        await GetDivisionsWhereMemberVotedNoAsync(member.GetId(), options);

    #endregion Get Divisions where Member voted No

    #region Get Divisions where Member voted Aye

    /// <summary>
    /// Commons Divisions where Member voted Aye
    /// </summary>
    public async Task<ParliamentListPage<CommonsDivision>?> GetDivisionsWhereMemberVotedAyeAsync(int mnisId, Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<CommonsDivision>("commonsdivisions/aye?mnisId=" + mnisId, options);

    /// <summary>
    /// Commons Divisions where Member voted Aye
    /// </summary>
    public async Task<ParliamentListPage<CommonsDivision>?> GetDivisionsWhereMemberVotedAyeAsync(Member member, Action<ParliamentPageOptions>? options = null) =>
        await GetDivisionsWhereMemberVotedAyeAsync(member.GetId(), options);

    #endregion Get Divisions where Member voted Ate
}