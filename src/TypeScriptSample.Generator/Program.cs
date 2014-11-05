using System;
using System.IO;
using System.Reflection;
using TypeLite;

namespace TypeScriptSample.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var assemblyFile = args[0];
            var outputPath = args[1];

            LoadReferencedAssemblies(assemblyFile);
            GenerateTypeScriptContracts(assemblyFile, outputPath);
        }

        private static void LoadReferencedAssemblies(string assemblyFile)
        {
            var sourceAssemblyDirectory = Path.GetDirectoryName(assemblyFile);
            foreach (var file in Directory.GetFiles(sourceAssemblyDirectory, "*.dll"))
            {
                File.Copy(file, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, new FileInfo(file).Name), true);
            }
        }

        private static void GenerateTypeScriptContracts(string assemblyFile, string outputPath)
        {
            var assembly = Assembly.LoadFrom(assemblyFile);
            // If you want a subset of classes from this assembly, filter them here
            var models = assembly.GetTypes();

            var generator = new TypeScriptFluent()
                .WithConvertor<Guid>(c => "string");

            foreach (var model in models)
            {
                generator.ModelBuilder.Add(model);
            }

            //Generate enums
            var tsEnumDefinitions = generator.Generate(TsGeneratorOutput.Enums);
            Directory.CreateDirectory(outputPath);
            File.WriteAllText(Path.Combine(outputPath, "enums.ts"), tsEnumDefinitions);
            //Generate interface definitions for all classes
            var tsClassDefinitions = generator.Generate(TsGeneratorOutput.Properties | TsGeneratorOutput.Fields);
            File.WriteAllText(Path.Combine(outputPath, "classes.d.ts"), tsClassDefinitions);

        }
    }
}
