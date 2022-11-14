using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitedKingdom.Parliament.Tests;

[TestClass]
public class LordsBillAmendmentsTests
{
    [TestMethod]
    public async Task GetBillAmendmentsAsync()
    {
        using ParliamentClient client = new();
        var result = await client.Lords.BillAmendments.GetBillAmendmentsAsync(options =>
        {
            options.PageSize = 20;
            options.Sort.Add("-date");
        });
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Items.Any());
        Assert.IsNotNull(result.Items.First().Label.Value);
    }
}
