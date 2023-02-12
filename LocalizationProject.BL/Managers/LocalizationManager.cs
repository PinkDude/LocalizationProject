using System.Globalization;
using LocalizationProject.Domain.Interfaces;

namespace LocalizationProject.BL.Managers;

public class LocalizationManager : ILocalizationManager
{
    private List<ISource> _sources = new();
    
    public async Task<string> GetString(string code, CultureInfo? cultureInfo = null)
    {
        cultureInfo ??= CultureInfo.CurrentCulture;

        foreach (var source in _sources)
        {
            var result = await source.TryGetString(code, cultureInfo);
            if (result != null)
                return result;
        }

        throw new Exception("Не удалось найти локализацию строки!");
    }

    public void RegisterSource(ISource source)
    {
        _sources.Add(source); 
    }
}