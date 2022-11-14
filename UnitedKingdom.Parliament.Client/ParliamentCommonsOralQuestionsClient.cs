﻿using System.ComponentModel;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament
{
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ParliamentCommonsOralQuestionsClient
    {
        private readonly ParliamentRestClient _restClient;

        internal ParliamentCommonsOralQuestionsClient(ParliamentRestClient restClient) => _restClient = restClient;

        /// <summary>
        /// All Commons Oral Questions.
        /// </summary>
        public async Task<ParliamentListPage<CommonsOralQuestion>?> GetQuestionsAsync(Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetListPageAsync<CommonsOralQuestion>("commonsoralquestions", options);

        /// <summary>
        /// All Commons Oral Questions.
        /// </summary>
        public async Task<ParliamentListPage<CommonsOralQuestion>?> GetQuestionsByAnswerDateAsync(DateTime startDate, DateTime endDate, Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetListPageAsync<CommonsOralQuestion>($"commonsoralquestions/answerDate?startDate={startDate:s}&endDate={endDate:s}", options);

        #region GetQuestionsByMnisIdAsync

        /// <summary>
        /// All Commons Oral Questions.
        /// </summary>
        public async Task<ParliamentListPage<CommonsOralQuestion>?> GetQuestionsByMnisIdAsync(int mnisId, Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetListPageAsync<CommonsOralQuestion>("commonsoralquestions?mnisId=" + mnisId, options);

        /// <summary>
        /// All Commons Oral Questions.
        /// </summary>
        public async Task<ParliamentListPage<CommonsOralQuestion>?> GetQuestionsByMnisIdAsync(Member member, Action<ParliamentPageOptions>? options = null) =>
            await GetQuestionsByMnisIdAsync(member.GetId(), options);

        #endregion GetQuestionsByMnisIdAsync

        /// <summary>
        /// All Commons Oral Questions By Answering Body.
        /// </summary>
        public async Task<ParliamentListPage<CommonsOralQuestion>?> GetQuestionsByAnsweringBodyAsync(string query, Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetListPageAsync<CommonsOralQuestion>("commonsoralquestions/answeringdepartment?q=" + query, options);

        /// <summary>
        /// All Commons Oral Questions By Session.
        /// </summary>
        public async Task<ParliamentListPage<CommonsOralQuestion>?> GetQuestionsBySessionAsync(string session, Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetListPageAsync<CommonsOralQuestion>("commonsoralquestions?session=" + session, options);

        /// <summary>
        /// All Commons Oral Questions By Tabling Date.
        /// </summary>
        public async Task<ParliamentListPage<CommonsOralQuestion>?> GetQuestionsByTablingDateAsync(DateTime startDate, DateTime endDate, Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetListPageAsync<CommonsOralQuestion>($"commonsoralquestions/tabled?startDate={startDate:s}&endDate={endDate:s}", options);

        #region GetQuestionsByTimeAsync

        /// <summary>
        /// All Commons Oral Questions By Time ID.
        /// </summary>
        public async Task<ParliamentListPage<CommonsOralQuestion>?> GetQuestionsByTimeAsync(int id, Action<ParliamentPageOptions>? options = null) =>
            await _restClient.GetListPageAsync<CommonsOralQuestion>($"commonsoralquestions/parent/{id}", options);

        /// <summary>
        /// All Commons Oral Questions By Time ID.
        /// </summary>
        public async Task<ParliamentListPage<CommonsOralQuestion>?> GetQuestionsByTimeAsync(CommonsQuestionTime time, Action<ParliamentPageOptions>? options = null) =>
            await GetQuestionsByTimeAsync(time.GetId(), options);

        #endregion

        #region GetQuestionAsync

        /// <summary>
        /// Commons Oral Questions by ID.
        /// </summary>
        public async Task<CommonsOralQuestion?> GetQuestionAsync(int id) =>
            await _restClient.GetItemAsync<CommonsOralQuestion>("commonsoralquestions/" + id);

        /// <summary>
        /// Commons Oral Questions by ID.
        /// </summary>
        public async Task<CommonsOralQuestion?> GetQuestionAsync(CommonsOralQuestion question) =>
            await GetQuestionAsync(question.GetId());

        #endregion GetQuestionAsync
    }
}