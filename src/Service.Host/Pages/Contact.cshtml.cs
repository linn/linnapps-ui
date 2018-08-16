namespace Linn.LinnappsUi.Service.Host.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class ContactModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            this.Message = "Your contact page.";
        }
    }
}
