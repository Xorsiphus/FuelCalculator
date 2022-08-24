using DistanceMatrixApi.Models.RouteDataResponse;

namespace DistanceMatrixApi;

public interface IDistanceMatrixService
{
    Task<RouteDataResponse?> GetRouteInfoAsync(string origins, string destination);
    Task<int?> GetDistanceAsync(string origins, string destination);
    Task<string?> TestApi();
}