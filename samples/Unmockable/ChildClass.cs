using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unmockable
{
    public class ChildClass : ParentClass
    {
        public sealed override string AbstractMethod()
        {
            return "Sealed method";
        }

        public virtual string VirtualMethod()
        {
            return "Virtual method";
        }
    }
}
