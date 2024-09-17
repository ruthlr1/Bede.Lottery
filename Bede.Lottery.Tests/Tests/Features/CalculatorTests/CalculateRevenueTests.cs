using Bede.Lottery.Application.Features.LotteryCalculator;

namespace Bede.Lottery.Tests.Tests.Features.CalculatorTests;

[TestClass]
public class CalculateRevenueTests
{

    [TestMethod]
    public async void Given_buys_Six_tickets_And_Price_per_ticket_is_1_dollar_fifty_Then_Total_price_should_be_Nine()
    {
        // arrange
        LotteryCalculatorService calculatorService = new LotteryCalculatorService();

        // act
        decimal total = await calculatorService.TotalTicketPrice(6,1.5M);

        // assert
        Assert.AreEqual(9, total);
    }



}
