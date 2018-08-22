namespace Linn.LinnappsUi.Service.Reports
{
    using System.Collections.Generic;

    using Linn.LinnappsUi.Domain.ReportModels;
    using Linn.LinnappsUi.Domain.Reports;
    using Linn.LinnappsUi.Domain.Repositories;

    public class EanCodeReportService : IEanCodeReportService
    {
        private readonly ISalesArticleRepository salesArticleRepository;

        public EanCodeReportService(ISalesArticleRepository salesArticleRepository)
        {
            this.salesArticleRepository = salesArticleRepository;
        }

        public IEnumerable<EanCodeReport> GetEanCodeReport(bool includePhasedOut = false)
        {
            throw new System.NotImplementedException();
        }
    }
}
