using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitedKingdom.Parliament.Tests;

[TestClass]
public class PublicationLogTests
{
    [TestMethod]
    public async Task GetPublicationLogsAsync()
    {
        using ParliamentClient client = new();
        var result = await client.PublicationLogs.GetPublicationLogsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().Label.Value);
    }

    [TestMethod]
    public async Task GetPublicationLogAsync()
    {
        using ParliamentClient client = new();
        var publicationLogs = await client.PublicationLogs.GetPublicationLogsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        var result = await client.PublicationLogs.GetPublicationLogAsync(publicationLogs.Items.First());
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Label.Value);
    }
}
