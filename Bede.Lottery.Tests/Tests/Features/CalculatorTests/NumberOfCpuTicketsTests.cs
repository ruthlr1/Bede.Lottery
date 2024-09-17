using Bede.Lottery.Application.Features.LotteryCalculator;

namespace Bede.Lottery.Tests.Tests.Features.CalculatorTests;

[TestClass]
public class NumberOfCpuTicketsTests
{

    [TestMethod]
    public async void Given_minimumCpuTicketsIsOneAndMaximumNumberCpuTicketsIsTen_Then_CaluclatedNumberOfCpuTicketsIsBetween_1_10()
    {
        // arrange
        LotteryCalculatorService calculatorService = new LotteryCalculatorService();

        // act
        int nCpuTickets = await calculatorService.GetNumberOfCpuTickets();

        // assert
        bool betweenRange = 1 <= nCpuTickets && nCpuTickets <= 10;
        Assert.IsTrue(betweenRange);
    }



}
