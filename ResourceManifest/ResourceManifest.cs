using Orchard.UI.Resources;

namespace Datwendo.ConnectorListener {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineStyle("SubscriberSettings").SetUrl("datwendo-subscriber-settings.css");
        }
    }
}
