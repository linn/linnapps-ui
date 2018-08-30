namespace Linn.LinnappsUi.Domain.Common
{
    using System.ComponentModel.DataAnnotations;

    public class Cit
    {
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        //[Display(Name = "CIT Leader")]
        //public AuthUserName CitLeader { get; set; }
    }
}
