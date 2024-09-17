namespace Bede.Lottery.Application.Extensions;

public static class NumberExtensions
{
    public static string ToCurrency(this decimal number)
    {
        return number.ToString("C");
    }
}
