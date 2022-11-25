using Microsoft.ML.Data;

namespace Navigator.Extensions.ML.Sentiment;

public class ActionSentimentData
{
    [LoadColumn(0)]
    public string SentimentText = null!;

    [LoadColumn(1)]
    [ColumnName("Label")]
    public bool Sentiment;
}