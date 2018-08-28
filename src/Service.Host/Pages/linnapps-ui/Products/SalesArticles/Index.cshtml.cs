namespace Linn.LinnappsUi.Service.Host.Pages.Products.SalesArticles
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class IndexModel : PageModel
    {
        private readonly Linn.LinnappsUi.Persistence.ServiceDbContext _context;

        public IndexModel(Linn.LinnappsUi.Persistence.ServiceDbContext context)
        {
            this._context = context;
        }

        [BindProperty]
        public string SelectedSalesArticle { get;set; }

        public IActionResult OnPostSelect()
        {
            return this.RedirectToPage("Details", new {id = this.SelectedSalesArticle });
        }
    }
}
