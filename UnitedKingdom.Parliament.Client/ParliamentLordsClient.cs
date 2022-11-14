using System.ComponentModel;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
public class ParliamentLordsClient
{
    private readonly ParliamentRestClient _restClient;
    private ParliamentLordsBillAmendmentsClient? _billAmendmentsClient;
    private ParliamentLordsWrittenQuestionsClient? _writtenQuestionsClient;

    internal ParliamentLordsClient(ParliamentRestClient restClient) => _restClient = restClient;

    public ParliamentLordsBillAmendmentsClient BillAmendments => _billAmendmentsClient ??= new ParliamentLordsBillAmendmentsClient(_restClient);
    public ParliamentLordsWrittenQuestionsClient WrittenQuestions => _writtenQuestionsClient ??= new ParliamentLordsWrittenQuestionsClient(_restClient);
}