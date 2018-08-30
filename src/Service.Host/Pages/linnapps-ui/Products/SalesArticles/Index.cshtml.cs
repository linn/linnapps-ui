namespace Linn.LinnappsUi.Service.Host.Pages.Products.SalesArticles
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class IndexModel : PageModel
    {
        [BindProperty]
        public string SelectedSalesArticle { get; set; }

        public IActionResult OnPostSelect()
        {
            return this.RedirectToPage("Details", new { id = this.SelectedSalesArticle });
        }
    }
}
