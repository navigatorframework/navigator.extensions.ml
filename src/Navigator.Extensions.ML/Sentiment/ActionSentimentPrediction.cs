using Microsoft.ML.Data;

namespace Navigator.Extensions.ML.Sentiment;

public class ActionSentimentPrediction : ActionSentimentData
{

    [ColumnName("PredictedLabel")]
    public bool Prediction { get; set; }

    public float Probability { get; set; }

    public float Score { get; set; }
}