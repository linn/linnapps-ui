namespace Linn.LinnappsUi.Service.Host.Pages.Products.SalesArticles
{
    using System.Threading.Tasks;

    using Linn.LinnappsUi.Domain.Products;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    public class DetailsModel : PageModel
    {
        private readonly Linn.LinnappsUi.Persistence.ServiceDbContext _context;

        public DetailsModel(Linn.LinnappsUi.Persistence.ServiceDbContext context)
        {
            this._context = context;
        }

        public SalesArticle SalesArticle { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            this.SalesArticle = await this._context.SalesArticle
                                    .Include(s => s.SaCoreType)
                                    .FirstOrDefaultAsync(m => m.ArticleNumber == id);

            if (this.SalesArticle == null)
            {
                return this.NotFound();
            }

            return this.Page();
        }
    }
}
