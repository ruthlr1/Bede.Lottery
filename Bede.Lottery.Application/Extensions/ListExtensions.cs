using Bede.Lottery.Domain.Entities;

namespace Bede.Lottery.Application.Extensions;

public static class ListExtensions
{
    public static string ToUniquePlayerIds(this List<PrizeTypeToPlayer> data)
    {
        return string.Join(", ", data.OrderBy(x => x.Player.PlayerId).Select(x => x.Player.PlayerId).Distinct());
    }
}
