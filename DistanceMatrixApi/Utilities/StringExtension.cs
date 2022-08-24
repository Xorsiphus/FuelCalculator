namespace DistanceMatrixApi.Utilities;

public static class StringExtension
{
    /// <summary>
    /// Алгоритм преобразования строки к SnakeCase
    /// </summary>
    /// <param name="str">Исходная строка</param>
    /// <returns>Строка в SnakeCase</returns>
    public static string ToSnakeCase(this string str) =>
        string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x)
            ? "_" + x
            : x.ToString())).ToLower();
    
    /// <summary>
    /// Запасной метод))
    /// </summary>
    public static string ToCamelCase(this string str) =>
        string.Concat(str.Split('_').ToList().Select(s =>
            char.ToUpper(s[0]) + s[1..]
        ));
}