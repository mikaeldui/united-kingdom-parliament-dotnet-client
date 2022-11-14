using System.ComponentModel;
using System.Linq.Expressions;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament
{
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ParliamentCommonsWrittenQuestionsClient
    {
        private readonly ParliamentRestClient _restClient;

        internal ParliamentCommonsWrittenQuestionsClient(ParliamentRestClient restClient) => _restClient = restClient;

        /// <summary>
        /// All Commons Written Questions.
        /// </summary>
        public async Task<ParliamentListPage<CommonsWrittenQuestion>?> GetQuestionsAsync(Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetListPageAsync<CommonsWrittenQuestion>("commonswrittenquestions", options);

        #region Get Questions By Answering Body

        /// <summary>
        /// All Commons Written Questions By Answering Body.
        /// </summary>
        public async Task<ParliamentListPage<CommonsWrittenQuestion>?> GetQuestionsByAnsweringBodyAsync(string query, Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetListPageAsync<CommonsWrittenQuestion>("commonswrittenquestions/answeringdepartment?q=" + query, options);

        /// <summary>
        /// All Commons Written Questions By Answering Body.
        /// </summary>
        public async Task<ParliamentListPage<CommonsWrittenQuestion>?> GetQuestionsByAnsweringBodyAsync(CommonsWrittenQuestion questionWithAnsweringBody, Action<ParliamentPageOptions>? options = null) =>
            await GetQuestionsByAnsweringBodyAsync(questionWithAnsweringBody.AnsweringBody.First().Value, options);

        #endregion Get Questions By Answering Body

        #region Get Questions By Member

        /// <summary>
        /// All Commons Written Questions By Member.
        /// </summary>
        public async Task<ParliamentListPage<CommonsWrittenQuestion>?> GetQuestionsByMemberAsync(int mnisId, Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetListPageAsync<CommonsWrittenQuestion>("commonswrittenquestions?mnisId=" + mnisId, options);

        /// <summary>
        /// All Commons Written Questions By Member.
        /// </summary>
        public async Task<ParliamentListPage<CommonsWrittenQuestion>?> GetQuestionsByMemberAsync(Member member, Action<ParliamentPageOptions>? options = null) =>
            await GetQuestionsByMemberAsync(member.GetId(), options);

        #endregion Get Questions By Member

        #region Get Questions By Session

        /// <summary>
        /// All Commons Written Questions By Session.
        /// </summary>
        public async Task<ParliamentListPage<CommonsWrittenQuestion>?> GetQuestionsBySessionAsync(string session, Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetListPageAsync<CommonsWrittenQuestion>("commonswrittenquestions?session=" + session, options);

        #endregion Get Questions By Session

        /// <summary>
        /// All Commons Written Questions By Table Date.
        /// </summary>
        public async Task<ParliamentListPage<CommonsWrittenQuestion>?> GetQuestionsByTableDateAsync(DateTime startDate, DateTime endDate, Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetListPageAsync<CommonsWrittenQuestion>($"commonswrittenquestions/tabled?startDate={startDate:s}&endDate={endDate:s}", options);

        #region Get Questions By UIN

        /// <summary>
        /// All Commons Written Questions By UIN.
        /// </summary>
        public async Task<ParliamentListPage<CommonsWrittenQuestion>?> GetQuestionsByUinAsync(string uin, Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetListPageAsync<CommonsWrittenQuestion>("commonswrittenquestions?uin=" + uin, options);

        /// <summary>
        /// All Commons Written Questions By UIN.
        /// </summary>
        public async Task<ParliamentListPage<CommonsWrittenQuestion>?> GetQuestionsByUinAsync(CommonsWrittenQuestion questionWithUin, Action<ParliamentPageOptions>? options = null) =>
            await GetQuestionsByUinAsync(questionWithUin.Uin, options);

        #endregion Get Questions By UIN

        #region Get Question

        /// <summary>
        /// Commons Written Questions By ID.
        /// </summary>
        public async Task<CommonsWrittenQuestion?> GetQuestionAsync(int id) =>
            await _restClient.GetItemAsync<CommonsWrittenQuestion>("commonswrittenquestions/" + id);

        /// <summary>
        /// Commons Written Questions By ID.
        /// </summary>
        public async Task<CommonsWrittenQuestion?> GetQuestionAsync(CommonsWrittenQuestion question) =>
            await GetQuestionAsync(question.GetId());

        #endregion Get Question
    }
}