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
    public class NotoficationPartHandler : ContentHandler {

        public NotoficationPartHandler(IRepository<NotificationPartRecord> repository)
        {            
            Filters.Add(StorageFilter.For(repository));
        }

        protected override void GetItemMetadata(GetContentItemMetadataContext context)
        {
            var part = context.ContentItem.As<NotificationPart>();

            if ( part != null && part.IdxVal != 0  )
            {
                context.Metadata.Identity.Add("Identifier", part.IdxVal.ToString());
            }
        }
    }
}