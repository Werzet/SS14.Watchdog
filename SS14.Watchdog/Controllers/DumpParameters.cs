using System;

namespace SS14.Watchdog.Controllers;

/// <summary>
/// Параметры создаваемого дампа.
/// </summary>
public class DumpParameters
{
	/// <summary>
	/// Продолжительность создания дампа.
	/// </summary>
	public TimeSpan Duration { get; set; } = TimeSpan.FromSeconds(10);

	/// <summary>
	/// Тип создаваемого дампа.
	/// </summary>
	public DumpType Type { get; set; } = DumpType.Trace;
}
