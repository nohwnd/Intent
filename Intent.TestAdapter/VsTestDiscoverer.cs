using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Intent.TestAdapter
{
    [DefaultExecutorUri(VsTestExecutor.Id)]
    //[FileExtension(".exe")]
    //[FileExtension(".dll")]
    public class VsTestDiscoverer : ITestDiscoverer
    {
        public void DiscoverTests(IEnumerable<string> sources, IDiscoveryContext discoveryContext, IMessageLogger logger, ITestCaseDiscoverySink discoverySink)
        {
            logger.SendMessage(TestMessageLevel.Informational, "Intent 1.0");
            foreach (var p in sources)
            {
                try
                {
                    var asm = Assembly.LoadFrom(p);
                    if (asm.IsExcluded())
                        continue;

                    var ts = asm.GetTypes().SkipExcluded();
                    foreach (var t in ts)
                    {
                        var ms = t.GetMethods().SkipExcluded();
                        foreach (var m in ms)
                        {
                            try
                            {
                                var discoveredTest = new TestCase(m.Name, VsTestExecutor.Uri, p)
                                {
                                    DisplayName = m.Name.Replace("_", " ")
                                };

                                logger.SendMessage(TestMessageLevel.Informational, $"Found test '{discoveredTest.DisplayName}'.");
                                discoverySink.SendTestCase(discoveredTest);
                            }
                            catch (Exception ex)
                            {
                                logger.SendMessage(TestMessageLevel.Error, ex.ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.SendMessage(TestMessageLevel.Error, ex.ToString());
                }
            }
        }
    }
}