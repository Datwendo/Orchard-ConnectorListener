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
    public class SubscriberPartDriver : ContentPartDriver<SubscriberPart>
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public SubscriberPartDriver(IContentDefinitionManager contentDefinitionManager)
        {
            T                           = NullLocalizer.Instance;
            _contentDefinitionManager   = contentDefinitionManager;
        }

        public Localizer T { get; set; }

        
       protected override string Prefix
        {
            get { return "Subscriber"; }
        }


        protected override DriverResult Display(SubscriberPart part, string displayType, dynamic shapeHelper) 
        {
            var contentTypeDefinition = _contentDefinitionManager.GetTypeDefinition(part.ContentTypeName);

            return ContentShape("Parts_Subscriber", () => shapeHelper.Parts_Subscriber(Content: part, ContentTypeDefinition: contentTypeDefinition));
        }

        //GET
        protected override DriverResult Editor(SubscriberPart part, dynamic shapeHelper) 
        {
            var lst                     = _contentDefinitionManager.ListTypeDefinitions().Select(c => new ContentTypeView {Name= c.Name, DisplayName = c.DisplayName});
            SubscriberPartViewModel vm  = new SubscriberPartViewModel { Subcriber = part, TypeLst = lst };
                return ContentShape("Parts_Subscriber_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/Subscriber",
                    Model: vm,
                    Prefix: Prefix));
        }
        
        //POST
        protected override DriverResult Editor(SubscriberPart part, IUpdateModel updater, dynamic shapeHelper) 
        {
            var lst                     = _contentDefinitionManager.ListTypeDefinitions().Select(c => new ContentTypeView { Name = c.Name, DisplayName = c.DisplayName });
            SubscriberPartViewModel vm  = new SubscriberPartViewModel { Subcriber = part, TypeLst = lst };
            if (updater != null && updater.TryUpdateModel(vm, Prefix, null, null))
            {
                part                    = vm.Subcriber;
            }
            return Editor(part,shapeHelper);
        }

        protected override void Importing(SubscriberPart part, ImportContentContext context)
        {
            var PublisherId = context.Attribute(part.PartDefinition.Name, "PublisherId");
            
            int pri = 0;
            if (int.TryParse(PublisherId, out pri))
                part.PublisherId = pri;

            var SubscriberId = context.Attribute(part.PartDefinition.Name, "SubscriberId");

            pri = 0;
            if (int.TryParse(SubscriberId, out pri))
                part.SubscriberId = pri;
            part.ContentTypeName = context.Attribute(part.PartDefinition.Name, "ContentTypeName");


            var TriggerWorkflow = context.Attribute(part.PartDefinition.Name, "TriggerWorkflow");
            pri = 0;
            if (int.TryParse(TriggerWorkflow, out pri))
                part.TriggerWorkflow = (pri ==1);
        }

        protected override void Exporting(SubscriberPart part, ExportContentContext context) {
            context.Element(part.PartDefinition.Name).SetAttributeValue("PublisherId", part.PublisherId);
            context.Element(part.PartDefinition.Name).SetAttributeValue("SubscriberId", part.SubscriberId);
            context.Element(part.PartDefinition.Name).SetAttributeValue("ContentTypeName", part.ContentTypeName);
            context.Element(part.PartDefinition.Name).SetAttributeValue("TriggerWorkflow", part.TriggerWorkflow ? "1":"0");
        }
    }
}