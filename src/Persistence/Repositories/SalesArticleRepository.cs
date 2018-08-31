namespace Linn.LinnappsUi.Persistence.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.LinnappsUi.Domain.Products;
    using Linn.LinnappsUi.Domain.Repositories;
    using Linn.LinnappsUi.Persistence;

    using Microsoft.EntityFrameworkCore;

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
                .Include(a => a.SaCoreType)
                .SingleOrDefault(s => s.ArticleNumber == articleNumber);
        }

        public IEnumerable<SalesArticle> GetByDiscountFamily(string discountFamily, bool includePhasedOut = false)
        {
            return includePhasedOut
               ? this.serviceDbContext.SalesArticle.Where(s => s.SaDiscountFamily == discountFamily)
               : this.serviceDbContext.SalesArticle.Where(s => s.SaDiscountFamily == discountFamily && s.PhaseOutDate == null);
        }

        private bool Matches(string articleNumber, string description, string[] splits)
        {
            var matchesArticleNumber = true;
            var matchesDescription = true;
            foreach (var split in splits)
            {
                matchesArticleNumber &= articleNumber.Contains(split);
                matchesDescription &= description.Contains(split);
            }

            return matchesDescription || matchesArticleNumber;
        }
    }
}