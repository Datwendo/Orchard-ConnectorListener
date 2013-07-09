using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;
using System.ComponentModel.DataAnnotations;
using Orchard.Environment.Extensions;
using System.Web.Mvc;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Mvc.Html;
using Orchard.Services;
using Orchard.ContentManagement.Aspects;
using Orchard.Core.Title.Models;


namespace Datwendo.ConnectorListener.Models
{
    [OrchardFeature("Datwendo.ConnectorListener")]
    public class SubscriberPart : ContentPart<SubscriberPartRecord>
    {
        public int PublisherId
        {
            get { return Record.PublisherId; }
            set { Record.PublisherId = value; }
        }
        public int SubscriberId
        {
            get { return Record.SubscriberId; }
            set { Record.SubscriberId = value; }
        }
        
        public int ConnectorId
        {
            get { return Record.ConnectorId; }
            set { Record.ConnectorId = value; }
        }

        public string ContentTypeName
        {
            get { return Record.ContentTypeName; }
            set { Record.ContentTypeName = value; }
        }

        public bool TriggerWorkflow
        {
            get { return Record.TriggerWorkflow; }
            set { Record.TriggerWorkflow = value; }
        }
    }
}
