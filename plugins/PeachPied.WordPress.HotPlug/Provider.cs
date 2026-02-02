using System;
using System.Collections.Generic;
using System.Composition;
using PeachPied.WordPress.Standard;

namespace PeachPied.WordPress.HotPlug;

[Export(typeof(IWpPluginProvider))]
sealed class Provider : IWpPluginProvider
{
    IEnumerable<IWpPlugin>/*!!*/IWpPluginProvider.GetPlugins(IServiceProvider provider, string wpRootPath)
    {
        yield return new HotPlug(
            wpRootPath,
            logger: (IWpPluginLogger)provider.GetService(typeof(IWpPluginLogger))
        );
    }
}