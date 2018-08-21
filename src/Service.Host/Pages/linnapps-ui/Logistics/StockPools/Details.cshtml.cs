namespace Linn.LinnappsUi.Service.Host.Pages.Logistics.StockPools
{
    using Linn.LinnappsUi.Domain.Logistics;
    using Linn.LinnappsUi.Domain.RemoteServices;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class DetailsModel : PageModel
    {
        private readonly IStockPoolService stockPoolService;

        public DetailsModel(IStockPoolService stockPoolService)
        {
            this.stockPoolService = stockPoolService;
        }

        public StockPool stockPool { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            this.stockPool = this.stockPoolService.GetStockPool(id.Value);

            if (this.stockPool == null)
            {
                return this.NotFound();
            }

            return this.Page();
        }
    }
}
