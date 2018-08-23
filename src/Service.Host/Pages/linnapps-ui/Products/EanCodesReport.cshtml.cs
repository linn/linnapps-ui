namespace Linn.LinnappsUi.Service.Host.Pages.Products
{
    using System.Collections.Generic;

    using Linn.LinnappsUi.Domain.ReportModels;
    using Linn.LinnappsUi.Domain.Reports;
    using Linn.LinnappsUi.Domain.Reports.Helpers;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class EanCodesReportModel : PageModel
    {
        private readonly IEanCodeReportService reportService;

        private readonly ICsvCreator csvCreator;

        public EanCodesReportModel(IEanCodeReportService reportService, ICsvCreator csvCreator)
        {
            this.reportService = reportService;
            this.csvCreator = csvCreator;
        }

        public IEnumerable<EanCodeReport> ReportData { get; set; } = new List<EanCodeReport>();

        public bool IncludePhasedOut { get; set; }

        public bool CartonisedOnly { get; set; } = true;

        public void OnPost(bool includePhasedOut, bool cartonisedOnly)
        {
            this.ReportData = this.reportService.GetEanCodeReport(includePhasedOut, cartonisedOnly);
        }

        public ActionResult OnPostDownloadFile(bool includePhasedOut, bool cartonisedOnly)
        {
            this.ReportData = this.reportService.GetEanCodeReport(includePhasedOut, cartonisedOnly);

            return this.File(this.csvCreator.CreateCsv(this.ReportData), "application/octet-stream", "EanCodes.csv");
        }
    }
}