using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitedKingdom.Parliament.Tests
{
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
    }
}
