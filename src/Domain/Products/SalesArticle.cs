namespace Linn.LinnappsUi.Domain.Products
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

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

        public string CartonType { get; set; }

        [ForeignKey("SA_CORE_TYPE")]
        public SaCoreType SaCoreType { get; set; }
    }
}
