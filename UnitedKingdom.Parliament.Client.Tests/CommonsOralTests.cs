using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitedKingdom.Parliament.Tests
{
    [TestClass]
    public class CommonsOralTests
    {
        [TestMethod]
        public async Task GetQuestionsAsync()
        {
            using ParliamentClient client = new();
            var result = await client.Commons.OralQuestions.GetQuestionsAsync(options =>
            {
                options.PageSize = 20;
                options.Sort.Add("-date");
            });
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Any());
            Assert.IsNotNull(result.Items.First().About);
        }

        [TestMethod]
        public async Task GetQuestionsByAnswerDateAsync()
        {
            using ParliamentClient client = new();
            var result = await client.Commons.OralQuestions.GetQuestionsByAnswerDateAsync(new DateTime(2020, 01, 01), new DateTime(2020, 03, 31), options =>
            {
                options.PageSize = 20;
                options.Sort.Add("date");
            });
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Any());
            Assert.IsNotNull(result.Items.First().About);
        }

        [TestMethod]
        public async Task GetQuestionsByMnisIdAsync()
        {
            using ParliamentClient client = new();
            var questions = await client.Commons.OralQuestions.GetQuestionsAsync(options =>
            {
                options.PageSize = 20;
                options.Sort.Add("-date");
            });
            var result = await client.Commons.OralQuestions.GetQuestionsByMnisIdAsync(questions.Items.First().TablingMember, options =>
            {
                options.PageSize = 20;
                options.Sort.Add("date");
            });
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Any());
            Assert.IsNotNull(result.Items.First().About);
        }

        [TestMethod]
        public async Task GetQuestionsByAnsweringBodyAsync()
        {
            using ParliamentClient client = new();
            var questions = await client.Commons.OralQuestions.GetQuestionsAsync(options =>
            {
                options.PageSize = 20;
                options.Sort.Add("-date");
            });
            var result = await client.Commons.OralQuestions.GetQuestionsByAnsweringBodyAsync(questions.Items.First().AnsweringBody.First().Value, options =>
            {
                options.PageSize = 20;
                options.Sort.Add("date");
            });
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Any());
            Assert.IsNotNull(result.Items.First().About);
        }

        [TestMethod]
        public async Task GetQuestionsBySessionAsync()
        {
            Assert.Inconclusive("Don't know how to get a session.");
            using ParliamentClient client = new();
            var questions = await client.Commons.OralQuestions.GetQuestionsAsync(options =>
            {
                options.PageSize = 20;
                options.Sort.Add("-date");
            });
            var result = await client.Commons.OralQuestions.GetQuestionsBySessionAsync(questions.Items.First().AnsweringBody.First().Value, options =>
            {
                options.PageSize = 20;
                options.Sort.Add("date");
            });
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Any());
            Assert.IsNotNull(result.Items.First().About);
        }

        [TestMethod]
        public async Task GetQuestionsByTablingDateAsync()
        {
            Assert.Inconclusive("Don't know how to get tabling date.");
            //using ParliamentClient client = new();
            //var questions = await client.Commons.OralQuestions.GetQuestionsAsync(options =>
            //{
            //    options.PageSize = 20;
            //    options.Sort.Add("-date");
            //});
            //var result = await client.Commons.OralQuestions.GetQuestionsByTablingDateAsync(questions.Items.First().AnsweringBody.First().Value, options =>
            //{
            //    options.PageSize = 20;
            //    options.Sort.Add("date");
            //});
            //Assert.IsNotNull(result);
            //Assert.IsTrue(result.Items.Any());
            //Assert.IsNotNull(result.Items.First().About);
        }

        [TestMethod]
        public async Task GetQuestionsByTimeAsync()
        {
            using ParliamentClient client = new();
            var questions = await client.Commons.OralQuestions.GetQuestionsAsync(options =>
            {
                options.PageSize = 20;
                options.Sort.Add("-date");
            });
            var result = await client.Commons.OralQuestions.GetQuestionsByTimeAsync(questions.Items.First().CommonsQuestionTime, options =>
            {
                options.PageSize = 20;
                options.Sort.Add("date");
            });
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Any());
            Assert.IsNotNull(result.Items.First().About);
        }

        [TestMethod]
        public async Task GetQuestionAsync()
        {
            using ParliamentClient client = new();
            var questions = await client.Commons.OralQuestions.GetQuestionsAsync(options =>
            {
                options.PageSize = 20;
                options.Sort.Add("-date");
            });
            var result = await client.Commons.OralQuestions.GetQuestionAsync(questions.Items.First());
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.About);
        }
    }
}
