using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace TheSecretSanta.Infrastructure.Mappings;

public class DictionaryConverter : ValueConverter<Dictionary<string, object>, string>
{
    public DictionaryConverter() :
        base(
        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
        v => JsonSerializer.Deserialize<Dictionary<string, object>>(v, (JsonSerializerOptions)null))
    {
    }
}
