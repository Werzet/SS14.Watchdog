namespace SS14.Watchdog.Components.ProcessManagement;

/// <summary>
/// Configuration for <see cref="ProcessManagerSystemd"/>.
/// </summary>
public sealed class SystemdProcessOptions : ProcessOptions
{
    /// <summary>
    /// How Systemd service units are created and managed. See enum members for details.
    /// </summary>
    public SystemdUnitManagementMode UnitManagementMode { get; set; } = SystemdUnitManagementMode.TransientRandom;

    /// <summary>
    /// Prefix for service unit names used.
    /// </summary>
    /// <remarks>
    /// This prefix is appended in front of the key of server instances to get the service name,
    /// e.g. <c>ss14-server-lizard.service</c> when using the default prefix and <see cref="SystemdUnitManagementMode.TransientFixed"/>.
    /// </remarks>
    public string UnitPrefix { get; set; } = "ss14-server-";

    /// <summary>
    /// Which Systemd service manager to connect to.
    /// </summary>
    public SystemdManager Manager { get; set; } = SystemdManager.Session;
}

/// <summary>
/// How service units are managed by <see cref="ProcessManagerSystemd"/>.
/// </summary>
/// <seealso cref="SystemdProcessOptions"/>
public enum SystemdUnitManagementMode
{
    /// <summary>
    /// Service units are spawned as transient services, with a randomized suffix to avoid overlap.
    /// </summary>
    TransientRandom,

    /// <summary>
    /// Service units are spawned as transient services, with the name fixed and re-used between runs.
    /// </summary>
    /// <remarks>
    /// This isn't the default because I have concerns about the need for past transient units needing to get successfully GC'd by systemd.
    /// </remarks>
    TransientFixed,
}

/// <summary>
/// Which Systemd service manager to connect to.
/// </summary>
/// <seealso cref="SystemdProcessOptions"/>
public enum SystemdManager
{
    /// <summary>
    /// Connect to the session manager for the current user.
    /// </summary>
    /// <remarks>
    /// The session manager must be running, and the watchdog must have the appropriate environment variables set to access the socket.
    /// </remarks>
    Session,

    /// <summary>
    /// Connect to the system global session manager.
    /// </summary>
    /// <remarks>
    /// The watchdog must be ran as root to make use of this.
    /// </remarks>
    System,
}
