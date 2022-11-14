using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

public class ParliamentClient : IDisposable
{
    private ParliamentRestClient _restClient;
    private ParliamentCommonsClient? _commonsClient;
    private ParliamentElectionClient? _electionClient;
    private ParliamentLordsClient? _lordsClient;
    private ParliamentMemberClient? _memberClient;
    private ParliamentPublicationLogClient? _publicationLogClient;
    private ParliamentResearchBriefingClient? _researchBriefingClient;

    public ParliamentClient() => _restClient = new ParliamentRestClient()
    {
        BaseAddress = new Uri("https://lda.data.parliament.uk/", UriKind.Absolute)
    };

    public ParliamentCommonsClient Commons => _commonsClient ??= new(_restClient);

    public ParliamentElectionClient Elections => _electionClient ??= new(_restClient);

    public ParliamentLordsClient Lords => _lordsClient ??= new(_restClient);

    /// <summary>
    /// Returns all Members' Biographies.
    /// </summary>
    public ParliamentMemberClient Members => _memberClient ??= new(_restClient);

    /// <summary>
    /// Returns all Publication Logs.
    /// </summary>
    public ParliamentPublicationLogClient PublicationLogs => _publicationLogClient ??= new(_restClient);
    
    /// <summary>
    /// Returns all Research Briefings.
    /// </summary>
    public ParliamentResearchBriefingClient ResearchBriefings => _researchBriefingClient ??= new(_restClient);

    public void Dispose() => ((IDisposable)_restClient).Dispose();
}