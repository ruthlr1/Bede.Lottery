using Bede.Lottery.Domain.Entities;

namespace Bede.Lottery.Application.Features.LotteryFactory;

public interface ILotteryFactoryService
{
    Task<ResultsModel> GetGameResults(LotteryFactoryArgs args);
    Task<List<Player>> AssignTicketsToPlayers(LotteryFactoryArgs gameSettings);
    List<PrizeTypeToPlayer> DrawWinners(List<PrizeTypeToPlayer> currentWinners, int maxTickets, decimal totalRevenue, PrizeType.PrizeTypeIndex prizeType, int totalWinners, int percentOfWinnings, List<Player> gamePlayers);
    
}
