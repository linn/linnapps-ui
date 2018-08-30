namespace Linn.LinnappsUi.Domain.Common
{
    using System.ComponentModel.DataAnnotations;

    public class AuthUserName {
        [Display(Name = "User Number")]
        public int UserNumber { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}