namespace Linn.LinnappsUi.Service.Host.Pages.Products.SaCoreTypes
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Linn.LinnappsUi.Domain.Products;

    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    public class IndexModel : PageModel
    {
        private readonly Linn.LinnappsUi.Persistence.ServiceDbContext context;

        public IndexModel(Linn.LinnappsUi.Persistence.ServiceDbContext context)
        {
            this.context = context;
        }

        public IList<SaCoreType> SaCoreType { get;set; }

        public async Task OnGetAsync()
        {
            this.SaCoreType = await this.context.SaCoreType.ToListAsync();
        }
    }
}
