namespace Linn.LinnappsUi.Service.Host.Pages.Products.SalesArticles
{
    using System.Linq;

    using Linn.LinnappsUi.Domain.RemoteServices;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class SalesArticleSearchModel : PageModel
    {
        private readonly ISalesArticleService salesArticleService;

        public SalesArticleSearchModel(ISalesArticleService salesArticleService)
        {
            this.salesArticleService = salesArticleService;
        }

        public JsonResult OnGet(string searchTerm)
        {
            var result = this.salesArticleService.Search(searchTerm);
            return new JsonResult(result
                .Take(20)
                .Select(s => new { value = s.ArticleNumber, label = $"{s.ArticleNumber} - {s.InvoiceDescription}" }));
        }
    }
}