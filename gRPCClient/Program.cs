using CodeSession.Shared;
using Grpc.Net.Client;

using var channel = GrpcChannel.ForAddress("https://localhost:7137");
var client = new WeatherForecasts.WeatherForecastsClient(channel);
var reply = (await client.GetWeatherAsync(new WeatherRequest())).Forecasts;

Console.WriteLine("Forecasts: " + reply);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();