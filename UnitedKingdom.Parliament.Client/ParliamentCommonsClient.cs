using System.ComponentModel;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament
{
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ParliamentCommonsClient
    {
        private readonly ParliamentRestClient _restClient;
        private ParliamentCommonsDivisionsClient? _divisionsClient;

        internal ParliamentCommonsClient(ParliamentRestClient restClient) => _restClient = restClient;

        public ParliamentCommonsDivisionsClient Divisions => _divisionsClient ??= new ParliamentCommonsDivisionsClient(_restClient);
    }
}