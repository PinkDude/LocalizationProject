using System.Globalization;
using LocalizationProject.Domain.Interfaces;

namespace LocalizationProject.BL.Sources;

public class InMemorySource : ISource
{
    private readonly IDictionary<string, string> _source;

    public InMemorySource(IDictionary<string, string> source)
    {
        _source = source;
    }
    
    public Task<string?> TryGetString(string code, CultureInfo cultureInfo)
    {
        var key = $"{cultureInfo.Name}.{code}";
        var isFinded = _source.TryGetValue(key, out var resultStr);
        return Task.FromResult(resultStr);
    }
}