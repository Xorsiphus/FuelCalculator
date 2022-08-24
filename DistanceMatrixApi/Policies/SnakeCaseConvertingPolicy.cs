using System.Text.Json;
using DistanceMatrixApi.Utilities;

namespace DistanceMatrixApi.Policies;

public class SnakeCaseConvertingPolicy : JsonNamingPolicy
{
    public static SnakeCaseConvertingPolicy Instance { get; } = new();

    /// <summary>
    /// Конвертер имён полей к стандарту SnakeCase, получаемому от api
    /// </summary>
    /// <param name="name">Имя свойства</param>
    /// <returns>Преобразованное к SnakeCase имя свойства</returns>
    public override string ConvertName(string name)
    {
        return name.ToSnakeCase();
    }
}