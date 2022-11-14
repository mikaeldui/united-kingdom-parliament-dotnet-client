using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitedKingdom.Parliament.Tests;

[TestClass]
public class CommonsTests
{
    [TestMethod]
    public async Task GetDivisionsAsync()
    {
        using ParliamentClient client = new();
        var result = await client.Commons.Divisions.GetDivisionsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().Title);
    }

    [TestMethod]
    public async Task GetDivisionByIdAsync()
    {
        using ParliamentClient client = new();
        var result = await client.Commons.Divisions.GetDivisionAsync(1540507);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Title);
    }

    [TestMethod]
    public async Task GetDivisionAsync()
    {
        using ParliamentClient client = new();
        var divisions = await client.Commons.Divisions.GetDivisionsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var result = await client.Commons.Divisions.GetDivisionAsync(divisions.Items.First());
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Title);
    }

    [TestMethod]
    public async Task GetDivisionsBySessionAsync()
    {
        using ParliamentClient client = new();
        var divisions = await client.Commons.Divisions.GetDivisionsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var division = await client.Commons.Divisions.GetDivisionAsync(divisions.Items.First());
        var result = await client.Commons.Divisions.GetDivisionsBySessionAsync(division.Session.First());
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().Title);
    }

    [TestMethod]
    public async Task GetDivisionsByUinAsync()
    {
        using ParliamentClient client = new();
        var divisions = await client.Commons.Divisions.GetDivisionsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var result = await client.Commons.Divisions.GetDivisionsByUinAsync(divisions.Items.First().Uin);
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().Title);
    }

    [TestMethod]
    public async Task GetDivisionVoteAsync()
    {
        using ParliamentClient client = new();
        var divisions = await client.Commons.Divisions.GetDivisionsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var division = await client.Commons.Divisions.GetDivisionAsync(divisions.Items.First());
        var result = await client.Commons.Divisions.GetDivisionVoteAsync(division.GetId(), division.Votes.First().GetId());
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.MemberParty);
    }

    [TestMethod]
    public async Task GetDivisionsWhereMemberVotedNoAsync()
    {
        using ParliamentClient client = new();
        var divisions = await client.Commons.Divisions.GetDivisionsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var division = await client.Commons.Divisions.GetDivisionAsync(divisions.Items.First());
        var result = await client.Commons.Divisions.GetDivisionsWhereMemberVotedNoAsync(division.Votes.First().Member.First());
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().Title);
    }

    [TestMethod]
    public async Task GetDivisionsWhereMemberVotedAyeAsync()
    {
        using ParliamentClient client = new();
        var divisions = await client.Commons.Divisions.GetDivisionsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var division = await client.Commons.Divisions.GetDivisionAsync(divisions.Items.First());
        var result = await client.Commons.Divisions.GetDivisionsWhereMemberVotedAyeAsync(division.Votes.First().Member.First());
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().Title);
    }
}
