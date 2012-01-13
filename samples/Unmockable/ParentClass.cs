using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unmockable
{
    public abstract class ParentClass
    {
        public string NonVirtualMethod()
        {
            return "Non-virual method";
        }

        public abstract string AbstractMethod();
    }
}
