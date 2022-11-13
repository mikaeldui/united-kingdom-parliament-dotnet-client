using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament
{
    public class ParliamentClient : IDisposable
    {
        private ParliamentRestClient _restClient;
        private ParliamentCommonsClient? _commonsClient;

        public ParliamentClient() => _restClient = new ParliamentRestClient()
        {
            BaseAddress = new Uri("https://lda.data.parliament.uk/", UriKind.Absolute)
        };

        public ParliamentCommonsClient Commons => _commonsClient ??= new ParliamentCommonsClient(_restClient);

        public void Dispose() => ((IDisposable)_restClient).Dispose();
    }
}