namespace Linn.LinnappsUi.Service.Host.Pages.Products.SalesArticles
{
    using System.Linq;

    using Linn.LinnappsUi.Domain.Repositories;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class SalesArticleSearchModel : PageModel
    {
        private readonly ISalesArticleRepository salesArticleRepository;

        public SalesArticleSearchModel(ISalesArticleRepository salesArticleRepository)
        {
            this.salesArticleRepository = salesArticleRepository;
        }

        public JsonResult OnGet(string searchTerm)
        {
            var result = this.salesArticleRepository.SearchByNameAndDescription(searchTerm.ToUpper());
            return new JsonResult(result
                .Take(20)
                .Select(s => new { value = s.ArticleNumber, label = $"{s.ArticleNumber} - {s.InvoiceDescription}" }));
        }
    }
}