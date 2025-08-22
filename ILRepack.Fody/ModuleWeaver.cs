using System.Collections.Generic;
using System.Diagnostics;
using Fody;

// -------------------
// ILRepack.Fody
// -------------------
// This project requires the following NuGet packages:
// - Fody (>= 6.5.1)
// - ILRepack.Lib (>= 2.0.18)

// The main weaver class must be named 'ModuleWeaver' and be public.
public class ModuleWeaver : BaseModuleWeaver
{
    // This method is the entry point for the Fody weaver.
    public override void Execute()
    {
        WriteInfo("Starting ILRepack weaving process.");

        try
        {
            //#if DEBUG
            //        if (!Debugger.IsAttached)
            //        {
            //            Debugger.Launch();
            //        }
            //#endif
            // 1. Read Configuration
            var config = new Configuration(Config);

            WriteInfo($"ILRepack.Fody v{GetType().Assembly.GetVersion()}");

            // You can get configuration from FodyWeavers.xml
            // For example, to get a list of assemblies to merge:
            // var mergeAssemblies = Config.Attribute("Merge")?.Value;
            // For simplicity, this example will merge all referenced assemblies.

            // 2. Configure ILRepack
            /*
            var repackOptions = new RepackOptions
            {
                // Set the output file. By default, this is the assembly being woven.
                OutputFile = AssemblyFilePath,
                // We want to merge all referenced assemblies.
                // In a real-world scenario, you might want to filter this list.
                InputAssemblies = ModuleDefinition
                    .AssemblyReferences.Select(r => ResolveAssemblyPath(r.Name))
                    .Where(p => p != null)
                    .ToArray(),
                // Set the path for the primary assembly.
                MainAssembly = AssemblyFilePath,
                // Enable logging from ILRepack
                Log = true,
                LogVerbose = true,
                // You can set other ILRepack options here, for example:
                // Internalize = true, // To make merged types internal
            };
            */

            // 3. Run ILRepack
            //var repack = new ILRepack(repackOptions);
            //repack.Repack();

            WriteInfo("ILRepack weaving process completed successfully.");
        }
        catch (Exception ex)
        {
            WriteError($"An error occurred during the ILRepack weaving process: {ex.Message}");
            WriteError(ex.StackTrace);
        }
    }

    // Helper method to resolve the full path of a referenced assembly.
    private string? ResolveAssemblyPath(string assemblyName)
    {
        try
        {
            var assembly = ResolveAssembly(assemblyName);
            if (assembly != null)
            {
                return assembly.MainModule.FileName;
            }
            WriteWarning($"Could not resolve assembly: {assemblyName}");
            return null;
        }
        catch (Exception ex)
        {
            WriteWarning(
                $"An error occurred while resolving assembly {assemblyName}: {ex.Message}"
            );
            return null;
        }
    }

    /// <summary>
    /// identify which assemblies should not be processed by this weaver
    /// </summary>
    /// <returns>assemblies that should not be processed by this weaver</returns>
    public override IEnumerable<string> GetAssembliesForScanning()
    {
        yield return "mscorlib";
        yield return "System";
    }

    /// <summary>
    /// determine if the weaver should run
    /// </summary>
    public override bool ShouldCleanReference => true;
}
