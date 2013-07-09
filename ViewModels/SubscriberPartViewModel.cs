using Datwendo.ConnectorListener.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datwendo.ConnectorListener.ViewModels
{
    public class ContentTypeView
    {
        public string Name {get; set; }
        public string DisplayName {get; set; }
    }

    public class SubscriberPartViewModel
    {
        public SubscriberPart Subcriber { get; set; }
        public IEnumerable<ContentTypeView> TypeLst { get; set; }
        public int SubscriberId
        {
            get { return (Subcriber != null) ? Subcriber.SubscriberId : 0; }
            set { if (Subcriber != null) Subcriber.SubscriberId = value; }
        }

        public int PublisherId
        {
            get { return (Subcriber != null) ? Subcriber.PublisherId : 0; }
            set { if (Subcriber != null) Subcriber.PublisherId = value; }
        }

        public int ConnectorId
        {
            get { return (Subcriber != null) ? Subcriber.ConnectorId : 0; }
            set { if (Subcriber != null) Subcriber.ConnectorId = value; }
        }
        
        public string ContentTypeName
        {
            get { return (Subcriber != null) ? Subcriber.ContentTypeName : string.Empty; }
            set { if (Subcriber != null) Subcriber.ContentTypeName = value; }
        }

        public bool TriggerWorkflow
        {
            get { return (Subcriber != null) ? Subcriber.TriggerWorkflow: false; }
            set { if (Subcriber != null) Subcriber.TriggerWorkflow = value; }
        }
    }
}