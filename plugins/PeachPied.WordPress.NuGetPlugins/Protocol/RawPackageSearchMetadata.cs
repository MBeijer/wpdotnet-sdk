using Newtonsoft.Json;
using NuGet.Protocol;

namespace Peachpied.WordPress.NuGetPlugins.Protocol;

class RawPackageSearchMetadata : PackageSearchMetadata
{
    [JsonProperty(JsonProperties.Versions)]
    public RawVersionInfo[] RawVersions { get; set; }
}