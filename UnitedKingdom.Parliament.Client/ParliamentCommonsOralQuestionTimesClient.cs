using System.ComponentModel;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
public class ParliamentCommonsOralQuestionTimesClient
{
    private readonly ParliamentRestClient _restClient;

    internal ParliamentCommonsOralQuestionTimesClient(ParliamentRestClient restClient) => _restClient = restClient;

    /// <summary>
    /// All Commons Oral Questions Times.
    /// </summary>
    public async Task<ParliamentListPage<CommonsOralQuestionTime>?> GetTimesAsync(Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<CommonsOralQuestionTime>("commonsoralquestiontimes", options);

    #region Get Times By Session

    /// <summary>
    /// All Commons Oral Questions Times By Session.
    /// </summary>
    public async Task<ParliamentListPage<CommonsOralQuestionTime>?> GetTimesBySessionAsync(string session, Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<CommonsOralQuestionTime>("commonsoralquestiontimes?session=" + session, options);

    /// <summary>
    /// All Commons Oral Questions Times By Session.
    /// </summary>
    public async Task<ParliamentListPage<CommonsOralQuestionTime>?> GetTimesBySessionAsync(CommonsOralQuestionTime timeWithSession, Action<ParliamentPageOptions>? options = null) =>
        await GetTimesBySessionAsync(timeWithSession.Session.First(), options);

    #endregion Get Times By Session

    #region Get Time

    /// <summary>
    /// Commons Oral Questions Time by ID.
    /// </summary>
    public async Task<CommonsOralQuestionTime?> GetTimeAsync(int timeId) =>
        await _restClient.GetItemAsync<CommonsOralQuestionTime>("commonsoralquestiontimes/" + timeId);

    /// <summary>
    /// Commons Oral Questions Time by ID.
    /// </summary>
    public async Task<CommonsOralQuestionTime?> GetTimeAsync(CommonsOralQuestionTime time) =>
        await GetTimeAsync(time.GetId());

    #endregion Get Time

    #region Get Time Answering Body

    /// <summary>
    /// Commons Oral Questions Time Answering Body by ID.
    /// </summary>
    public async Task<QuestionTimeAnswerBody?> GetTimeAnsweringBodyAsync(int timeId, int bodyId) =>
        await _restClient.GetItemAsync<QuestionTimeAnswerBody>($"resources/{timeId}/QuestionTimeAnswerBody/{bodyId}");

    /// <summary>
    /// Commons Oral Questions Time Answering Body by ID.
    /// </summary>
    public async Task<QuestionTimeAnswerBody?> GetTimeAnsweringBodyAsync(CommonsOralQuestionTime time, int bodyId) =>
        await GetTimeAnsweringBodyAsync(time.GetId(), bodyId);

    /// <summary>
    /// Commons Oral Questions Time Answering Body by ID.
    /// </summary>
    public async Task<QuestionTimeAnswerBody?> GetTimeAnsweringBodyAsync(CommonsOralQuestionTime time, QuestionTimeAnswerBody body) =>
        await GetTimeAnsweringBodyAsync(time.GetId(), body.GetId());

    /// <summary>
    /// Commons Oral Questions Time Answering Body by ID.
    /// </summary>
    public async Task<QuestionTimeAnswerBody?> GetTimeAnsweringBodyAsync(int timeId, QuestionTimeAnswerBody body) =>
        await GetTimeAnsweringBodyAsync(timeId, body.GetId());

    #endregion Get Time Answering Body
}