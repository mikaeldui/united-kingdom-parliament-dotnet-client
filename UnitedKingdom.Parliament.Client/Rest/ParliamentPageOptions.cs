using System.Web;

namespace UnitedKingdom.Parliament.Rest;

public class ParliamentPageOptions
{
    /// <summary>
    /// Brings back maximum of value or 500 records - whichever is less.
    /// </summary>
    public int? PageSize { get; set; }

    /// <summary>
    /// Brings back page number value.
    /// </summary>
    public int? Page { get; set; }

    /// <summary>
    /// Orders data by specified field(s). Use -(minus) in front of qsName to sort in ascending order
    /// </summary>
    public List<string> Sort { get; } = new List<string>();

    public ParliamentPageFilterOptions Filters { get; } = new ParliamentPageFilterOptions();

    /// <summary>
    /// Text search where value is a lucene query.
    /// See http://lucene.apache.org/core/4_1_0/queryparser/org/apache/lucene/queryparser/classic/package-summary.html#package_description.
    /// </summary>
    public string? Search { get; set; }

    public override string? ToString()
    {
        var queryString = HttpUtility.ParseQueryString("");
        foreach (var filter in Filters.Filters) queryString.Add(filter.Key, filter.Value);
        if (PageSize != null) queryString.Add("_pageSize", PageSize.ToString());
        if (Page != null) queryString.Add("_page", Page.ToString());
        if (Sort.Any()) queryString.Add("_sort", Sort.Join(","));
        if (Search != null) queryString.Add("_search", Search);
        return queryString.ToString();
    }
}
