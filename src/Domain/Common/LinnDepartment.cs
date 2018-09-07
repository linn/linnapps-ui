namespace Linn.LinnappsUi.Domain.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class LinnDepartment
    {
        [Display(Name = "Code")]
        [Key]
        public string DepartmentCode { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Personnel Dept")]
        public string PersonnelDept { get; set; }

        [Display(Name = "Date Closed")]
        [DataType(DataType.Date)]
        public DateTime? DateClosed { get; set; }

        public List<Cit> Cits { get; set; }
    }
}