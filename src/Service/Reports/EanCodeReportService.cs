namespace Linn.LinnappsUi.Service.Reports
{
    using System.Collections.Generic;

    using Linn.LinnappsUi.Domain.ReportModels;
    using Linn.LinnappsUi.Domain.Reports;

    public class EanCodeReportService : IEanCodeReportService
    {
        public IEnumerable<EanCodeReport> GetEanCodeReport(bool includePhasedOut = false)
        {
            throw new System.NotImplementedException();
        }
    }
}
