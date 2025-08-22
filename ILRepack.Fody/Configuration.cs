using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Fody;

public record class Configuration
{
    /// <summary>
    /// If `DuplicateTypes` is not specified, allow all duplicate types.
    /// See`<AllowDuplicateTypes>` below for more informationelement
    ///
    /// Corresponds to:
    /// `@AllowAllDuplicateTypes` attribute
    /// `/allowdup` command line argument
    /// </summary>
    public bool AllowAllDuplicateTypes { get; set; }

    /// <summary>
    /// Allows to duplicate resources in output assembly (by default they're ignored).
    ///
    /// Corresponds to:
    /// `@AllowDuplicateResources` attribute
    /// `/allowduplicateresources` command line argument
    /// </summary>
    public bool AllowDuplicateResources { get; set; }

    /// <summary>
    /// When specified, allows multiple attributes (if type allows).
    ///
    /// Corresponds to:
    /// `@AllowMultipleAssemblyLevelAttributes` attribute
    /// `/allowMultiple` command line argument
    /// </summary>
    public bool AllowMultipleAssemblyLevelAttributes { get; set; }

    /// <summary>
    /// Allows (and resolves) file wildcards (e.g. *.dll) in input assemblies.
    ///
    /// Corresponds to:
    /// `@AllowWildCards` attribute
    /// `/wildcards` command line argument
    /// </summary>
    public bool AllowWildCards { get; set; }

    /// <summary>
    /// Allows assemblies with Zero PeKind (but obviously only IL will get merged).
    ///
    /// Corresponds to:
    /// `@AllowZeroPeKind` attribute
    /// `/zeropekind` command line argument
    /// </summary>
    public bool AllowZeroPeKind { get; set; }

    /// <summary>
    /// NOT IMPLEMENTED.
    ///
    /// Corresponds to:
    /// `@Closed` attribute
    /// `/closed` command line argument
    /// </summary>
    public bool Closed { get; set; }

    /// <summary>
    /// Copy assembly attributes (by default only the primary assembly attributes are copied).
    ///
    /// Corresponds to:
    /// `@CopyAttributes` attribute
    /// `/copyattrs` command line argument
    /// </summary>
    public bool CopyAttributes { get; set; }

    /// <summary>
    /// Enables symbol file generation. explcitly set to `false` to disable default behaviour.
    ///
    /// Corresponds to:
    /// `@DebugInfo` attribute
    /// `/ndebug` command line argument (when omitted)
    /// </summary>
    public bool DebugInfo { get; set; }

    /// <summary>
    /// Set the key, but don't sign the assembly.
    ///
    /// Corresponds to:
    /// `@DelaySign` attribute
    /// `/delaysign` command line argument
    /// </summary>
    public bool DelaySign { get; set; }

    /// <summary>
    /// Do not internalize types marked as Serializable.
    ///
    /// Corresponds to:
    /// `@ExcludeInternalizeSerializable` attribute
    /// `/excludeinternalizeserializable` command line argument
    /// </summary>
    public bool ExcludeInternalizeSerializable { get; set; }

    /// <summary>
    /// Make all types except in the first assembly 'internal'.
    /// Types in the transitive closure of public API remain public.
    ///
    /// Corresponds to:
    /// `@Internalize` attribute
    /// `/internalize` command line argument
    /// </summary>
    public bool Internalize { get; set; }

    /// <summary>
    /// Take reference assembly version into account when removing references.
    ///
    /// Corresponds to:
    /// `@KeepOtherVersionReferences` attribute
    /// `/keepotherversionreferences` command line argument
    /// </summary>
    public bool KeepOtherVersionReferences { get; set; }

    /// <summary>
    /// Stores file:line debug information as type/method attributes (requires PDB).
    ///
    /// Corresponds to:
    /// `@LineIndexation` attribute
    /// `/index` command line argument
    /// </summary>
    public bool LineIndexation { get; set; }

    /// <summary>
    /// More detailed logging.
    ///
    /// Corresponds to:
    /// `@LogVerbose` attribute
    /// `/verbose` command line argument
    /// </summary>
    public bool LogVerbose { get; set; }

