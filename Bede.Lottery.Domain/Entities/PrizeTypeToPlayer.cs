namespace Bede.Lottery.Domain.Entities;

public class PrizeTypeToPlayer
{
    public PrizeType.PrizeTypeIndex PrizeType { get; set; }
    public Player Player { get; set; } = null!;
    public int TicketNumber { get; set; }
    public decimal Winnings { get; set; }

}
