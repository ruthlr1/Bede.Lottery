// See https://aka.ms/new-console-template for more information
using Bede.Lottery.App;
using Bede.Lottery.Application.Extensions;
using Bede.Lottery.Application.Features.ConfigSettings;
using Bede.Lottery.Application.Features.LotteryCalculator;
using Bede.Lottery.Application.Features.LotteryFactory;
using Bede.Lottery.Application.Validation;

DependencyInjection di = new DependencyInjection(args);

ConfigModel? config = await di.LoadSettings();
if (config == null)
    return;

LotteryFactoryArgs lotteryFactoryArgs = new LotteryFactoryArgs(config!);
while(true)// keep console running
{
    Console.WriteLine($"Player 1 remaining balance: {lotteryFactoryArgs.PlayerBalance.ToCurrency()}");
    Console.WriteLine("How many tickets would you like to buy, Player 1?");

    string? inputText = Console.ReadLine();
    int? inputIntTickets = UiInputValidation.ValidateInputNumberOfTickets(inputText);
    if(!inputIntTickets.HasValue)
    {
        Console.WriteLine("Please enter a valid number");
        Console.WriteLine();
        continue;
    }

    if(!UiInputValidation.InputNumberIsWithinValidRange(inputIntTickets.GetValueOrDefault()))
    {
        Console.WriteLine($"Players can only buy between {LotteryCalculatorService.MinNumberTickets} and {LotteryCalculatorService.MaxNumberTickets} tickets to play.");
        Console.WriteLine();
        continue;
    }

    lotteryFactoryArgs.UserNumberOfTickets = inputIntTickets.GetValueOrDefault();

    var totalTicketAmount = await di.TotalTicketPrice(lotteryFactoryArgs.UserNumberOfTickets, lotteryFactoryArgs.TicketCost);

    var canPurchase = await di.PlayerHasBalance(lotteryFactoryArgs.PlayerBalance, totalTicketAmount);
    if(canPurchase)
    {
        lotteryFactoryArgs.PlayerBalance -= totalTicketAmount;
    }
    else
    {
        Console.WriteLine("Sorry insufficient funds to purchase tickets");
        Console.WriteLine($"Current Balance: {lotteryFactoryArgs.PlayerBalance.ToCurrency()}, Required total ticket price: {totalTicketAmount.ToCurrency()}");
        Console.WriteLine();
        continue;
    }

    lotteryFactoryArgs.NumberOfOtherPlayers = await di.GetTotalOtherPlayers(lotteryFactoryArgs);

    Console.WriteLine();
    Console.WriteLine($"{lotteryFactoryArgs.NumberOfOtherPlayers} other CPU players also have purchased tickets.");

    var results = await di.GetResults(lotteryFactoryArgs);

    Console.WriteLine($"Total tickets sold: {results.TotalTicketsSold}");
    Console.WriteLine();
    Console.WriteLine("Ticket Draw Results");
    foreach (var msg in results.ToDisplay())
    {
        Console.WriteLine($"* {msg}");
    }

    Console.WriteLine();
    Console.WriteLine($"Player 1 winnings: {results.Player1Winnings.ToCurrency()}");
    Console.WriteLine();
    Console.WriteLine("Congratulations to all the winners");
    Console.WriteLine($"House Revenue: {results.HouseWinnings.ToCurrency()}");
    Console.WriteLine();
    Console.WriteLine();

    lotteryFactoryArgs.PlayerBalance += results.Player1Winnings;
}