    /// <summary>
    /// Merge IL Linker files.
    ///
    /// Corresponds to:
    /// `@MergeIlLinkerFiles` attribute
    /// `/illink` command line argument
    /// </summary>
    public bool MergeIlLinkerFiles { get; set; }

    /// <summary>
    /// Do not add the resourc '.List' with all merged assembly nameselement
    ///
    /// Corresponds to:
    /// `@NoRepackRes` attribute
    /// `/noRepackRes` command line argument
    /// </summary>
    public bool NoRepackRes { get; set; }

    /// <summary>
    /// Use as many CPUs as possible to merge the assemblies.
    ///
    /// Corresponds to:
    /// `@Parallel` attribute
    /// `/parallel` command line argument
    /// </summary>
    public bool Parallel { get; set; }

    /// <summary>
    /// Pause execution once completed, good for debugging, don't use for CI/CD.
    ///
    /// Corresponds to:
    /// `@PauseBeforeExit` attribute
    /// `/pause` command line argument
    /// </summary>
    public bool PauseBeforeExit { get; set; }

    /// <summary>
    /// Preserve original file PE timestamp.
    ///
    /// Corresponds to:
    /// `@PreserveTimestamp` attribute
    /// `/preservetimestamp` command line argument
    /// </summary>
    public bool PreserveTimestamp { get; set; }

    /// <summary>
    /// Undocumented.
    /// </summary>
    public bool PublicKeyTokens { get; set; }

    /// <summary>
    /// Rename each internalized type to a new unique name.
    ///
    /// Corresponds to:
    /// `@RenameInternalized` attribute
    /// `/renameinternalized` command line argument
    /// </summary>
    public bool RenameInternalized { get; set; }

    /// <summary>
    /// Skips merging config files.
    ///
    /// Corresponds to:
    /// `@SkipConfigMerge` attribute
    /// `/skipconfig` command line argument
    /// </summary>
    public bool SkipConfigMerge { get; set; }

    /// <summary>
    /// Undocumented.
    /// </summary>
    public bool StrongNameLost { get; set; }

    /// <summary>
    /// Merges types with identical names into one.
    ///
    /// Corresponds to:
    /// `@UnionMerge` attribute
    /// `/union` command line argument
    /// </summary>
    public bool UnionMerge { get; set; }

    /// <summary>
    /// Merges XML documentation as well.
    ///
    /// Corresponds to:
    /// `@XmlDocumentation` attribute
    /// `/xmldocs` command line argument
    /// </summary>
    public bool XmlDocumentation { get; set; }

    /// <summary>
    /// NOT IMPLEMENTED.
    ///
    /// Corresponds to:
    /// `@FileAlignment` attribute
    /// `/align` command line argument
    /// </summary>
    public int FileAlignment { get; set; }

    /// <summary>
    /// Target assembly kind [library|exe|winexe], default is same as primary assembly.
    ///
    /// Corresponds to:
    /// `@TargetKind` attribute
    /// `/target: command line argument
    /// </summary>
    public string TargetKind { get; set; } = string.Empty;

    /// <summary>
    /// Specify target platform path.
    ///
    /// Corresponds to:
    /// `@TargetPlatformDirectory` attribute
    /// `/targetplatform: command line argument (first part of P)
    /// </summary>
    public string TargetPlatformDirectory { get; set; } = string.Empty;

    /// <summary>
    /// Specify target platform version (v1, v1.1, v2, v4 supported).
    ///
    /// Corresponds to:
    /// `@TargetPlatformVersion` attribute
    /// `/targetplatform:P` command line argument (second part of P)
    /// </summary>
    public string TargetPlatformVersion { get; set; } = string.Empty;

    /// <summary>
    /// Target assembly version.
    ///
    /// Corresponds to:
    /// `@Version` attribute
    /// `/ver:X.Y.Z` command line argument
    /// </summary>
    public string Version { get; set; } = string.Empty;

