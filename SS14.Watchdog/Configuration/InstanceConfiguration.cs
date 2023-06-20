using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using SS14.Watchdog.Controllers;

namespace SS14.Watchdog.Configuration
{
    [UsedImplicitly]
    public sealed class InstanceConfiguration
    {
        public string? Name { get; set; }
        public string? UpdateType { get; set; }
        public string? ApiToken { get; set; }
        public ushort ApiPort { get; set; }

        public string RunCommand { get; set; } = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? "bin/Robust.Server.exe"
            : "bin/Robust.Server";

        /// <summary>
        /// Тип создаваемого дампа.
        /// </summary>
        public DumpType TimeoutDumpType { get; set; } = DumpType.Gcdump | DumpType.Trace;

        /// <summary>
        /// Максимальное время создание дампа gcdmp.
        /// </summary>
        public int GcdumpDumpCreateTimeout { get; set; } = 10;

        /// <summary>
        /// Время выполнения трассировки.
        /// </summary>
        public int TraceDumpDuration { get; set; } = 10;

        /// <summary>
        /// How long since the last ping before we consider the server "dead" and forcefully terminate it. In seconds.
        /// </summary>
        public int TimeoutSeconds { get; set; } = 5;
        
        /// <summary>
        /// Any additional environment variables for the server process.
        /// </summary>
        [UsedImplicitly]
        public Dictionary<string, string> EnvironmentVariables { get; set; } = new();
    }
}