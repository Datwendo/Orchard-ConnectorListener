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
    public class NotificationPart : ContentPart<NotificationPartRecord>
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

        public string SecretKey 
        {
            get { return Record.SecretKey; }
            set { Record.SecretKey = value; }
        }
        public int StateCode 
        {
            get { return Record.StateCode; }
            set { Record.StateCode = value; }
        }

        public int CounterId 
        {
            get { return Record.CounterId; }
            set { Record.CounterId = value; }
        }

        public int IdxVal
        {
            get { return Record.IdxVal; }
            set { Record.IdxVal = value; }
        }

        public PropagateType DataType
        {
            get { return (PropagateType)Record.DataType; }
            set { Record.DataType = (int)DataType; }
        }
    }
}
