namespace Linn.LinnappsUi.Domain.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AuthUserName {
        [Display(Name = "User Number")]
        public int UserNumber { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Date Invalid")]
        [DataType(DataType.Date)]
        public DateTime? DateInvalid { get; set; }
    }
}