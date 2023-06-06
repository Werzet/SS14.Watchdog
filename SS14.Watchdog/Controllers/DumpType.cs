namespace SS14.Watchdog.Controllers;

/// <summary>
/// Тип создаваемого дампа.
/// </summary>
public enum DumpType
{
	/// <summary>
	/// dotnet-trace
	/// </summary>
	Trace = 0,

	/// <summary>
	/// dotnet-gcdump.
	/// </summary>
	Gcdump = 1,
}