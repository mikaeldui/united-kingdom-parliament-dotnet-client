using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Text;
using System.Web;

namespace UnitedKingdom.Parliament.Rest;

internal class ParliamentRestClient : HttpClient
{
    public async Task<TResult?> GetAsync<TResult>(string url)
    {
        if (url.Contains('?'))
        {
            url = url.Insert(url.IndexOf('?'), ".json");
        }
        else
            url += ".json";

        var result = await this.GetFromJsonAsync<ParliamentResponse<TResult>>(url);
        if (result == null) return default;
        return result.Result;
    }

    public async Task<ParliamentListPage<TResult>?> GetListPageAsync<TResult>(string url, Action<ParliamentPageOptions>? options = null)
    {
        ParliamentPageOptions? opt = null;
        if (options != null)
        {
            opt = new();
            options.Invoke(opt);
            var queryString = opt.ToString();
            if (url.Contains('?'))
                url += "&" + queryString;
            else
                url += "?" + queryString;
        }
        var result = await GetAsync<ParliamentListPage<TResult>>(url);
        result.Options = opt;
        return result;
    }

    public async Task<ParliamentItemPage<TResult>?> GetItemPageAsync<TResult>(string url) =>
        await GetAsync<ParliamentItemPage<TResult>>(url);

    public async Task<TResult?> GetItemAsync<TResult>(string url)
    {
        var result = await GetAsync<ParliamentItemPage<TResult>>(url);
        if (result == null) return default;
        return result.PrimaryTopic;
    }
}
