using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitedKingdom.Parliament.Tests;

[TestClass]
public class ElectionsTests
{
    [TestMethod]
    public async Task GetElectionsAsync()
    {
        using ParliamentClient client = new();
        var result = await client.Elections.GetElectionsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().Label.Value);
    }

    [TestMethod]
    public async Task GetElectionAsync()
    {
        using ParliamentClient client = new();
        var elections = await client.Elections.GetElectionsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var result = await client.Elections.GetElectionAsync(elections.Items.First());
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Label.Value);
    }

    [TestMethod]
    public async Task GetElectionResultsAsync()
    {
        using ParliamentClient client = new();
        var result = await client.Elections.GetElectionResultsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().ResultOfElection);
    }

    [TestMethod]
    public async Task GetElectionResultAsync()
    {
        using ParliamentClient client = new();
        var electionResults = await client.Elections.GetElectionResultsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var result = await client.Elections.GetElectionResultAsync(electionResults.Items.First());
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.ResultOfElection);
    }

    [TestMethod]
    public async Task GetElectionResultsByElectionAsync()
    {
        using ParliamentClient client = new();
        var elections = await client.Elections.GetElectionsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var result = await client.Elections.GetElectionResultsByElectionAsync(elections.Items.First(), options =>
        {
            options.PageSize = 20;
            options.Sort.Add("date");
        });
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().ResultOfElection);
    }

    [TestMethod]
    public async Task GetElectionResultsByConstituencyAsync()
    {
        using ParliamentClient client = new();
        var electionResults = await client.Elections.GetElectionResultsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var result = await client.Elections.GetElectionResultsByConstituencyAsync(electionResults.Items.First().Constituency, options =>
        {
            options.PageSize = 20;
            options.Sort.Add("date");
        });
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().ResultOfElection);
    }

    [TestMethod]
    public async Task GetCandidateElectionResultAsync()
    {
        using ParliamentClient client = new();
        var electionResults = await client.Elections.GetElectionResultsAsync();
        var electionResult = await client.Elections.GetElectionResultAsync(electionResults.Items.First());
        var result = await client.Elections.GetCandidateElectionResultAsync(electionResult, electionResult.Candidates.First());
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.FullName.Value);
    }
}
