using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intent.TestAdapter
{
    [ExtensionUri(Id)]
    public class VsTestExecutor : ITestExecutor
    {
        public const string Id = "executor://intent.testadapter";
        public static readonly Uri Uri = new Uri(Id);

        public void Cancel()
        {
            // noop
        }

        public void RunTests(IEnumerable<TestCase> tests, IRunContext runContext, IFrameworkHandle frameworkHandle)
        {
            var sources = tests.Select(t => t.Source).Distinct().ToList();
            RunTests(sources, runContext, frameworkHandle);
        }

        public void RunTests(IEnumerable<string> sources, IRunContext runContext, IFrameworkHandle frameworkHandle)
        {
            IMessageLogger logger = frameworkHandle;
            logger.SendMessage(TestMessageLevel.Informational, "Intent 1.0");

            if (runContext.KeepAlive)
                frameworkHandle.EnableShutdownAfterTestRun = true;

            new Runner().Run(sources, new VsLoggerAdapter(frameworkHandle, Uri));
        }
    }
}