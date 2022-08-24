using FuelCalculator.Application;
using Microsoft.AspNetCore.Mvc;

namespace FuelCalculator.Controllers;

[ApiController]
[Route("[controller]")]
public class FuelCalculatorController : ControllerBase
{
    private readonly ILogger<FuelCalculatorController> _logger;
    private readonly IFuelWeightCalculatorService _fuelWeightCalculatorService;

    public FuelCalculatorController(ILogger<FuelCalculatorController> logger,
        IFuelWeightCalculatorService fuelWeightCalculatorService)
    {
        _logger = logger;
        _fuelWeightCalculatorService = fuelWeightCalculatorService;
    }

    [HttpGet]
    [Route("GetFuelWeight")]
    public async Task<IActionResult> GetFuelWeight([FromQuery] string origin, string destination, string fuelType,
        double fuelConsumption)
    {
        var result =
            await _fuelWeightCalculatorService.GetFuelWeightAsync(origin, destination, fuelType, fuelConsumption);
        return result > 0 ? Ok(result) : BadRequest();
    }
}