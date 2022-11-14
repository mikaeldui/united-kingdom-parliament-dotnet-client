using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitedKingdom.Parliament.Tests;

[TestClass]
public class LordsWrittenQuestionsTests
{
    [TestMethod]
    public async Task GetQuestionsAsync()
    {
        using ParliamentClient client = new();
        var result = await client.Lords.WrittenQuestions.GetQuestionsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().Title);
    }

    [TestMethod]
    public async Task GetQuestionsByAnsweringBodyAsync()
    {
        using ParliamentClient client = new();
        var questions = await client.Lords.WrittenQuestions.GetQuestionsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var result = await client.Lords.WrittenQuestions.GetQuestionsByAnsweringBodyAsync(questions.Items.First(), options =>
        {
            options.PageSize = 20;
            options.Sort.Add("date");
        });
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().Title);
    }

    [TestMethod]
    public async Task GetQuestionsByMemberAsync()
    {
        using ParliamentClient client = new();
        var questions = await client.Lords.WrittenQuestions.GetQuestionsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var result = await client.Lords.WrittenQuestions.GetQuestionsByMemberAsync(questions.Items.First().TablingMember, options =>
        {
            options.PageSize = 20;
            options.Sort.Add("date");
        });
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().Title);
    }

    [TestMethod]
    public async Task GetQuestionsBySessionAsync()
    {
        Assert.Inconclusive("Don't know how to get session.");
        //using ParliamentClient client = new();
        //var questions = await client.Lords.WrittenQuestions.GetQuestionsAsync(options =>
        //{
        //    options.PageSize = 20;
        //    options.Sort.Add("-date");
        //});
        //var result = await client.Lords.WrittenQuestions.GetQuestionsBySessionAsync(questions.Items.First(), options =>
        //{
        //    options.PageSize = 20;
        //    options.Sort.Add("date");
        //});
        //Assert.IsNotNull(result);
        //Assert.IsTrue(result.Items.Any());
        //Assert.IsNotNull(result.Items.First().Title);
    }

    [TestMethod]
    public async Task GetQuestionsByTableDateAsync()
    {
        using ParliamentClient client = new();
        var questions = await client.Lords.WrittenQuestions.GetQuestionsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var result = await client.Lords.WrittenQuestions.GetQuestionsByTableDateAsync(questions.Items.First().DateTabled.Value.AddMonths(-1), questions.Items.First().DateTabled.Value, options =>
        {
            options.PageSize = 20;
            options.Sort.Add("date");
        });
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().Title);
    }

    [TestMethod]
    public async Task GetQuestionsByUinAsync()
    {
        using ParliamentClient client = new();
        var questions = await client.Lords.WrittenQuestions.GetQuestionsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var result = await client.Lords.WrittenQuestions.GetQuestionsByUinAsync(questions.Items.First(), options =>
        {
            options.PageSize = 20;
            options.Sort.Add("date");
        });
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().Title);
    }

    [TestMethod]
    public async Task GetQuestionAsync()
    {
        using ParliamentClient client = new();
        var questions = await client.Lords.WrittenQuestions.GetQuestionsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var result = await client.Lords.WrittenQuestions.GetQuestionAsync(questions.Items.First());
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Title);
    }
}
