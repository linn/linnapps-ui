namespace Linn.LinnappsUi.Proxy
{
    using Linn.LinnappsUi.Domain.RemoteServices;

    public class ThingProxy : IThingService
    {
        public string GetThing()
        {
            return "Got a Thing from Linnapps";
        }
    }
}
