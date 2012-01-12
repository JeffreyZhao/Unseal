using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using System.IO;

namespace Unseal
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: Unseal.exe full-path-of-assembly.");
                Environment.Exit(1);
            }

            var asmFile = args[0];
            if (!File.Exists(asmFile))
            {
                Console.WriteLine("Input file doesn't exist." + asmFile);
                Environment.Exit(1);
            }

            Console.WriteLine("Start processing: " + asmFile);

            var pdbFile = Path.ChangeExtension(asmFile, ".pdb");
            var hasPdbFile = File.Exists(pdbFile);

            if (hasPdbFile)
            {
                Console.WriteLine("Pdb found: " + pdbFile);
            }

            var asmDef = AssemblyDefinition.ReadAssembly(asmFile, new ReaderParameters
            {
                ReadSymbols = hasPdbFile
            });

            var classTypes = asmDef.Modules
                .SelectMany(m => m.Types)
                .Where(t => t.IsClass)
                .ToList();

            foreach (var type in classTypes)
            {
                if (type.IsSealed)
                {
                    type.IsSealed = false;
                }

                foreach (var method in type.Methods)
                {
                    if (method.IsStatic) continue;
                    if (method.IsConstructor) continue;
                    if (method.IsAbstract) continue;

                    if (method.IsFinal)
                    {
                        method.IsFinal = false;
                    }

                    if (!method.IsVirtual)
                    {
                        method.IsVirtual = true;
                    }
                }
            }

            asmDef.Write(asmFile, new WriterParameters
            {
                WriteSymbols = hasPdbFile
            });

            Console.WriteLine("Finished");
        }
    }
}
