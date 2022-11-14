using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitedKingdom.Parliament.Tests;

[TestClass]
public class ResearchBriefingTests
{
    [TestMethod]
    public async Task GetResearchBriefingsAsync()
    {
        using ParliamentClient client = new();
        var result = await client.ResearchBriefings.GetResearchBriefingsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().Description.First());
    }

    [TestMethod]
    public async Task GetResearchBriefingAsync()
    {
        using ParliamentClient client = new();
        var researchBriefings = await client.ResearchBriefings.GetResearchBriefingsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var result = await client.ResearchBriefings.GetResearchBriefingAsync(researchBriefings.Items.First());
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Description.First());
    }
}
