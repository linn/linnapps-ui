namespace Linn.LinnappsUi.Service.Host.Pages
{
    using Linn.LinnappsUi.Domain.RemoteServices;

    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class IndexModel3 : PageModel
    {
        private readonly IThingService thingService;

        public IndexModel3(IThingService thingService)
        {
            this.thingService = thingService;
        }

        public string DisplayThing { get; set; }

        public void OnGet()
        {
            this.DisplayThing = this.thingService.GetThing();
        }
    }
}
