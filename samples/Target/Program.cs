using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;

namespace Target
{
    class Program
    {
        static void Main(string[] args)
        {
            var parentMock = new Mock<ParentClass>();
            parentMock.Setup(p => p.AbstractMethod()).Returns("Mock an abstract method.");

            try
            {
                parentMock.Setup(p => p.NonVirtualMethod()).Returns("Failed");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Cannot mock a non-virtual method.");
            }

            var childMock = new Mock<ChildClass>();
            childMock.Setup(c => c.VirtualMethod()).Returns("Mock a virtual method");

            try
            {
                childMock.Setup(c => c.AbstractMethod()).Returns("Failed");
                if (childMock.Object.AbstractMethod() == "Sealed method")
                {
                    throw new NotSupportedException();
                }
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Cannot mock a sealed method");
            }

            try
            {
                var sealedMock = new Mock<SealedClass>();
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Cannot mock a sealed class.");
            }

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
