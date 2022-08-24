using DistanceMatrixApi;
using DistanceMatrixApi.ServiceImpl;
using FuelCalculator.Application.Enums;
using FuelCalculator.Application.Enums.Configuration;
using Microsoft.Extensions.Options;
using static System.Enum;

namespace FuelCalculator.Application.ServiceImpl;

public class FuelWeightCalculatorService : IFuelWeightCalculatorService
{
    private readonly IDistanceMatrixService _distanceService;

    public FuelWeightCalculatorService(IOptions<DistanceMatrixAuth> options)
    {
        _distanceService = new DistanceMatrixService(options.Value.ApiKey);
    }

    /// <summary>
    /// Метод вычисляющий вес топлива, необходимый для поездки между заданными пунктами
    /// </summary>
    /// <param name="origins">Точка отправления</param>
    /// <param name="destination">Точка прибытия</param>
    /// <param name="fuelType">Тип топлива</param>
    /// <param name="fuelСonsumption">Расход топлива на 100км</param>
    /// <returns></returns>
    public async Task<double> GetFuelWeightAsync(string origins, string destination, string fuelType,
        double fuelСonsumption)
    {
        var distance = await _distanceService.GetDistanceAsync(origins, destination);
        if (distance == null) return -1;

        if (!TryParse<FuelTypes>(fuelType, out var currentFuel))
        {
            return -1;
        }

        return Math.Round(distance.Value * ((int) currentFuel / 100000000.0) * fuelСonsumption, 2);
    }
}