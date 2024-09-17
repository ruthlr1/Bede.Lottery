namespace Bede.Lottery.Application.Features.ConfigSettings;

public class ConfigModel
{
    public decimal PlayerBalance { get; set; }
    public decimal TicketCost { get; set; }

    public int MinNumberOfPlayers { get; set; }
    public int MaxNumberOfPlayers { get; set; }
}
