using System.Globalization;

namespace LocalizationProject.Domain.Interfaces;

public interface ISource
{
    Task<string?> TryGetString(string code, CultureInfo cultureInfo);
}