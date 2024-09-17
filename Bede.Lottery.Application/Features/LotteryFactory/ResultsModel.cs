using Bede.Lottery.Application.Extensions;
using Bede.Lottery.Domain.Entities;

namespace Bede.Lottery.Application.Features.LotteryFactory;

public class ResultsModel
{
    public List<PrizeTypeToPlayer> Winners { get; set; } = new List<PrizeTypeToPlayer>();

    public int TotalTicketsSold { get; set; }
    public decimal HouseWinnings { get; set; }
    public decimal Player1Winnings => Winners.Where(x => x.Player.PlayerId == 1).Sum(x => x.Winnings);

    public List<string> ToDisplay()
    {
        var messages = new List<string>();

        var grandWinner = Winners.Where(x => x.PrizeType == PrizeType.PrizeTypeIndex.GrandPrice).FirstOrDefault();
        if (grandWinner != null)
            messages.Add($"Grand Prize: {grandWinner.Player.PlayerName} wins {grandWinner.Winnings.ToCurrency()}");

        var secondWinners = Winners.Where(x => x.PrizeType == PrizeType.PrizeTypeIndex.SecondTier).ToList();
        if (secondWinners.Any())
            messages.Add($"Second Tier: Players {secondWinners.ToUniquePlayerIds()} wins {secondWinners.First().Winnings.ToCurrency()}");

        var thirdWinners = Winners.Where(x => x.PrizeType == PrizeType.PrizeTypeIndex.ThirdTier).ToList();
        if (thirdWinners.Any())
            messages.Add($"Third Tier: Players {thirdWinners.ToUniquePlayerIds()} wins {thirdWinners.First().Winnings.ToCurrency()}");


        return messages;
    }
}
