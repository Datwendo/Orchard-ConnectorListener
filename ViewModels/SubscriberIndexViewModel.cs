using System;
using System.Collections.Generic;
using System.Linq;
using Orchard.ContentManagement;
using Datwendo.ConnectorListener.Models;


namespace Datwendo.ConnectorListener.ViewModels
{
    // For Admin Menu
    public class SubscriberIndexViewModel
    {
        public IEnumerable<SubscriberPart> Attributes { get; set; }
        public dynamic Pager { get; set; }
    }
}
