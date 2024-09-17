using Bede.Lottery.Application.Features.ConfigSettings;

namespace Bede.Lottery.Application.Features.LotteryFactory;

public class LotteryFactoryArgs : ConfigModel
{
    public LotteryFactoryArgs(ConfigModel config)
    {
        base.PlayerBalance = config.PlayerBalance;
        base.TicketCost = config.TicketCost;

        base.MinNumberOfPlayers = config.MinNumberOfPlayers;
        base.MaxNumberOfPlayers = config.MaxNumberOfPlayers;
    }
    public int UserNumberOfTickets { get; set; }
    public int NumberOfOtherPlayers { get; set; }
}
