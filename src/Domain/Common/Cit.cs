namespace Linn.LinnappsUi.Domain.Common
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cit
    {
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "CIT Leader")]
        [ForeignKey("CIT_LEADER_USER_NUMBER")]
        public AuthUserName CitLeader { get; set; }
    }
}
