using System.ComponentModel;
using System.Diagnostics;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

/// <summary>
/// Returns all Publication Logs.
/// </summary>
[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
public class ParliamentPublicationLogClient
{
    private readonly ParliamentRestClient _restClient;

    internal ParliamentPublicationLogClient(ParliamentRestClient restClient) => _restClient = restClient;

    /// <summary>
    /// Publication Logs.
    /// </summary>
    public async Task<ParliamentListPage<PublicationLog>?> GetPublicationLogsAsync(Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<PublicationLog>("publicationlogs", options);

    /// <summary>
    /// Publication Logs.
    /// </summary>
    public async Task<PublicationLog?> GetPublicationLogAsync(int id) =>
        await _restClient.GetItemAsync<PublicationLog>("publicationlogs/" + id);

    /// <summary>
    /// Publication Logs.
    /// </summary>
    public async Task<PublicationLog?> GetPublicationLogAsync(PublicationLog publicationLog) =>
        await GetPublicationLogAsync(publicationLog.GetId());
}

[DebuggerDisplay($"{{{nameof(Label)}}}")]
public class PublicationLog : LinkedData
{
    public StringValue Label { get; set; }
    public StringValue PaperNumber { get; set; }
    public DateTimeValue PublicationDate { get; set; }

    // Extended
    public Legislature[]? Legislature { get; set; }
    public SubType? SubType { get; set; }
}
