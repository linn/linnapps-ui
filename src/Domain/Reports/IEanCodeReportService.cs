namespace Linn.LinnappsUi.Domain.Reports
{
    using System.Collections.Generic;

    using Linn.LinnappsUi.Domain.ReportModels;

    public interface IEanCodeReportService
    {
        IEnumerable<EanCodeReport> GetEanCodeReport(bool includePhasedOut = false);
    }
}
