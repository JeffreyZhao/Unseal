using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Target
{
    public sealed class SealedClass : ChildClass
    {
        public override string VirtualMethod()
        {
            return base.VirtualMethod() + ", overridden";
        }
    }
}
