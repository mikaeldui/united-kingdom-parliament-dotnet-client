using System.Text.Json.Serialization;

namespace UnitedKingdom.Parliament;

public abstract class LinkedData
{
    [JsonPropertyName("_about")]
    public Uri About { get; set; }
    /// <summary>
    /// Can be one or multiple URLs.
    /// </summary>
    public object? Type { get; set; }
    public Uri? IsPrimaryTopicOf { get; set; }

    /// <summary>
    /// Get the numeric resource ID.
    /// </summary>
    public int GetId() => int.Parse(About.AbsolutePath.AfterLast('/'));
}