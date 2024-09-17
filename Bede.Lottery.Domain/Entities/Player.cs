
namespace Bede.Lottery.Domain.Entities;

public class Player
{
    public Player(int playerId)
    {
        PlayerId = playerId;
    }
    public int PlayerId { get; set; }
    public string PlayerName => $"Player {PlayerId}";
    public List<int> TicketNumbers { get; set; } = new List<int>();

    public void AssignTickets(int nextTicketNumber, int totalTickets)
    {
        int currentTicket = nextTicketNumber;
        int ticketIndex = 0;
        while (ticketIndex < totalTickets) 
        {
            TicketNumbers.Add(currentTicket);
            currentTicket++;
            ticketIndex++;
        }
    }
}
