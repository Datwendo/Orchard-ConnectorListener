using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datwendo.ConnectorListener.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;
using Orchard.Localization;
using Orchard.Utility.Extensions;
using Orchard.ContentTypes;

using Orchard.ContentManagement.MetaData;
using Datwendo.ConnectorListener.ViewModels;

namespace Datwendo.ConnectorListener.Drivers
{
    [OrchardFeature("Datwendo.ConnectorListener")]
    public class NotificationPartDriver : ContentPartDriver<NotificationPart>
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public NotificationPartDriver(IContentDefinitionManager contentDefinitionManager)
        {
            T                           = NullLocalizer.Instance;
            _contentDefinitionManager   = contentDefinitionManager;
        }

        public Localizer T { get; set; }

        
       protected override string Prefix
        {
            get { return "Notification"; }
        }


        protected override DriverResult Display(NotificationPart part, string displayType, dynamic shapeHelper) 
        {
            return ContentShape("Parts_Notification", () => shapeHelper.Parts_Notification(Model: part));
        }

        //GET
        protected override DriverResult Editor(NotificationPart part, dynamic shapeHelper) 
        {
                return ContentShape("Parts_Notification_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/Notification",
                    Model: part,
                    Prefix: Prefix));
        }
        
        //POST
        protected override DriverResult Editor(NotificationPart part, IUpdateModel updater, dynamic shapeHelper) 
        {
            if (updater != null)
                updater.TryUpdateModel(part, Prefix, null, null);

            return Editor(part,shapeHelper);
        }

        protected override void Importing(NotificationPart part, ImportContentContext context)
        {
            var PublisherId = context.Attribute(part.PartDefinition.Name, "PublisherId");
            
            int pri = 0;
            if (int.TryParse(PublisherId, out pri))
                part.PublisherId    = pri;

            var SubscriberId = context.Attribute(part.PartDefinition.Name, "SubscriberId");

            pri = 0;
            if (int.TryParse(SubscriberId, out pri))
                part.SubscriberId   = pri;


            var CounterId = context.Attribute(part.PartDefinition.Name, "CounterId");
            pri = 0;
            if (int.TryParse(CounterId, out pri))
                part.CounterId      = pri;


            var Index = context.Attribute(part.PartDefinition.Name, "IdxVal");
            pri = 0;
            if (int.TryParse(Index, out pri))
                part.IdxVal          = pri;

            var Status = context.Attribute(part.PartDefinition.Name, "StateCode");
            pri = 0;
            if (int.TryParse(Status, out pri))
                part.StateCode             = pri;
        }

        protected override void Exporting(NotificationPart part, ExportContentContext context) {
            context.Element(part.PartDefinition.Name).SetAttributeValue("PublisherId", part.PublisherId);
            context.Element(part.PartDefinition.Name).SetAttributeValue("SubscriberId", part.SubscriberId);
            context.Element(part.PartDefinition.Name).SetAttributeValue("CounterId", part.CounterId);
            context.Element(part.PartDefinition.Name).SetAttributeValue("IdxVal", part.IdxVal); 
            context.Element(part.PartDefinition.Name).SetAttributeValue("StateCode", part.StateCode);
        }
    }
}