    /// <summary>
    /// Key container.
    ///
    /// Corresponds to:
    /// `@KeyContainer` attribute
    /// `/keycontainer:<c>` command line argument
    /// </summary>
    public string KeyContainer { get; set; } = string.Empty;

    /// <summary>
    /// Keyfile to sign the output assembly.
    ///
    /// Corresponds to:
    /// `@KeyFile` attribute
    /// `/keyfile:<path>` command line argument
    /// </summary>
    public string KeyFile { get; set; } = string.Empty;

    /// <summary>
    /// Enable logging to the given file (default is disabled).
    ///
    /// Corresponds to:
    /// `@LogFile` attribute
    /// `/log:<logfile>` command line argument
    /// </summary>
    public string LogFile { get; set; } = string.Empty;

    /// <summary>
    /// A list of assembly names to include from the default action of "embed all Copy Local references".
    /// </summary>
    public List<string> IncludeAssemblies { get; set; } = [];

    /// <summary>
    /// A list of assembly names to exclude from the default action of "embed all Copy Local references".
    /// </summary>
    public List<string> ExcludeAssemblies { get; set; } = [];

    /// <summary>
    /// A list of runtime assembly names to include from the default action of "embed all Copy Local references".
    /// </summary>
    public List<string> IncludeRuntimeAssemblies { get; set; } = [];

    /// <summary>
    /// A list of runtime assembly names to exclude from the default action of "embed all Copy Local references".
    /// </summary>
    public List<string> ExcludeRuntimeAssemblies { get; set; } = [];

    /// <summary>
    /// Keep duplicates of the specified type, may be specified more than once.
    ///
    /// Corresponds to:
    ///`<AllowedDuplicateTypes>` element
    /// `/allowdup:Type`   command line argument
    /// </summary>
    public List<string> AllowedDuplicateTypes { get; set; } = [];

    /// <summary>
    /// Take assembly attributes from the given assembly file.
    ///
    /// Corresponds to:
    /// `<ImportAttributeAssemblies>` element
    /// `/attr:<path>` command line argument
    /// </summary>
    public List<string> ImportAttributeAssemblies { get; set; } = [];

    /// <summary>
    /// Internalize a specific assembly name (no e propertxtension).
    /// May be specified more than once (one per assembly to internalize).
    /// If specified, no need to also specify `/internalize`.
    ///
    /// Corresponds to:
    /// `<InternalizeAssemblies>`
    /// `/internalizeassembly:<path>`
    /// </summary>
    public List<string> InternalizeAssemblies { get; set; } = [];

    /// <summary>
    /// Each item is either regex or a full type name not to internalize, or an assembly name not to internalize (.dll extension optional).
    /// Internally, each item is written line-by-line into  `.not` file that gets passed aselement
    ///
    /// Corresponds to:
    /// `<ExcludeInternalizeAssemblies>`
    /// `/internalize:<exclude_file>`
    /// </summary>
    public List<string> ExcludeInternalizeAssemblies { get; set; } = [];

    /// <summary>
    /// Path(s) to search directories used to resolve referenced assemblies (can be specified multiple times).
    /// If you get 'unable to resolve assembly' errors specify a path to a directory where the assembly can be found.
    ///
    /// Corresponds to:
    /// `<LibraryPaths>`
    /// `/lib:<path>`
    /// </summary>
    public List<string> LibraryPaths { get; set; } = [];

    /// <summary>
    /// Allows dropping members denoted by this attribute name when merging.
    ///
    /// Corresponds to:
    /// `<RepackDropAttributes>` element
    /// `/repackdrop:RepackDropAttribute` command line argument
    /// </summary>
    public List<string> RepackDropAttributes { get; set; } = [];

    /*
    [Required]
    /// <summary>
    /// Paths to input assemblies in the following order:
    /// - **primary assembly**: gives the name, version to the merged one
    /// - **other assemblies**: other assemblies to merge with the primary one
    ///
    /// Corresponds to:
    /// `<InputAssemblies>`
    /// </summary>
    public List<string> InputAssemblies { get; set; } = [];

    [Required]
    /// <summary>
    /// Target assembly path, symbol/config/doc files will be written here as well.
    ///
    /// Corresponds to:
    /// `<OutputFile>` element
    /// `/out:<path>` command line argument
    /// </summary>
    public string OutputFile { get; set; } = default;
    */

