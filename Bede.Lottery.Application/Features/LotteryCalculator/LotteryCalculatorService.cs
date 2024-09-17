namespace Bede.Lottery.Application.Features.LotteryCalculator;

public class LotteryCalculatorService : ILotteryCalculatorService
{
    public const int MinNumberTickets = 1;
    public const int MaxNumberTickets = 10;

    public Task<int> GetNumberOfCpuTickets()
    {
        Random rnd = new Random();
        int nTotalTickets = rnd.Next(MinNumberTickets, MaxNumberTickets);
        return Task.FromResult(nTotalTickets);
    }

    public Task<int> GetNumberOfPlayers(int minimumNoPlayers, int maximumNoPlayers)
    {
        Random rnd = new Random();
        int nPlayers = rnd.Next(minimumNoPlayers, maximumNoPlayers);
        return Task.FromResult(nPlayers);
    }


    public Task<decimal> TotalTicketPrice(int noTickets, decimal ticketPrice)
    {
        return Task.FromResult(noTickets * ticketPrice);
    }

    public decimal CalculateIndividualRevenue(decimal totalRevenue, int totalWinners, int percentWinnings)
    {
        return Math.Round(totalRevenue * ((decimal)percentWinnings / 100) / totalWinners, 2);
    }

    public Task<bool> PlayerHasBalance(decimal currentBalance, decimal totalTicketCost)
    {
        return Task.FromResult(currentBalance >= totalTicketCost);
    }
}
