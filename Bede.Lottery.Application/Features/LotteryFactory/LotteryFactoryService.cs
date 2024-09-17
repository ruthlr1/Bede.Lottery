using Bede.Lottery.Application.Features.LotteryCalculator;
using Bede.Lottery.Domain.Entities;

namespace Bede.Lottery.Application.Features.LotteryFactory;

public class LotteryFactoryService : ILotteryFactoryService
{

    private readonly ILotteryCalculatorService _lotteryCalculator;
    public LotteryFactoryService(ILotteryCalculatorService lotteryCalculator)
    {
        _lotteryCalculator = lotteryCalculator;
    }

    public async Task<List<Player>> AssignTicketsToPlayers(LotteryFactoryArgs args)
    {
        var totalPlayers = await _lotteryCalculator.GetNumberOfPlayers(args.MinNumberOfPlayers, args.MaxNumberOfPlayers);

        List<Player> players = new List<Player>();
        Player player = new Player(1);
        player.AssignTickets(1, args.UserNumberOfTickets);
        players.Add(player);

        for (var i = 2; i <= totalPlayers; i++)
        {
            int nextTicketNumber = 0;
            if (players.Any())
                nextTicketNumber = players.SelectMany(x => x.TicketNumbers).Max();

            nextTicketNumber++;

            player = new Player(i);
            var totalCpuTickets = await _lotteryCalculator.GetNumberOfCpuTickets();
            player.AssignTickets(nextTicketNumber, totalCpuTickets);
            players.Add(player);
        }

        return players;
    }

    public async Task<ResultsModel> GetGameResults(LotteryFactoryArgs args)
    {
        ResultsModel results = new ResultsModel();

        var gamePlayers = await AssignTicketsToPlayers(args);
        int maxTickets = gamePlayers.SelectMany(x => x.TicketNumbers).Max();

        decimal totalRevenue = maxTickets * args.TicketCost;

        // grand prize
        results.Winners.AddRange(DrawWinners(results.Winners, maxTickets, totalRevenue, PrizeType.PrizeTypeIndex.GrandPrice, 1, 50, gamePlayers));

        // second Tier
        var secondTierTickets = (int)Math.Round(maxTickets * 0.1M); // 10% of tickets
        results.Winners.AddRange(DrawWinners(results.Winners, maxTickets, totalRevenue, PrizeType.PrizeTypeIndex.SecondTier, secondTierTickets, 30, gamePlayers));

        // third Tier
        var thirdTierTickets = (int)Math.Round(maxTickets * 0.2M); // 20% of tickets
        results.Winners.AddRange(DrawWinners(results.Winners, maxTickets, totalRevenue, PrizeType.PrizeTypeIndex.ThirdTier, thirdTierTickets, 10, gamePlayers));

        // house winnings is the remaining balance
        results.HouseWinnings = totalRevenue - results.Winners.Sum(x => x.Winnings);

        results.TotalTicketsSold = gamePlayers.SelectMany(x => x.TicketNumbers).Count();

        return results;
    }

    public List<PrizeTypeToPlayer> DrawWinners(List<PrizeTypeToPlayer> currentWinners, int maxTickets, decimal totalRevenue, PrizeType.PrizeTypeIndex prizeType, int totalWinners, int percentOfWinnings, List<Player> gamePlayers)
    {
        Random random = new Random();
        List<PrizeTypeToPlayer> winners = new List<PrizeTypeToPlayer>();
        var individualRevenue = _lotteryCalculator.CalculateIndividualRevenue(totalRevenue, totalWinners, percentOfWinnings);

        for (int i = 0; i < totalWinners; i++)
        {
            var winner = new PrizeTypeToPlayer();
            winner.PrizeType = prizeType;
            bool drawnTicket = true;
            while (drawnTicket)
            {
                winner.TicketNumber = random.Next(1, maxTickets);
                drawnTicket = currentWinners.Any(x => x.TicketNumber == winner.TicketNumber);
            }

            winner.Player = gamePlayers.Where(x => x.TicketNumbers.Contains(winner.TicketNumber)).First();
            winner.Winnings = individualRevenue;
            winners.Add(winner);
        }

        return winners;
    }

}
