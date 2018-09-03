namespace Linn.LinnappsUi.Domain.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class LinnDepartment
    {
        [Display(Name = "Code")]
        public int DepartmentCode { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Personnel Dept")]
        public string PersonnelDept { get; set; }

        [Display(Name = "Date Closed")]
        [DataType(DataType.Date)]
        public DateTime? DateClosed { get; set; }
    }
}