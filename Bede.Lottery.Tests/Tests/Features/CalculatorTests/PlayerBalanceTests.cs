using Bede.Lottery.Application.Features.LotteryCalculator;

namespace Bede.Lottery.Tests.Tests.Features.CalculatorTests;

[TestClass]
public class PlayerBalanceTests
{

    [TestMethod]
    public async void Given_PlayerHasEnoughMoneyToMakePurchase_Then_Result_Shoul_be_true()
    {
        // arrange
        LotteryCalculatorService calculatorService = new LotteryCalculatorService();

        // act
        bool canMakePurchase = await calculatorService.PlayerHasBalance(7M,6.5M);

        // assert
        Assert.IsTrue(canMakePurchase);
    }

    [TestMethod]
    public async void Given_PlayerHasInsufficientMoneyToMakePurchase_Then_Result_Shoul_be_false()
    {
        // arrange
        LotteryCalculatorService calculatorService = new LotteryCalculatorService();

        // act
        bool canMakePurchase = await calculatorService.PlayerHasBalance(6M, 6.5M);

        // assert
        Assert.IsFalse(canMakePurchase);
    }



}
