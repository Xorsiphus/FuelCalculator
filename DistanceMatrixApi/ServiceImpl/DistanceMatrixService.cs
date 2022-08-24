using System.Net.Http.Json;
using System.Text.Json;
using DistanceMatrixApi.Models.RouteDataResponse;
using DistanceMatrixApi.Policies;

namespace DistanceMatrixApi.ServiceImpl;

public class DistanceMatrixService : IDistanceMatrixService
{
    private readonly string? _apiKey;

    public DistanceMatrixService(string? apiKey)
    {
        _apiKey = apiKey;
    }

    /// <summary>
    /// Тестирование api
    /// </summary>
    /// <returns>Поле статуса ответа</returns>
    public async Task<string?> TestApi()
    {
        var result = await SendRequestAsync("Krasnoyarsk", "Divnogorsk");
        return result?
            .Status;
    }

    /// <summary>
    /// Основной метод, получения объекта с информацией о маршруте
    /// </summary>
    /// <param name="origins">Точка отправления</param>
    /// <param name="destination">Точка прибытия</param>
    /// <returns>Объект</returns>
    public async Task<RouteDataResponse?> GetRouteInfoAsync(string origins, string destination)
    {
        var result = await SendRequestAsync(origins, destination);
        return result;
    }

    /// <summary>
    /// Метод, с помощью которого получается расстояние между заданными точками
    /// </summary>
    /// <param name="origins">Точка отправления</param>
    /// <param name="destination">Точка прибытия</param>
    /// <returns>Расстояние между точками</returns>
    public async Task<int?> GetDistanceAsync(string origins, string destination)
    {
        var result = await GetRouteInfoAsync(origins, destination);
        return result?
            .Rows?.FirstOrDefault()?
            .Elements?.FirstOrDefault()?
            .Distance?
            .Value;
    }

    /// <summary>
    /// Компановщик ссылки для обращения к api
    /// </summary>
    /// <param name="origins">Первый параметр запроса</param>
    /// <param name="destination">Второй параметр запроса</param>
    /// <returns>Готовый экземпляр Uri</returns>
    private Uri CollectApiUri(string origins, string destination)
    {
        return new Uri("https://api.distancematrix.ai/maps/api/distancematrix/json" +
                       $"?origins={origins}" +
                       $"&destinations={destination}" +
                       $"&key={_apiKey}");
    }

    /// <summary>
    /// Выполнение запроса к api
    /// </summary>
    /// <returns>Объект ответа</returns>
    private async Task<RouteDataResponse?> SendRequestAsync(string origins, string destination)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = CollectApiUri(origins, destination)
        };

        using var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<RouteDataResponse>(new JsonSerializerOptions()
        {
            PropertyNamingPolicy = SnakeCaseConvertingPolicy.Instance
        });
    }
}