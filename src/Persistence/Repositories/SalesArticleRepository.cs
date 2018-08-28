namespace Linn.LinnappsUi.Persistence.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.LinnappsUi.Domain.Products;
    using Linn.LinnappsUi.Domain.Repositories;
    using Linn.LinnappsUi.Persistence;

    public class SalesArticleRepository : ISalesArticleRepository
    {
        private readonly ServiceDbContext serviceDbContext;

        public SalesArticleRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public SalesArticle GetByArticleNumber(string articleNumber)
        {
            return this.serviceDbContext.SalesArticle
                .SingleOrDefault(s => s.ArticleNumber == articleNumber);
        }

        public IEnumerable<SalesArticle> SearchByNameAndDescription(string searchTerm)
        {
            return this.serviceDbContext.SalesArticle
                .Where(s => s.ArticleNumber.Contains(searchTerm) || s.InvoiceDescription.Contains(searchTerm));
        }

        public IEnumerable<SalesArticle> GetByDiscountFamily(string discountFamily, bool includePhasedOut = false)
        {
            return includePhasedOut
               ? this.serviceDbContext.SalesArticle.Where(s => s.SaDiscountFamily == discountFamily)
               : this.serviceDbContext.SalesArticle.Where(s => s.SaDiscountFamily == discountFamily && s.PhaseOutDate == null);
        }
    }
}