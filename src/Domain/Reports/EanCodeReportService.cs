namespace Linn.LinnappsUi.Domain.Reports
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.LinnappsUi.Domain.DatabasePackages;
    using Linn.LinnappsUi.Domain.ReportModels;
    using Linn.LinnappsUi.Domain.Repositories;

    public class EanCodeReportService : IEanCodeReportService
    {
        private readonly ISalesArticleRepository salesArticleRepository;

        private readonly ISalaPack salaPack;

        public EanCodeReportService(ISalesArticleRepository salesArticleRepository, ISalaPack salaPack)
        {
            this.salesArticleRepository = salesArticleRepository;
            this.salaPack = salaPack;
        }

        public IEnumerable<EanCodeReport> GetEanCodeReport(bool includePhasedOut = false, bool cartonisedOnly = false)
        {
            var codes = this.salesArticleRepository.GetByDiscountFamily("HIFI", includePhasedOut);
            if (cartonisedOnly)
            {
                codes = codes.Where(c => !string.IsNullOrEmpty(c.CartonType));
            }

            return codes
                .OrderBy(c => c.ArticleNumber)
                .Select(c => new EanCodeReport
                                 {
                                     ArticleNumber = c.ArticleNumber,
                                     ArticleDescription = c.InvoiceDescription,
                                     EanCode = c.EanCode,
                                     PackingDescription = c.PackingDescription,
                                     LabelDescripton1 = this.salaPack.LabelDescription1(c.ArticleNumber)
                                 });
        }
    }
}
