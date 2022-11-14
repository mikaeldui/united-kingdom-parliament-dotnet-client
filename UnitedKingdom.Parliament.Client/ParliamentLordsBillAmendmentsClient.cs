﻿using System.ComponentModel;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
public class ParliamentLordsBillAmendmentsClient
{
    private readonly ParliamentRestClient _restClient;

    internal ParliamentLordsBillAmendmentsClient(ParliamentRestClient restClient) => _restClient = restClient;

    /// <summary>
    /// Returns all Lords Bill Amendments.
    /// </summary>
    public async Task<ParliamentListPage<LordsBillAmendment>?> GetBillAmendmentsAsync(Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<LordsBillAmendment>("lordsbillamendments", options);
}