using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unmockable
{
    public sealed class SealedClass : ChildClass
    {
        public override string VirtualMethod()
        {
            return base.VirtualMethod() + ", overridden";
        }
    }
}
