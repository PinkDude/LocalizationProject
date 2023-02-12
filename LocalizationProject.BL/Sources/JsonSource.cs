using System.Globalization;
using System.Text.Json.Serialization;
using LocalizationProject.Domain.Interfaces;
using Newtonsoft.Json;

namespace LocalizationProject.BL.Sources;

public class JsonSource: ISource
{
    private readonly string _path;
    
    public JsonSource(string path)
    {
        _path = path;
    }
    
    public async Task<string?> TryGetString(string code, CultureInfo cultureInfo)
    {
        var file = await File.ReadAllTextAsync(_path);
        var dictionary = JsonConvert.DeserializeObject<Dictionary<string,string>>(file);

        var key = $"{cultureInfo.Name}.{code}";
        return dictionary.TryGetValue(key, out var str) ? str : null;
    }
}