namespace Linn.LinnappsUi.Service.Host.Pages.Products.SalesArticles
{
    using System.Linq;

    using Linn.Common.Persistence;
    using Linn.LinnappsUi.Domain.Products;
    using Linn.LinnappsUi.Domain.Repositories;
    using Linn.LinnappsUi.Persistence;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class EditCoreTypeModel : PageModel
    {
        private readonly ITransactionManager transactionManager;

        private readonly ISalesArticleRepository salesArticleRepository;

        private readonly ISaCoreTypeRepository coreTypeRepository;

        public EditCoreTypeModel(
            ITransactionManager transactionManager,
            ISalesArticleRepository salesArticleRepository,
            ISaCoreTypeRepository coreTypeRepository)
        {
            this.transactionManager = transactionManager;
            this.salesArticleRepository = salesArticleRepository;
            this.coreTypeRepository = coreTypeRepository;
        }

        [BindProperty]
        public SalesArticle SalesArticle { get; set; }

        [BindProperty]
        public int? SelectedCoreType { get; set; }

        public SelectList CoreTypes { get; set; }

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

            this.CoreTypes = new SelectList(
                this.coreTypeRepository.GetCoreTypes().ToList(),
                "CoreType",
                "Description",
                this.SalesArticle.SaCoreType?.CoreType);
            return this.Page();
        }

        public IActionResult OnPost()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            var article = this.salesArticleRepository.GetByArticleNumber(this.SalesArticle.ArticleNumber);
            var coreType = this.SelectedCoreType.HasValue
                               ? this.coreTypeRepository.GetById(this.SelectedCoreType.Value)
                               : null;
            article.SaCoreType = coreType;
            this.transactionManager.Commit();

            return this.RedirectToPage("./Details", new { id = this.SalesArticle.ArticleNumber });
        }
    }
}
