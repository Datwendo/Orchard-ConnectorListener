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
    public class NotificationPartRecord: ContentPartRecord 
    {
        public virtual int PublisherId { get; set; }
        public virtual int CounterId { get; set; }
        public virtual int SubscriberId { get; set; }
        public virtual string SecretKey { get; set; }
        public virtual int StateCode { get; set; }
        public virtual int IdxVal { get; set; }
        public virtual int DataType { get; set; }
    }

}
