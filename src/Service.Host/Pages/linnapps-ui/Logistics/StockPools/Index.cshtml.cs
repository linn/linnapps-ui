namespace Linn.LinnappsUi.Service.Host.Pages.Logistics.StockPools
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.LinnappsUi.Domain.Logistics;
    using Linn.LinnappsUi.Domain.RemoteServices;

    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class IndexModel : PageModel
    {
        private readonly IStockPoolService stockPoolService;

        public IndexModel(IStockPoolService stockPoolService)
        {
            this.stockPoolService = stockPoolService;
        }

        public IList<StockPool> StockPools { get; set; }

        public void OnGet()
        {
            this.StockPools = this.stockPoolService.GetStockPools().OrderBy(b => b.StockPoolCode).ToList();
        }
    }
}
