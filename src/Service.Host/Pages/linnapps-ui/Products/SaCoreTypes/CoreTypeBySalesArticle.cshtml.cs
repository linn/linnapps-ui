namespace Linn.LinnappsUi.Service.Host.Pages.Products.SaCoreTypes
{
    using System.Collections.Generic;

    using Linn.LinnappsUi.Domain.ReportModels;
    using Linn.LinnappsUi.Domain.Reports;

    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class CoreTypeBySalesArticleModel : PageModel
    {
        private readonly ISaCoreTypesReportService reportService;

        public CoreTypeBySalesArticleModel(ISaCoreTypesReportService reportService)
        {
            this.reportService = reportService;
        }

        public IEnumerable<SalesArticleCoreType> SalesArticleCoreTypes { get; set; }

        public void OnGet()
        {
            this.SalesArticleCoreTypes = this.reportService.GetCoreTypesBySalesArticle();
        }
    }
}