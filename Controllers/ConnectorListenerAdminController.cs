using System.Web.Mvc;
using Orchard.Localization;
using Orchard;
using Orchard.Mvc;
using Datwendo.ConnectorListener.Models;
using Datwendo.ConnectorListener.ViewModels;
using Orchard.DisplayManagement;
using Orchard.ContentManagement;
using Orchard.Environment.Extensions;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

using Orchard.WebApi.Extensions;
using Orchard.UI.Admin;
using Orchard.Settings;
using Orchard.UI.Navigation;

namespace Datwendo.ConnectorListener.Controllers {
    [Admin]
    [OrchardFeature("Datwendo.ConnectorListener")]
    public class ConnectorListenerAdminController : Controller
    {
        private dynamic Shape { get; set; }
        private readonly ISiteService _siteService;
        private readonly IContentManager _contentManager;

        public ConnectorListenerAdminController(
                                IContentManager contentManager,
                                ISiteService siteService,
                                IShapeFactory shapeFactory) 
        {
            _contentManager = contentManager;
            _siteService    = siteService;

            Shape           = shapeFactory;
            T               = NullLocalizer.Instance;
        }


        public Localizer T { get; set; }
        
        public ActionResult Index(PagerParameters pagerParameters) 
        {
            var pager               = new Pager(_siteService.GetSiteSettings(), pagerParameters.Page, pagerParameters.PageSize);
            var subscribers         = _contentManager
                .Query<SubscriberPart>()
                .List()
                .OrderBy(p => p.PublisherId).ToList();
            var paginatedAttributes = subscribers
                                            .Skip(pager.GetStartIndex())
                                            .Take(pager.PageSize)
                                            .ToList();
            var pagerShape          = Shape.Pager(pager).TotalItemCount(subscribers.Count());
            var vm                  = new SubscriberIndexViewModel
            {
                Attributes          = paginatedAttributes,
                Pager               = pagerShape
            };

            return View(vm);
        }

        public ActionResult Notifications(int Id,int SubscriberId,PagerParameters pagerParameters) 
        {
            var pager               = new Pager(_siteService.GetSiteSettings(), pagerParameters.Page, pagerParameters.PageSize);
            var notif0s             = _contentManager
                .Query<NotificationPart>()
                .List().ToList().Where(n => n.PublisherId == Id && n.SubscriberId == SubscriberId )
                .OrderBy(n => n.SubscriberId).ToList();
            var notifs              = notif0s.Select ( n => n.ContentItem );
            var paginatedAttributes = notifs
                                            .Skip(pager.GetStartIndex())
                                            .Take(pager.PageSize)
                                            .ToList();
            var pagerShape          = Shape.Pager(pager).TotalItemCount(notifs.Count());
            var vm                  = new NotificationIndexViewModel
            {
                Attributes          = paginatedAttributes,
                Pager               = pagerShape
            };

            return View(vm);
        }
        }
}
