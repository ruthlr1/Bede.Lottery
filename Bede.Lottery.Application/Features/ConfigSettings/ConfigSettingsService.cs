using System.Text.Json;

namespace Bede.Lottery.Application.Features.ConfigSettings;

public class ConfigSettingsService : IConfigSettingsService
{

    public Task<ConfigModel?> LoadSettings()
    {
        try
        {
            string pathToSettings = Path.Combine(Environment.CurrentDirectory, "AppSettings.json");
            string txtConfig = File.ReadAllText(pathToSettings);
            return Task.FromResult(JsonSerializer.Deserialize<ConfigModel>(txtConfig));
        }
        catch (Exception)
        {
            return Task.FromResult<ConfigModel?>(null);
        }
    }
}
