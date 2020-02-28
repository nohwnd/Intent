using System;
using System.Collections.Generic;
using System.Reflection;

namespace Intent
{
    public class Runner
    {
        public void Run(IEnumerable<string> path, IRunLogger logger)
        {
            foreach (var p in path)
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
                                var i = Activator.CreateInstance(t);
                                m.Invoke(i, Array.Empty<object>());
                                logger.WriteTestInconclusive(m);
                            }
                            catch (Exception ex)
                            {
                                if (ex is TargetInvocationException tex)
                                {
                                    switch (tex.InnerException)
                                    {
                                        case TestPassedException _:
                                            logger.WriteTestPassed(m);
                                            break;
                                        default:
                                            logger.WriteTestFailure(m, tex.InnerException);
                                            break;
                                    }
                                }
                                else
                                {
                                    logger.WriteTestFailure(m, ex);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.WriteFrameworkError(ex);
                }
            }
        }
    }
}
