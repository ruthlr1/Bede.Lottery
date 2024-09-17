using Bede.Lottery.Application.Validation;

namespace Bede.Lottery.Tests.Tests.Validation;

[TestClass]
public class UiValidatorTests
{
    [TestMethod]
    public void Input_text_is_empty_Then_returns_null()
    {
        // arrange and act
        var result = UiInputValidation.ValidateInputNumberOfTickets("");

        // assert 
        Assert.IsNull(result);
    }

    [TestMethod]
    public void Input_text_is_not_number_Then_returns_null()
    {
        // arrange and act
        var result = UiInputValidation.ValidateInputNumberOfTickets("sadsda");

        // assert 
        Assert.IsNull(result);
    }

    [TestMethod]
    public void Input_text_is_integer_5_Then_returns_5()
    {
        // arrange and act
        var result = UiInputValidation.ValidateInputNumberOfTickets("5");

        // assert 
        Assert.AreEqual(5,result);
    }

    [TestMethod]
    public void Input_text_is_decimal_5_dot_6_Then_returns_null()
    {
        // arrange and act
        var result = UiInputValidation.ValidateInputNumberOfTickets("5.6");

        // assert 
        Assert.IsNull(result);
    }

    [TestMethod]
    public void Input_number_is_between_1_and_10_Then_returns_true()
    {
        // todo: this test is subject to change. If the constants involved change then this test will fail. 
        // This test is based on range 1-10

        // arrange and act
        var result = UiInputValidation.InputNumberIsWithinValidRange(7);

        // assert 
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Input_number_is_not_between_1_and_10_Then_returns_false()
    {
        // todo: this test is subject to change. If the constants involved change then this test will fail. 
        // This test is based on range 1-10

        // arrange and act
        var result = UiInputValidation.InputNumberIsWithinValidRange(11);

        // assert 
        Assert.IsFalse(result);
    }
}
