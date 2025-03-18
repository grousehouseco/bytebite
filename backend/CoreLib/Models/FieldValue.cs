using System.Runtime.Serialization;
using System.Text.Json;

namespace CoreLib.Models;

public class FieldValue<T>
{
    public string Field { get; set; } = string.Empty;
    public T? Value { get; set; }

    public override string ToString()
    {
        var valueJson = Value is null ? "NULL" : JsonSerializer.Serialize<T>(Value);
        return $"{Field}: {valueJson}";
    }
}