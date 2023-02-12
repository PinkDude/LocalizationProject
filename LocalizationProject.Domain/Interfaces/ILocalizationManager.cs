using System.Globalization;

namespace LocalizationProject.Domain.Interfaces;

public interface ILocalizationManager
{
    Task<string> GetString(string code, CultureInfo? cultureInfo = null);

    void RegisterSource(ISource source);
}