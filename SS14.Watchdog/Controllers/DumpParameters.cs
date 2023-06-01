using System;

namespace SS14.Watchdog.Controllers;

public class DumpParameters
{
	public TimeSpan Duration { get; set; } = TimeSpan.FromSeconds(30);
}
