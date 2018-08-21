namespace Linn.LinnappsUi.Domain.RemoteServices
{
    using System.Collections.Generic;

    using Linn.LinnappsUi.Domain.Logistics;

    public interface IStockPoolService
    {
        StockPool GetStockPool(int id);

        IEnumerable<StockPool> GetStockPools();
    }
}
