namespace Linn.LinnappsUi.Service.Host.Pages
{
    using Linn.Common.Logging;

    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class IndexModel2 : PageModel
    {
        private readonly ILog log;

        public IndexModel2(ILog log)
        {
            this.log = log;
        }

        public void OnGet()
        {
            this.log.Debug("Looked at index");
        }
    }
}
