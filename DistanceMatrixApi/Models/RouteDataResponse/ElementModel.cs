namespace DistanceMatrixApi.Models.RouteDataResponse;

public class ElementModel : AbstractEntity
{
    public Property? Distance { get; set; }
    public Property? Duration { get; set; }
    public string? Status { get; set; }
}