namespace Linn.LinnappsUi.Service.Host.Pages
{
    using Linn.Common.Logging;
    using Linn.LinnappsUi.Domain.RemoteServices;

    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class IndexModel2 : PageModel
    {
        private readonly ILog log;

        private readonly IThingService thingService;

        public IndexModel2(ILog log, IThingService thingService)
        {
            this.log = log;
            this.thingService = thingService;
        }

        public string DisplayThing { get; set; }

        public void OnGet()
        {
            this.log.Debug("Looked at index");

            this.DisplayThing = this.thingService.GetThing();
        }
    }
}
