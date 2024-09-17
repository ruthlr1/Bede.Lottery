using Bede.Lottery.Application.Features.ConfigSettings;
using Bede.Lottery.Application.Features.LotteryCalculator;
using Bede.Lottery.Application.Features.LotteryFactory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bede.Lottery.App;

public class DependencyInjection
{
    public DependencyInjection(string[] consoleArgs)
    {
        Register(consoleArgs);
    }

    private IHost _host;
    private void Register(string[] consoleArgs)
    {
        _host =  Host.CreateDefaultBuilder(consoleArgs)
        .ConfigureServices((context, services) =>
        {
            // Register services here
            services.AddScoped<ILotteryCalculatorService, LotteryCalculatorService>();
            services.AddScoped<ILotteryFactoryService, LotteryFactoryService>();
            services.AddScoped<IConfigSettingsService, ConfigSettingsService>();
        })
        .Build();
    }

    public async Task<ResultsModel> GetResults(LotteryFactoryArgs lotteryFactoryArgs)
    {
        var myService = _host.Services.GetRequiredService<ILotteryFactoryService>();
        return await myService.GetGameResults(lotteryFactoryArgs);
    }

    public async Task<int> GetTotalOtherPlayers(LotteryFactoryArgs lotteryFactoryArgs)
    {
        var myService = _host.Services.GetRequiredService<ILotteryCalculatorService>();
        return await myService.GetNumberOfPlayers(lotteryFactoryArgs.MinNumberOfPlayers, lotteryFactoryArgs.MaxNumberOfPlayers);
    }

    public async Task<ConfigModel?> LoadSettings()
    {
        var myService = _host.Services.GetRequiredService<IConfigSettingsService>();
        return await myService.LoadSettings();
    }

    public async Task<decimal> TotalTicketPrice(int noTickets, decimal ticketPrice)
    {
        var myService = _host.Services.GetRequiredService<ILotteryCalculatorService>();
        return await myService.TotalTicketPrice(noTickets, ticketPrice);
    }

    public async Task<bool> PlayerHasBalance(decimal currenceBalance, decimal totalTicketPrice)
    {
        var myService = _host.Services.GetRequiredService<ILotteryCalculatorService>();
        return await myService.PlayerHasBalance(currenceBalance, totalTicketPrice);
    }


}
