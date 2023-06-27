using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Tomlyn;
using Tomlyn.Model;

namespace SS14.Watchdog.Components.ServerManagement
{
	public partial class ServerInstance
	{
		private static string ConfigFileName => "server_config.toml";

		public void CreateConfigParameter(string table, string key, string value)
		{
			var tomlFilePath = Path.Combine(InstanceDir, "bin", ConfigFileName);

			if (!File.Exists(tomlFilePath))
			{
				_logger.LogWarning("{Key}: configuration file not found", Key);

				throw new FileNotFoundException("Configuration file not found");
			}

			var tomlFile = File.ReadAllText(tomlFilePath);

			var tomlData = Toml.ToModel(tomlFile);

			if (!tomlData.TryGetValue(table, out var tableValues))
			{

			}

			if (tableValues is not TomlTable tomlTableValues)
			{
				throw new ArgumentException();
			}

			if (!tomlTableValues.TryGetValue(key, out var keyData))
			{

			}
		}
	}
}
