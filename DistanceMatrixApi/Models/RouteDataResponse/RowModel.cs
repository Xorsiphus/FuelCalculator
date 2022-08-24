namespace DistanceMatrixApi.Models.RouteDataResponse;

public class RowModel : AbstractEntity
{
    public IEnumerable<ElementModel>? Elements { get; set; }
}