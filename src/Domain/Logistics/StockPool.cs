namespace Linn.LinnappsUi.Domain.Logistics
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class StockPool
    {
        public int Id { get; set; }

        [Display(Name = "Bridge Id")]
        public int BridgeId { get; set; }

        [Display(Name = "Code")]
        public string StockPoolCode { get; set; }

        [Display(Name = "Description")]
        public string StockPoolDescription { get; set; }

        [Display(Name = "Date Invalid")]
        [DataType(DataType.Date)]
        public DateTime? DateInvalid { get; set; }

        [Display(Name = "Accounting Company")]
        public string AccountingCompany { get; set; }

        [Display(Name = "Sequence")]
        public int Sequence { get; set; }

        [Display(Name = "Stock Category")]
        public string StockCategory { get; set; }

        [Display(Name = "Default Location")]
        public int? DefaultLocation { get; set; }
    }
}
