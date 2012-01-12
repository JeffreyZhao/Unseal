using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Target;
using Moq;

namespace Usage
{
    class Program
    {
        static void Main(string[] args)
        {
            var parentMock = new Mock<ParentClass>();
            parentMock.Setup(p => p.NonVirtualMethod()).Returns("Non-virtual method mocked.");
            Console.WriteLine(parentMock.Object.NonVirtualMethod());

            var childMock = new Mock<ChildClass>();
            childMock.Setup(c => c.AbstractMethod()).Returns("Sealed method mocked.");
            Console.WriteLine(childMock.Object.AbstractMethod());

            var sealedMock = new Mock<SealedClass>();
            sealedMock.Setup(s => s.NonVirtualMethod()).Returns("Sealed class mocked.");
            Console.WriteLine(sealedMock.Object.NonVirtualMethod());

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
