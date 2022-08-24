namespace DistanceMatrixApi.Models.RouteDataResponse;

public class RouteDataResponse : AbstractEntity
{
    public IEnumerable<string>? DestinationAddresses { get; set; }
    public IEnumerable<string>? OriginAddresses { get; set; }
    public IEnumerable<RowModel>? Rows { get; set; }
    public string? Status { get; set; }
    public string? ErrorMessage { get; set; }
}