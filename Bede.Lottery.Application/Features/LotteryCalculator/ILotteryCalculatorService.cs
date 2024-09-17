namespace Bede.Lottery.Application.Features.LotteryCalculator;

public interface ILotteryCalculatorService
{
    Task<int> GetNumberOfPlayers(int minimumNoPlayers, int maximumNoPlayers);
    Task<int> GetNumberOfCpuTickets();
    Task<decimal> TotalTicketPrice(int noTickets, decimal ticketPrice);
    decimal CalculateIndividualRevenue(decimal totalRevenue,int totalWinners, int percentWinnings);
    Task<bool> PlayerHasBalance(decimal currentBalance, decimal totalTicketCost);

}
