using Bede.Lottery.Application.Features.LotteryCalculator;

namespace Bede.Lottery.Tests.Tests.Features.CalculatorTests;

[TestClass]
public class NumberOfPlayersTests
{

    [TestMethod]
    public async void Given_minimumPlayersIsFiveAndMaximumNumberPlayersIsNine_Then_CaluclatedNumberOfPlayersIsBetween_5_9()
    {
        // arrange
        LotteryCalculatorService calculatorService = new LotteryCalculatorService();

        // act
        int nPlayers = await calculatorService.GetNumberOfPlayers(5, 9);

        // assert
        bool betweenRange = 5 <= nPlayers && nPlayers <= 9;
        Assert.IsTrue(betweenRange);
    }



}
