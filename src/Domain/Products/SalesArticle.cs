namespace Linn.LinnappsUi.Domain.Products
{
    using System;

    public class SalesArticle
    {
        public string ArticleNumber { get; set; }

        public string TypeOfSale { get; set; }

        public string InvoiceDescription { get; set; }

        public string EanCode { get; set; }

        public string PackingDescription { get; set; }

        public string SaDiscountFamily { get; set; }

        public DateTime? PhaseInDate { get; set; }

        public DateTime? PhaseOutDate { get; set; }
    }
}
