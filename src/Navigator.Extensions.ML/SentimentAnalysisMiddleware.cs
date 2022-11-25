using MediatR;
using Microsoft.Extensions.ML;
using Navigator.Actions;
using Navigator.Context;
using Navigator.Extensions.ML.Model;
using Navigator.Extensions.ML.Sentiment;

namespace Navigator.Extensions.ML;

/// <summary>
/// 
/// </summary>
public abstract class SentimentAnalysisMiddleware<TAction, TResponse> : IActionMiddleware<TAction, TResponse> where TAction : IAction
{
    private readonly PredictionEnginePool<ActionSentimentData, ActionSentimentPrediction> _predictionEnginePool;
    private readonly INavigatorContext _navigatorContext;

    protected SentimentAnalysisMiddleware(PredictionEnginePool<ActionSentimentData, ActionSentimentPrediction> predictionEnginePool,
        INavigatorContextAccessor navigatorContextAccessor)
    {
        _predictionEnginePool = predictionEnginePool;
        _navigatorContext = navigatorContextAccessor.NavigatorContext;
    }

    /// <inheritdoc />
    public async Task<Status> Handle(TAction action, CancellationToken cancellationToken, RequestHandlerDelegate<Status> next)
    {
        var data = GetData(action);

        if (data is not null)
        {
            var prediction = _predictionEnginePool.Predict(EModel.SentimentAnalysisModel.ToString(), data);
        }

        return await next();
    }

    protected abstract ActionSentimentData? GetData(TAction action);
}