namespace Linn.LinnappsUi.Service.Host.Pages
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class HealthCheckModel : PageModel
    {
        public ActionResult OnGet()
        {
            return new OkResult();
        }
    }
}