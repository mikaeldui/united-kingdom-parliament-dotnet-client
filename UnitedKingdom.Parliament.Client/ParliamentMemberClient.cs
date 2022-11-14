using System.ComponentModel;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

/// <summary>
/// Returns all Members' Biographies.
/// </summary>
[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
public class ParliamentMemberClient
{
    private readonly ParliamentRestClient _restClient;

    internal ParliamentMemberClient(ParliamentRestClient restClient) => _restClient = restClient;

    /// <summary>
    /// All Commons Members.
    /// </summary>
    public async Task<ParliamentListPage<Member>?> GetCommonsMembersAsync(Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<Member>("commonsmembers", options);

    /// <summary>
    /// All Lords Members.
    /// </summary>
    public async Task<ParliamentListPage<Member>?> GetLordsMembersAsync(Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<Member>("lordsmembers", options);

    /// <summary>
    /// All Members.
    /// </summary>
    public async Task<ParliamentListPage<Member>?> GetMembersAsync(Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<Member>("members", options);

    #region Get Member

    /// <summary>
    /// Member by ID.
    /// </summary>
    public async Task<Member?> GetMemberAsync(int id) =>
        await _restClient.GetItemAsync<Member>("members/" + id);

    /// <summary>
    /// Member by ID.
    /// </summary>
    public async Task<Member?> GetMemberAsync(Member member) =>
        await GetMemberAsync(member.GetId());

    #endregion 

    #region Get Financial Interests

    /// <summary>
    /// Returns Commons Financial Interests.
    /// </summary>
    public async Task<ParliamentListPage<Member>?> GetCommonsFinancialInterestsAsync(Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<Member>("commonsregisteredinterests", options);

    /// <summary>
    /// Returns Lords Financial Interests.
    /// </summary>
    public async Task<ParliamentListPage<Member>?> GetLordsFinancialInterestsAsync(Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<Member>("lordsregisteredinterests", options);

    #endregion

    #region Get Financial Interests by Member

    /// <summary>
    /// Returns Lords Financial Interests By MemberId.
    /// </summary>
    public async Task<ParliamentListPage<FinancialInterest>?> GetLordsFinancialInterestsByMemberAsync(int memberId, Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<FinancialInterest>("lordsregisteredinterests?member=" + memberId, options);

    /// <summary>
    /// Returns Lords Financial Interests By MemberId.
    /// </summary>
    public async Task<ParliamentListPage<FinancialInterest>?> GetLordsFinancialInterestsByMemberAsync(Member member, Action<ParliamentPageOptions>? options = null) =>
        await GetLordsFinancialInterestsByMemberAsync(member.GetId(), options);

    #endregion
}