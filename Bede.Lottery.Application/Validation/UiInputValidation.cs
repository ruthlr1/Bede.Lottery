
using Bede.Lottery.Application.Features.LotteryCalculator;

namespace Bede.Lottery.Application.Validation;

public class UiInputValidation
{
    public static int? ValidateInputNumberOfTickets(string? inputText)
    {
        if (!int.TryParse(inputText, out int noTickets))
            return null;

        else
            return noTickets;
    }

    public static bool InputNumberIsWithinValidRange(int inputNumber)
    {
        return LotteryCalculatorService.MinNumberTickets <= inputNumber && inputNumber <= LotteryCalculatorService.MaxNumberTickets;
    }


}
