﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

using Microsoft.DotNet.Cli.Cleanup;
using LocalizableStrings = Microsoft.DotNet.Tools.Cleanup.LocalizableStrings;
using static Microsoft.DotNet.Cli.Cleanup.CleanupCommandCommon;

namespace Microsoft.DotNet.Cli
{
    internal static class CleanupAnalyzersCommandParser
    {
        private static readonly CleanupAnalyzersHandler s_analyzerHandler = new();

        public static Command GetCommand()
        {
            var command = new Command("analyzers", LocalizableStrings.Run_3rd_party_analyzers__and_apply_fixes)
            {
                DiagnosticsOption,
                SeverityOption,
            };
            command.AddCommonOptions();
            command.Handler = s_analyzerHandler;
            return command;
        }

        class CleanupAnalyzersHandler : ICommandHandler
        {
            public Task<int> InvokeAsync(InvocationContext context)
                => Task.FromResult(new CleanupAnalyzersCommand().FromArgs(context.ParseResult).Execute());
        }
    }
}
