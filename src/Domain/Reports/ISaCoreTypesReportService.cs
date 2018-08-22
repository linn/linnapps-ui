namespace Linn.LinnappsUi.Domain.Reports
{
    using System.Collections.Generic;

    using Linn.LinnappsUi.Domain.ReportModels;

    public interface ISaCoreTypesReportService
    {
        IEnumerable<SalesArticleCoreType> GetCoreTypesBySalesArticle();
    }
}