    /// <summary>
    /// Timeout to end task in seconds.
    /// This is a special value that allows to terminate th `` task after the specified time to avoid endless loops eating precious CI time.
    ///
    /// Corresponds to:
    /// `@Timeout` attribute
    /// </summary>
    public int Timeout { get; set; } = 30;

    public Configuration(XElement config)
    {
        if (config is null)
        {
            return;
        }

        AllowAllDuplicateTypes = config.ReadBoolAttribute(
            "AllowAllDuplicateTypes",
            AllowAllDuplicateTypes
        );
        AllowDuplicateResources = config.ReadBoolAttribute(
            "AllowDuplicateResources",
            AllowDuplicateResources
        );
        AllowMultipleAssemblyLevelAttributes = config.ReadBoolAttribute(
            "AllowMultipleAssemblyLevelAttributes",
            AllowMultipleAssemblyLevelAttributes
        );
        AllowWildCards = config.ReadBoolAttribute("AllowWildCards", AllowWildCards);
        AllowZeroPeKind = config.ReadBoolAttribute("AllowZeroPeKind", AllowZeroPeKind);
        Closed = config.ReadBoolAttribute("Closed", Closed);
        CopyAttributes = config.ReadBoolAttribute("CopyAttributes", CopyAttributes);
        DebugInfo = config.ReadBoolAttribute("DebugInfo", DebugInfo);
        DelaySign = config.ReadBoolAttribute("DelaySign", DelaySign);
        ExcludeInternalizeSerializable = config.ReadBoolAttribute(
            "ExcludeInternalizeSerializable",
            ExcludeInternalizeSerializable
        );
        Internalize = config.ReadBoolAttribute("Internalize", Internalize);
        KeepOtherVersionReferences = config.ReadBoolAttribute(
            "KeepOtherVersionReferences",
            KeepOtherVersionReferences
        );
        LineIndexation = config.ReadBoolAttribute("LineIndexation", LineIndexation);
        LogVerbose = config.ReadBoolAttribute("LogVerbose", LogVerbose);
        MergeIlLinkerFiles = config.ReadBoolAttribute("MergeIlLinkerFiles", MergeIlLinkerFiles);
        NoRepackRes = config.ReadBoolAttribute("NoRepackRes", NoRepackRes);
        Parallel = config.ReadBoolAttribute("Parallel", Parallel);
        PauseBeforeExit = config.ReadBoolAttribute("PauseBeforeExit", PauseBeforeExit);
        PreserveTimestamp = config.ReadBoolAttribute("PreserveTimestamp", PreserveTimestamp);
        PublicKeyTokens = config.ReadBoolAttribute("PublicKeyTokens", PublicKeyTokens);
        RenameInternalized = config.ReadBoolAttribute("RenameInternalized", RenameInternalized);
        SkipConfigMerge = config.ReadBoolAttribute("SkipConfigMerge", SkipConfigMerge);
        StrongNameLost = config.ReadBoolAttribute("StrongNameLost", StrongNameLost);
        UnionMerge = config.ReadBoolAttribute("UnionMerge", UnionMerge);
        XmlDocumentation = config.ReadBoolAttribute("XmlDocumentation", XmlDocumentation);

        FileAlignment = config.ReadIntegerAttribute("FileAlignment", FileAlignment);
        Timeout = config.ReadIntegerAttribute("Timeout", Timeout);

        TargetKind = config.ReadStringAttribute("TargetKind", TargetKind);
        TargetPlatformDirectory = config.ReadStringAttribute(
            "TargetPlatformDirectory",
            TargetPlatformDirectory
        );
        TargetPlatformVersion = config.ReadStringAttribute(
            "TargetPlatformVersion",
            TargetPlatformVersion
        );
        Version = config.ReadStringAttribute("Version", Version);
        KeyContainer = config.ReadStringAttribute("KeyContainer", KeyContainer);
        KeyFile = config.ReadStringAttribute("KeyFile", KeyFile);
        LogFile = config.ReadStringAttribute("LogFile", LogFile);

        IncludeAssemblies = config.ReadList("IncludeAssemblies");
        ExcludeAssemblies = config.ReadList("ExcludeAssemblies");
        IncludeRuntimeAssemblies = config.ReadList("IncludeRuntimeAssemblies");
        ExcludeRuntimeAssemblies = config.ReadList("ExcludeRuntimeAssemblies");

        AllowedDuplicateTypes = config.ReadList("AllowedDuplicateTypes");
        ImportAttributeAssemblies = config.ReadList("ImportAttributeAssemblies");
        InternalizeAssemblies = config.ReadList("InternalizeAssemblies");
        ExcludeInternalizeAssemblies = config.ReadList("ExcludeInternalizeAssemblies");
        //LibraryPaths = config.ReadList("LibraryPaths");
        RepackDropAttributes = config.ReadList("RepackDropAttributes");

        /*
        if (config.Attribute("IncludeAssemblies") is not null ||
            config.Element("IncludeAssemblies") is not null)
        {
            OptOutAssemblies = false;
        }

        if (config.Attribute("IncludeRuntimeAssemblies") is not null ||
            config.Element("IncludeRuntimeAssemblies") is not null)
        {
            OptOutRuntimeAssemblies = false;
        }

        IncludeDebugSymbols = config.ReadBoolAttribute("IncludeDebugSymbols", IncludeDebugSymbols);
        IncludeRuntimeReferences = config.ReadBoolAttribute("IncludeRuntimeReferences", IncludeRuntimeReferences);
        UseRuntimeReferencePaths = config.ReadBoolAttribute("UseRuntimeReferencePaths");
        DisableCompression = config.ReadBoolAttribute("DisableCompression", DisableCompression);
        DisableCleanup = config.ReadBoolAttribute("DisableCleanup", DisableCleanup);
        DisableEventSubscription = config.ReadBoolAttribute("DisableEventSubscription", DisableEventSubscription);
        LoadAtModuleInit = config.ReadBoolAttribute("LoadAtModuleInit", LoadAtModuleInit);
        CreateTemporaryAssemblies = config.ReadBoolAttribute("CreateTemporaryAssemblies", CreateTemporaryAssemblies);
        IgnoreSatelliteAssemblies = config.ReadBoolAttribute("IgnoreSatelliteAssemblies", IgnoreSatelliteAssemblies);

        ExcludeAssemblies = config.ReadList("ExcludeAssemblies");
        IncludeAssemblies = config.ReadList("IncludeAssemblies");
        ExcludeRuntimeAssemblies = config.ReadList("ExcludeRuntimeAssemblies");
        IncludeRuntimeAssemblies = config.ReadList("IncludeRuntimeAssemblies");

        UnmanagedWinX86Assemblies = config.ReadList("UnmanagedWinX86Assemblies");
        if (!UnmanagedWinX86Assemblies.Any())
        {
            // Backwards compatibility
            UnmanagedWinX86Assemblies = config.ReadList("Unmanaged32Assemblies");
        }

        UnmanagedWinX64Assemblies = config.ReadList("UnmanagedWinX64Assemblies");
        if (!UnmanagedWinX64Assemblies.Any())
        {
            // Backwards compatibility
            UnmanagedWinX64Assemblies = config.ReadList("Unmanaged64Assemblies");
        }

        UnmanagedWinArm64Assemblies = config.ReadList("UnmanagedWinArm64Assemblies");

        PreloadOrder = config.ReadList("PreloadOrder");
        */

        //if (IncludeAssemblies.Any() && ExcludeAssemblies.Any())
        //{
        //    throw new WeavingException("Either configure IncludeAssemblies OR ExcludeAssemblies, not both.");
        //}
    }

    public bool OptOutAssemblies { get; }
    public bool OptOutRuntimeAssemblies { get; }
}
