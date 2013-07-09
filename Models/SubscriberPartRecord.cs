using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Orchard.ContentManagement.Records;
using Orchard.Environment.Extensions;
using Orchard.Localization;



namespace Datwendo.ConnectorListener.Models
{
    [OrchardFeature("Datwendo.ConnectorListener")]
    public class SubscriberPartRecord: ContentPartRecord 
    {
        public virtual int PublisherId { get; set; }
        public virtual int SubscriberId { get; set; }
        public virtual int ConnectorId { get; set; }
        
        public virtual string ContentTypeName { get; set; }
        public virtual bool TriggerWorkflow { get; set; }  
    }

}
