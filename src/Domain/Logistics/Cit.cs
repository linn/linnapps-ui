namespace Linn.LinnappsUi.Domain.Logistics
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Cit
    {
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
