namespace Linn.LinnappsUi.Service.Host.Pages.Products
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.LinnappsUi.Domain.ReportModels;
    using Linn.LinnappsUi.Domain.Reports;

    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class EanCodesReportModel : PageModel
    {
        private readonly IEanCodeReportService reportService;

        public EanCodesReportModel(IEanCodeReportService reportService)
        {
            this.reportService = reportService;
        }

        public IEnumerable<EanCodeReport> ReportData { get; set; } = new List<EanCodeReport>();

        public bool IncludePhasedOut { get; set; }

        public bool CartonisedOnly { get; set; } = true;

        public void OnPost(bool includePhasedOut, bool cartonisedOnly)
        {
            this.ReportData = this.reportService.GetEanCodeReport(includePhasedOut, cartonisedOnly);
        }
    }
}