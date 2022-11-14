using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament
{
    public class ParliamentClient : IDisposable
    {
        private ParliamentRestClient _restClient;
        private ParliamentCommonsClient? _commonsClient;
        private ParliamentElectionClient? _electionClient;
        private ParliamentLordsClient? _lordsClient;

        public ParliamentClient() => _restClient = new ParliamentRestClient()
        {
            BaseAddress = new Uri("https://lda.data.parliament.uk/", UriKind.Absolute)
        };

        public ParliamentCommonsClient Commons => _commonsClient ??= new ParliamentCommonsClient(_restClient);

        public ParliamentElectionClient Elections => _electionClient ??= new ParliamentElectionClient(_restClient);

        public ParliamentLordsClient Lords => _lordsClient ??= new ParliamentLordsClient(_restClient);

        public void Dispose() => ((IDisposable)_restClient).Dispose();
    }
}