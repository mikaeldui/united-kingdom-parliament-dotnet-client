using System.ComponentModel;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

/// <summary>
/// Returns all Lords Bill Amendments.
/// </summary>
[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
public class ParliamentLordsWrittenQuestionsClient
{
    private readonly ParliamentRestClient _restClient;

    internal ParliamentLordsWrittenQuestionsClient(ParliamentRestClient restClient) => _restClient = restClient;

    /// <summary>
    /// All Lords Written Questions.
    /// </summary>
    public async Task<ParliamentListPage<LordsWrittenQuestion>?> GetQuestionsAsync(Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<LordsWrittenQuestion>("lordswrittenquestions", options);

    #region Get By Answering Body

    /// <summary>
    /// All Lords Written Questions By Answering Body.
    /// </summary>
    public async Task<ParliamentListPage<LordsWrittenQuestion>?> GetQuestionsByAnsweringBodyAsync(string query, Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<LordsWrittenQuestion>("lordswrittenquestions/answeringdepartment?q=" + query, options);

    /// <summary>
    /// All Lords Written Questions By Answering Body.
    /// </summary>
    public async Task<ParliamentListPage<LordsWrittenQuestion>?> GetQuestionsByAnsweringBodyAsync(LordsWrittenQuestion questionWithAnsweringBody, Action<ParliamentPageOptions>? options = null) =>
        await GetQuestionsByAnsweringBodyAsync(questionWithAnsweringBody.AnsweringBody.First().Value, options);

    #endregion

    #region Get By Member

    /// <summary>
    /// All Lords Written Questions By Member.
    /// </summary>
    public async Task<ParliamentListPage<LordsWrittenQuestion>?> GetQuestionsByMemberAsync(int mnisId, Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<LordsWrittenQuestion>("lordswrittenquestions?mnisId=" + mnisId, options);

    /// <summary>
    /// All Lords Written Questions By Member.
    /// </summary>
    public async Task<ParliamentListPage<LordsWrittenQuestion>?> GetQuestionsByMemberAsync(Member member, Action<ParliamentPageOptions>? options = null) =>
        await GetQuestionsByMemberAsync(member.GetId(), options);

    #endregion

    #region Get By Session

    /// <summary>
    /// All Lords Written Questions By Session.
    /// </summary>
    public async Task<ParliamentListPage<LordsWrittenQuestion>?> GetQuestionsBySessionAsync(string session, Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<LordsWrittenQuestion>("lordswrittenquestions?session=" + session, options);

    #endregion

    #region Get By Table Date

    /// <summary>
    /// All Lords Written Questions By Table Date.
    /// </summary>
    public async Task<ParliamentListPage<LordsWrittenQuestion>?> GetQuestionsByTableDateAsync(DateTime startDate, DateTime endDate, Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<LordsWrittenQuestion>($"lordswrittenquestions/tabled?startDate={startDate:s}&endDate={endDate:s}", options);

    #endregion

    #region Get By UIN

    /// <summary>
    /// All Lords Written Questions By UIN.
    /// </summary>
    public async Task<ParliamentListPage<LordsWrittenQuestion>?> GetQuestionsByUinAsync(string uin, Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<LordsWrittenQuestion>("lordswrittenquestions?uin=" + uin, options);

    /// <summary>
    /// All Lords Written Questions By UIN.
    /// </summary>
    public async Task<ParliamentListPage<LordsWrittenQuestion>?> GetQuestionsByUinAsync(LordsWrittenQuestion questionWithUin, Action<ParliamentPageOptions>? options = null) =>
        await GetQuestionsByUinAsync(questionWithUin.Uin, options);

    #endregion

    #region Get Question

    /// <summary>
    /// Lords Written Questions By ID.
    /// </summary>
    public async Task<LordsWrittenQuestion?> GetQuestionAsync(int id) =>
        await _restClient.GetItemAsync<LordsWrittenQuestion>("lordswrittenquestions/" + id);

    /// <summary>
    /// Lords Written Questions By ID.
    /// </summary>
    public async Task<LordsWrittenQuestion?> GetQuestionAsync(LordsWrittenQuestion question) =>
        await GetQuestionAsync(question.GetId());

    #endregion 
}