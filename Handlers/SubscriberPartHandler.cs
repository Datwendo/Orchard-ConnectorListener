using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datwendo.ConnectorListener.Models;
using Orchard.ContentManagement.Handlers;
using Orchard;
using Orchard.Environment.Extensions;
using Orchard.Localization;
using Orchard.Logging;
using Orchard.Data;

using Orchard.ContentManagement;
using Orchard.Core.Common.Models;


namespace Datwendo.ConnectorListener.Handlers
{
    [OrchardFeature("Datwendo.ConnectorListener")]
    public class SubscriberPartHandler : ContentHandler {

        public Localizer T { get; set; }

        public SubscriberPartHandler(IRepository<SubscriberPartRecord> repository)
        {            
            T               = NullLocalizer.Instance;
            Filters.Add(StorageFilter.For(repository));
        }
    }
}