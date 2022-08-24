namespace FuelCalculator.Application;

public interface IFuelWeightCalculatorService
{
    public Task<double> GetFuelWeightAsync(string origins, string destination, string fuelType, double fuelСonsumption);
}