using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Orchard.Localization;
using Orchard;
using Orchard.Mvc;
using Datwendo.ConnectorListener.Models;
using Orchard.DisplayManagement;
using Orchard.ContentManagement;
using Orchard.Environment.Extensions;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

using Orchard.WebApi.Extensions;
using Orchard.Workflows.Services;
using Orchard.Core.Common.Models;


namespace Datwendo.ConnectorListener.Controllers.Api {
    [OrchardFeature("Datwendo.ConnectorListener")]
    public class CCListenerController : ApiController
    {
        public IOrchardServices Services { get; set; }
        private readonly IWorkflowManager _workflowManager;

        public CCListenerController(IOrchardServices services, IWorkflowManager workflowManager) 
        {
            Services            = services;
            _workflowManager    = workflowManager;
        }

        public HttpResponseMessage Post(int Id,PbRequest CReq)
        {
            if (this.ModelState.IsValid)
            {
                // Should be better in Async task ??? but what compat with Orchard
                // get the ConnectorListener
                var subs = Services.ContentManager.Query<SubscriberPart, SubscriberPartRecord>().Where(s => s.SubscriberId == Id && s.PublisherId == CReq.Pb && s.ConnectorId == CReq.Cc).List().FirstOrDefault();
                ContentItem newContent              = null;                
                if (subs != null)
                {
                    if (!string.IsNullOrEmpty(subs.ContentTypeName))
                    {

                        if (string.Equals(subs.ContentTypeName, "ConnectorNotification", StringComparison.OrdinalIgnoreCase))
                        {
                            newContent              = Services.ContentManager.New("ConnectorNotification");
                        }
                        else
                        {
                            newContent              = Services.ContentManager.New(subs.ContentTypeName); 
                        }
                        if (newContent != null ) 
                        {
                            var notif               =  newContent.As<NotificationPart>();
                            if ( notif != null )
                            {
                                notif.CounterId     = CReq.Cc;
                                notif.PublisherId   = CReq.Pb;
                                notif.SubscriberId  = Id;
                                notif.StateCode     = CReq.Cd;
                                notif.IdxVal        = CReq.Vl;
                                notif.SecretKey     = CReq.Ky;
                            }
                            else
                            {
                                    // TBD -> "Identifier", 
                            }
                           Services.ContentManager.Create(newContent);
                        }
                    }
                    if ( subs.TriggerWorkflow )
                        _workflowManager.TriggerEvent("ConnectorPublished", subs, () => new Dictionary<string, object> { {"Request", CReq},{ "NewContent", newContent } });
                }
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}
