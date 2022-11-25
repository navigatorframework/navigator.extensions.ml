using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;
using Navigator.Configuration;
using Navigator.Configuration.Extension;
using Navigator.Extensions.ML.Model;
using Navigator.Extensions.ML.Sentiment;

namespace Navigator.Extensions.ML;

/// <summary>
/// Extensions to NavigatorConfiguration
/// </summary>
public static class NavigatorExtensionConfigurationExtensions
{
    /// <summary>
    /// Configures the Sentiment Analysis ML extension.
    /// </summary>
    /// <param name="extensionConfiguration"></param>
    /// <returns></returns>
    public static NavigatorConfiguration SentimentAnalysis(this NavigatorExtensionConfiguration extensionConfiguration)
    {

        return extensionConfiguration.Extension(
            configuration =>
            {
                configuration.Services.AddPredictionEnginePool<ActionSentimentData, ActionSentimentPrediction>()
                    .FromUri(
                        modelName: EModel.SentimentAnalysisModel.ToString(),
                        uri:"https://github.com/dotnet/samples/raw/main/machine-learning/models/sentimentanalysis/sentiment_model.zip",
                        period: TimeSpan.FromMinutes(1));
            });
    }
}