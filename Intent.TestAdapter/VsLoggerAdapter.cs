using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using VsTestResult = Microsoft.VisualStudio.TestPlatform.ObjectModel.TestResult;
using System;
using System.Reflection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Intent.TestAdapter
{
    internal class VsLoggerAdapter : IRunLogger
    {
        private IFrameworkHandle _handle;
        private IMessageLogger _logger;
        private Uri _uri;

        public VsLoggerAdapter(IFrameworkHandle handle, Uri uri)
        {
            _handle = handle;
            _logger = handle;
            _uri = uri;
        }

        public void WriteFrameworkError(Exception ex)
        {
            _logger.SendMessage(TestMessageLevel.Error, ex.ToString()); 
        }

        public void WriteTestFailure(MethodInfo m, Exception ex)
        {

            var tc = new TestCase(m.Name, _uri, m.DeclaringType.Assembly.Location);
            _handle.RecordResult(new VsTestResult(tc)
            {
                DisplayName = m.Name.Replace("_", " "),
                Outcome = TestOutcome.Failed,
                ErrorMessage = ex.Message,
                ErrorStackTrace = ex.StackTrace
            });
        }

        public void WriteTestInconclusive(MethodInfo m)
        {
            var tc = new TestCase(m.Name, _uri, m.DeclaringType.Assembly.Location);
            _handle.RecordResult(new VsTestResult(tc)
            {
                DisplayName = m.Name.Replace("_", " "),
                Outcome = TestOutcome.Skipped
            });
        }

        public void WriteTestPassed(MethodInfo m)
        {
            var tc = new TestCase(m.Name, _uri, m.DeclaringType.Assembly.Location);
            _handle.RecordResult(new VsTestResult(tc)
            {
                DisplayName = m.Name.Replace("_", " "),
                Outcome = TestOutcome.Passed
            });
        }
    }
}