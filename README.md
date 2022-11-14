# United Kingdom Parliament .NET Client
[![.NET](https://github.com/mikaeldui/united-kingdom-parliament-dotnet-client/actions/workflows/dotnet.yml/badge.svg)](https://github.com/mikaeldui/united-kingdom-parliament-dotnet-client/actions/workflows/dotnet.yml)
[![CodeQL Analysis](https://github.com/mikaeldui/united-kingdom-parliament-dotnet-client/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/mikaeldui/united-kingdom-parliament-dotnet-client/actions/workflows/codeql-analysis.yml)

A .NET Client for the UK Parliament's API at https://explore.data.parliament.uk/.

You can install it using the following **.NET CLI** command:

    dotnet add package MikaelDui.UnitedKingdom.Parliament.Client --version *

## Example
Write the titles of the 20 latest commons divisions in the console.

    using ParliamentClient client = new();
    var result = await client.Commons.Divisions.GetDivisionsAsync(options =>
    {
        options.PageSize = 20;
        options.Sort.Add("-date");
    });

    foreach (var division in result.Items)
        Console.WriteLine(division.Title);
