using System;

namespace SS14.Watchdog.Controllers;

/// <summary>
/// Тип создаваемого дампа.
/// </summary>
[Flags]
public enum DumpType
{
	/// <summary>
	/// None.
	/// </summary>
	None = 0,

	/// <summary>
	/// dotnet-trace
	/// </summary>
	Trace = 1,

	/// <summary>
	/// dotnet-gcdump.
	/// </summary>
	Gcdump = 2,
}