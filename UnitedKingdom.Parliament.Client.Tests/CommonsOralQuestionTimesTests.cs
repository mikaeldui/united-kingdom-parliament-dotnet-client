using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitedKingdom.Parliament.Tests
{
    [TestClass]
    public class CommonsOralQuestionTimesTests
    {
        [TestMethod]
        public async Task GetTimesAsync()
        {
            using ParliamentClient client = new();
            var result = await client.Commons.OralQuestions.Times.GetTimesAsync(options =>
            {
                options.PageSize = 20;
                options.Sort.Add("-date");
            });
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Any());
            Assert.IsNotNull(result.Items.First().About);
        }

        [TestMethod]
        public async Task GetTimesBySessionAsync()
        {
            using ParliamentClient client = new();
            var times = await client.Commons.OralQuestions.Times.GetTimesAsync(options =>
            {
                options.PageSize = 20;
                options.Sort.Add("-date");
            });
            var result = await client.Commons.OralQuestions.Times.GetTimesBySessionAsync(times.Items.First(), options =>
            {
                options.PageSize = 20;
                options.Sort.Add("date");
            });
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Any());
            Assert.IsNotNull(result.Items.First().About);
        }

        [TestMethod]
        public async Task GetTimeAsync()
        {
            using ParliamentClient client = new();
            var times = await client.Commons.OralQuestions.Times.GetTimesAsync(options =>
            {
                options.PageSize = 20;
                options.Sort.Add("-date");
            });
            var result = await client.Commons.OralQuestions.Times.GetTimeAsync(times.Items.First());
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.About);
        }

        [TestMethod]
        public async Task GetTimeAnsweringBodyAsync()
        {
            using ParliamentClient client = new();
            var times = await client.Commons.OralQuestions.Times.GetTimesAsync(options =>
            {
                options.PageSize = 20;
                options.Sort.Add("-date");
            });
            var result = await client.Commons.OralQuestions.Times.GetTimeAnsweringBodyAsync(times.Items.First(), times.Items.First().AnswerBody.First());
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.About);
        }
    }
}
