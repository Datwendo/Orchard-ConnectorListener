using System;
using System.Collections.Generic;
using System.Linq;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Utilities;
using Orchard.Localization;
using Orchard.Environment.Extensions;
using Orchard.Workflows.Activities;
using Orchard.Workflows.Services;
using Orchard.Workflows.Models;
using Datwendo.ConnectorListener.Models;


namespace Datwendo.Commerce.Workflow
{
    [OrchardFeature("Datwendo.ConnectorListener")]
    public class SubscriberActivity : Event
    {
        public Localizer T { get; set; }

        public SubscriberActivity()
        {
            T = NullLocalizer.Instance;
        }

        public override bool CanStartWorkflow
        {
            get { return true; }
        }

        public override string Name
        {
            get { return "ConnectorPublished"; }
        }

        public override LocalizedString Description
        {
            get { return T("New Cloud Connector value has been published."); }
        }

        public override IEnumerable<LocalizedString> GetPossibleOutcomes(WorkflowContext workflowContext, ActivityContext activityContext)
        {
            return new LocalizedString[] { T("New") };
        }

        public override IEnumerable<LocalizedString> Execute(WorkflowContext workflowContext, ActivityContext activityContext)
        {
            yield return T("New");
        }

        public override bool CanExecute(WorkflowContext workflowContext, ActivityContext activityContext)
        {
            try
            {
                var content = workflowContext.Content;
                if (content == null)
                    return false;
                return string.Equals(content.ContentItem.TypeDefinition.Name, "ConnectorListener");
            }
            catch
            {
                return false;
            }
        }

        public override LocalizedString Category
        {
            get { return T("Cloud Connector"); }
        }
    }
    
}
