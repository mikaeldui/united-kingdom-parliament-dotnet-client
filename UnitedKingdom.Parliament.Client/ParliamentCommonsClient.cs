using System.ComponentModel;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament
{
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ParliamentCommonsClient
    {
        private readonly ParliamentRestClient _restClient;
        private ParliamentCommonsDivisionsClient? _divisionsClient;
        private ParliamentCommonsOralQuestionsClient? _oralQuestionsClient;

        internal ParliamentCommonsClient(ParliamentRestClient restClient) => _restClient = restClient;

        public ParliamentCommonsDivisionsClient Divisions => _divisionsClient ??= new ParliamentCommonsDivisionsClient(_restClient);
        public ParliamentCommonsOralQuestionsClient OralQuestions => _oralQuestionsClient ??= new ParliamentCommonsOralQuestionsClient(_restClient);
    }
}