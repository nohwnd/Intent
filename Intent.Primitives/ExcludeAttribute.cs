using System;

namespace Intent
{
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method)]
    public class ExcludeAttribute : Attribute
    {
    }
}
