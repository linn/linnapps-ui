namespace Linn.LinnappsUi.Service.Host.Pages.Products.SalesArticles
{
    using System.Linq;
    using System.Threading.Tasks;

    using Linn.LinnappsUi.Domain.Products;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    public class EditCoreTypeModel : PageModel
    {
        private readonly Linn.LinnappsUi.Persistence.ServiceDbContext _context;

        public EditCoreTypeModel(Linn.LinnappsUi.Persistence.ServiceDbContext context)
        {
            this._context = context;
        }

        [BindProperty]
        public SalesArticle SalesArticle { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            this.SalesArticle = await this._context.SalesArticle.FirstOrDefaultAsync(m => m.ArticleNumber == id);

            if (this.SalesArticle == null)
            {
                return this.NotFound();
            }
            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            var article = await this._context.SalesArticle.FirstOrDefaultAsync(m => m.ArticleNumber == this.SalesArticle.ArticleNumber);
            var coreType = await this._context.SaCoreType.FirstOrDefaultAsync(m => m.CoreType == this.SalesArticle.SaCoreType.CoreType);

            article.SaCoreType = coreType;

            try
            {
                var article2 = await this._context.SalesArticle.FirstOrDefaultAsync(m => m.ArticleNumber == this.SalesArticle.ArticleNumber);
                await this._context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.SalesArticleExists(this.SalesArticle.ArticleNumber))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.RedirectToPage("./Details", new { id = this.SalesArticle.ArticleNumber });
        }

        private bool SalesArticleExists(string id)
        {
            return this._context.SalesArticle.Any(e => e.ArticleNumber == id);
        }
    }
}
