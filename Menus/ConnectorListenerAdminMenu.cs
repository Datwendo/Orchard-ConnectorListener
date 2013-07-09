using System.Web.Routing;
using Orchard.Environment;
using Orchard.Localization;
using Orchard.UI.Navigation;
using Orchard.Environment.Extensions;



namespace Datwendo.Commerce.Menus
{
    [OrchardFeature("Datwendo.ConnectorListener")]
    public class ConnectorListenerAdminMenu : INavigationProvider
    {
        private readonly Work<RequestContext> _requestContextAccessor;

        public string MenuName {
            get { return "admin"; }
        }

        public ConnectorListenerAdminMenu(Work<RequestContext> requestContextAccessor)
        {
            _requestContextAccessor = requestContextAccessor;
            T                       = NullLocalizer.Instance;
        }

        private Localizer T { get; set; }

        public void GetNavigation(NavigationBuilder builder) {
            var requestContext  = _requestContextAccessor.Value;
            var idValue         = (string)requestContext.RouteData.Values["id"];
            var id              = 0;

            if (!string.IsNullOrEmpty(idValue))
            {
                int.TryParse(idValue, out id);
            }

            builder
                .AddImageSet("datwendo-connector-listener")
                .Add(item => item
                    .Caption(T("Connector Listener"))
                    .Position("5")
                    .LinkToFirstChild(true)

                    .Add(subItem => subItem
                        .Caption(T("Subscribers"))
                        .Position("3.7")
                        .Action("Index", "ConnectorListenerAdmin", new { area = "Datwendo.ConnectorListener" })
                        .Add(T("Index"), i => i.Action("Index", "ConnectorListenerAdmin", new { area = "Datwendo.ConnectorListener" }).LocalNav())
                        .Add(T("Notifications"), i => i.Action("Notifications", "ConnectorListenerAdmin", new { id }).LocalNav())
                    )
                );
        }
    }
}