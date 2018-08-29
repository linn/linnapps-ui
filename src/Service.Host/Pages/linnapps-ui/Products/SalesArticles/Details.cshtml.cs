namespace Linn.LinnappsUi.Service.Host.Pages.Products.SalesArticles
{
    using Linn.LinnappsUi.Domain.Products;
    using Linn.LinnappsUi.Domain.Repositories;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class DetailsModel : PageModel
    {
        private readonly ISalesArticleRepository salesArticleRepository;

        public DetailsModel(ISalesArticleRepository salesArticleRepository)
        {
            this.salesArticleRepository = salesArticleRepository;
        }

        public SalesArticle SalesArticle { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            this.SalesArticle = this.salesArticleRepository.GetByArticleNumber(id);

            if (this.SalesArticle == null)
            {
                return this.NotFound();
            }

            return this.Page();
        }
    }
}
