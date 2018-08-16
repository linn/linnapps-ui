namespace Linn.LinnappsUi.Domain.Products
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SaCoreType
    {
        [Key]
        [Display(Name = "Core Type")]
        public int CoreType { get; set; }

        public string Description { get; set; }

        [Display(Name = "Date Invalid")]
        [DataType(DataType.Date)]
        public DateTime? DateInvalid { get; set; }

        [Display(Name = "Insert Type")]
        public string InsertType { get; set; }

        [Display(Name = "Trigger Level")]
        public int? TriggerLevel { get; set; }

        [Display(Name = "Lookahead Days")]
        public int? LookaheadDays { get; set; }

        [Display(Name = "Sort Order")]
        public int? SortOrder { get; set; }
    }
}
