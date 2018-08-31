namespace Linn.LinnappsUi.Domain.RemoteServices
{
    using System.Collections.Generic;

    using Linn.LinnappsUi.Domain.Products;

    public interface ISalesArticleService
    {
        IEnumerable<SalesArticle> Search(string searchTerm);
    }
}
