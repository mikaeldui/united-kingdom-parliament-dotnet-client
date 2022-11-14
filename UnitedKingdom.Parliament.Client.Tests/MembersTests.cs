using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitedKingdom.Parliament.Tests;

[TestClass]
public class MembersTests
{
    [TestMethod]
    public async Task GetCommonsMembersAsync()
    {
        using ParliamentClient client = new();
        var result = await client.Members.GetCommonsMembersAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().GivenName.Value);
    }

    [TestMethod]
    public async Task GetLordsMembersAsync()
    {
        using ParliamentClient client = new();
        var result = await client.Members.GetLordsMembersAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().GivenName.Value);
    }

    [TestMethod]
    public async Task GetMembersAsync()
    {
        using ParliamentClient client = new();
        var result = await client.Members.GetMembersAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().GivenName.Value);
    }

    [TestMethod]
    public async Task GetMemberAsync()
    {
        using ParliamentClient client = new();
        var members = await client.Members.GetMembersAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var result = await client.Members.GetMemberAsync(members.Items.First());
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.GivenName.Value);
    }

    [TestMethod]
    public async Task GetCommonsFinancialInterestsAsync()
    {
        Assert.Inconclusive("Didn't return anything when test was written.");
        using ParliamentClient client = new();
        var result = await client.Members.GetCommonsFinancialInterestsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().GivenName.Value);
        Assert.IsNotNull(result.Items.First().FinancialInterests.Any());
    }

    [TestMethod]
    public async Task GetLordsFinancialInterestsAsync()
    {
        using ParliamentClient client = new();
        var result = await client.Members.GetLordsFinancialInterestsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().GivenName.Value);
        Assert.IsNotNull(result.Items.First().FinancialInterests.Any());
    }

    [TestMethod]
    public async Task GetLordsFinancialInterestsByMemberAsync()
    {
        using ParliamentClient client = new();
        var lords = await client.Members.GetLordsFinancialInterestsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var result = await client.Members.GetLordsFinancialInterestsByMemberAsync(lords.Items.First());
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().RegisteredInterest.Value);
    }
}
