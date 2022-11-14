using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;
using UnitedKingdom.Parliament.Converters;
using UnitedKingdom.Parliament.Rest;

namespace UnitedKingdom.Parliament;

/// <summary>
/// Returns all Research Briefings.
/// </summary>
[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
public class ParliamentResearchBriefingClient
{
    private readonly ParliamentRestClient _restClient;

    internal ParliamentResearchBriefingClient(ParliamentRestClient restClient) => _restClient = restClient;

    /// <summary>
    /// All Research Briefings.
    /// </summary>
    public async Task<ParliamentListPage<ResearchBriefing>?> GetResearchBriefingsAsync(Action<ParliamentPageOptions>? options = null) =>
        await _restClient.GetListPageAsync<ResearchBriefing>("researchbriefings", options);

    /// <summary>
    /// All Research Briefings.
    /// </summary>
    public async Task<ResearchBriefing?> GetResearchBriefingAsync(int id) =>
        await _restClient.GetItemAsync<ResearchBriefing>("researchbriefings/" + id);

    /// <summary>
    /// All Research Briefings.
    /// </summary>
    public async Task<ResearchBriefing?> GetResearchBriefingAsync(ResearchBriefing researchBriefing) =>
        await GetResearchBriefingAsync(researchBriefing.GetId());
}

[DebuggerDisplay($"{{{nameof(Identifier)}}} - {{{nameof(Title)}}}")]
public class ResearchBriefing : LinkedData
{
    public StringValue Abstract { get; set; }
    public DateTimeValue Date { get; set; }
    public string[] Description { get; set; }
    public StringValue Identifier { get; set; }
    public Publisher Publisher { get; set; }
    [JsonPropertyName("section")]
    public Section[] Sections { get; set; }
    public SubType SubType { get; set; }
    public string Title { get; set; }
    [JsonPropertyName("topic"), JsonConverter(typeof(SingleOrArrayConverter<Topic[], Topic>))]
    public Topic[] Topics { get; set; }

    // Extended
    public BriefingDocument? BriefingDocument { get; set; }
    public Uri? ContentLocation { get; set; }
    public DateTimeValue? Created { get; set; }
    public Author? Creator { get; set; }
    public string? Disclaimer { get; set; }
    public Uri? ExternalLocation { get; set; }
    public string? HtmlSummary { get; set; }
    public string? InternalLocation { get; set; }
    public DateTimeValue? Modified { get; set; }
    public BooleanValue? Published { get; set; }
    public ResearchContributor[]? ResearchContributors { get; set; }
    public string? Status { get; set; }
}
