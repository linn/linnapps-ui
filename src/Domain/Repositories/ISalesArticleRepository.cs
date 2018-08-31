namespace Linn.LinnappsUi.Domain.Repositories
{
    using System.Collections.Generic;
    using Linn.LinnappsUi.Domain.Products;

    public interface ISalesArticleRepository
    {
        SalesArticle GetByArticleNumber(string articleNumber);

        IEnumerable<SalesArticle> SearchByNameAndDescription(string searchTerm);

        IEnumerable<SalesArticle> GetByDiscountFamily(string discountFamily, bool includePhasedOut = false);
    }
}
