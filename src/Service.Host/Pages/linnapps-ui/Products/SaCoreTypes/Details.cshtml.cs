namespace Linn.LinnappsUi.Service.Host.Pages.Products.SaCoreTypes
{
    using System.Threading.Tasks;

    using Linn.LinnappsUi.Domain.Products;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    public class DetailsModel : PageModel
    {
        private readonly Linn.LinnappsUi.Persistence.ServiceDbContext context;

        public DetailsModel(Linn.LinnappsUi.Persistence.ServiceDbContext context)
        {
            this.context = context;
        }

        public SaCoreType SaCoreType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            this.SaCoreType = await this.context.SaCoreType.FirstOrDefaultAsync(m => m.CoreType == id);

            if (this.SaCoreType == null)
            {
                return this.NotFound();
            }

            return this.Page();
        }
    }
}
