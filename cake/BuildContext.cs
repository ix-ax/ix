// Build
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

using System.Collections.Generic;
using System.IO;
using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNet.Build;
using Cake.Common.Tools.DotNet.MSBuild;
using Cake.Common.Tools.DotNet.Run;
using Cake.Common.Tools.DotNet.Test;
using Cake.Common.Tools.DotNetCore.MSBuild;
using Cake.Core;
using Cake.Frosting;

public class BuildContext : FrostingContext
{
    public string Artifacts  => Path.Combine(Environment.WorkingDirectory.FullPath, "..//artifacts//");

    public string TestResults => Path.Combine(Environment.WorkingDirectory.FullPath, "..//TestResults//");

    public string WorkDirName => Environment.WorkingDirectory.GetDirectoryName();

    public string DocumentationOutputDir => Path.GetFullPath(Path.Combine(Environment.WorkingDirectory.FullPath, "..//docs//"));

    public string DocumentationSource => Path.GetFullPath(Path.Combine(Environment.WorkingDirectory.FullPath, "..//docfx//"));

    public string RootDir => Path.GetFullPath(Path.Combine(Environment.WorkingDirectory.FullPath, "..//src//"));

    public Cake.Common.Tools.DotNet.Build.DotNetBuildSettings DotNetBuildSettings { get; }

    public Cake.Common.Tools.DotNet.Test.DotNetTestSettings DotNetTestSettings { get; }

    public DotNetRunSettings DotNetRunSettings { get; }

    public BuildParameters BuildParameters { get; }

    public BuildContext(ICakeContext context, BuildParameters buildParameters)
        : base(context)
    {

        BuildParameters = buildParameters;

        DotNetBuildSettings = new DotNetBuildSettings()
        {
            Verbosity = buildParameters.Verbosity,
            Configuration = buildParameters.Configuration,
            NoRestore = false,
            MSBuildSettings = new DotNetMSBuildSettings()
            {
                Verbosity = DotNetVerbosity.Quiet
            }
        };

        DotNetTestSettings = new DotNetTestSettings()
        {
            Verbosity = buildParameters.Verbosity,
            Configuration = buildParameters.Configuration,
            NoRestore = true,
            NoBuild = true,
            DiagnosticOutput = true,
            VSTestReportPath = TestResults,
        };

        DotNetRunSettings = new DotNetRunSettings()
        {
            Verbosity = buildParameters.Verbosity,
            Framework = "net6.0",
            Configuration = buildParameters.Configuration,
            NoBuild = true,
            NoRestore = true,
        };
    }

    public IEnumerable<string> TargetFrameworks { get; } = new List<string>() { "net6.0", "net7.0" };
}