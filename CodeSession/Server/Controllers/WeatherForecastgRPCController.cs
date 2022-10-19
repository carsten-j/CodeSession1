using CodeSession.Server.Services;
using CodeSession.Shared;
using Grpc.Core;

namespace CodeSession.Server.Controllers;

public class WeatherForecastGrpcService : WeatherForecasts.WeatherForecastsBase
{
    private readonly IForecastService _forecastService;

    public WeatherForecastGrpcService(IForecastService forecastService)
    {
        _forecastService = forecastService;
    }

    public override Task<WeatherReply> GetWeather(WeatherRequest request, ServerCallContext context)
    {
        var reply = new WeatherReply();

        reply.Forecasts.Add(_forecastService.CreateForecasts(100));

        return Task.FromResult(reply);
    }
}