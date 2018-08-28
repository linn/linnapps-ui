namespace Linn.LinnappsUi.Service.Host.Pages.Products.SalesArticles
{
    using System.Linq;
    using System.Threading.Tasks;

    using Linn.Common.Persistence;
    using Linn.LinnappsUi.Domain.Products;
    using Linn.LinnappsUi.Persistence;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    public class EditCoreTypeModel : PageModel
    {
        private readonly ServiceDbContext context;

        private readonly ITransactionManager transactionManager;

        public EditCoreTypeModel(ServiceDbContext context, ITransactionManager transactionManager)
        {
            this.context = context;
            this.transactionManager = transactionManager;
        }

        [BindProperty]
        public SalesArticle SalesArticle { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            this.SalesArticle = await this.context.SalesArticle.FirstOrDefaultAsync(m => m.ArticleNumber == id);

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

            var article = await this.context.SalesArticle.FirstOrDefaultAsync(m => m.ArticleNumber == this.SalesArticle.ArticleNumber);
            var coreType = await this.context.SaCoreType.FirstOrDefaultAsync(m => m.CoreType == this.SalesArticle.SaCoreType.CoreType);

            article.SaCoreType = coreType;
            this.transactionManager.Commit();

            return this.RedirectToPage("./Details", new { id = this.SalesArticle.ArticleNumber });
        }

        private bool SalesArticleExists(string id)
        {
            return this.context.SalesArticle.Any(e => e.ArticleNumber == id);
        }
    }
}
