namespace Bede.Lottery.Application.Features.ConfigSettings;

public interface IConfigSettingsService
{
    Task<ConfigModel?> LoadSettings();
}
