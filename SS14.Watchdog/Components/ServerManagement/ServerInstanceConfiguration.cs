using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Tomlyn;
using Tomlyn.Model;
using YamlDotNet.Core.Tokens;

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
				var newTable = new TomlTable
				{
					{ key, value }
				};

				tomlData.Add(table, newTable);
			}
			else
			{
				if (tableValues is not TomlTable tomlTableValues)
				{
					throw new ArgumentException($"{table} in not {nameof(TomlTable)}. Check configuration file for correct.");
				}

				tomlTableValues[key] = value;

				//if (!tomlTableValues.TryGetValue(key, out var keyData))
				//{
				//	tomlTableValues.Add(key, value);
				//}
				//else
				//{
				//	ke
				//}
			}

			File.WriteAllText(tomlFilePath, Toml.FromModel(tomlData));
		}

		//public void Update(string table, string key, string value)
		////{
		////	var tomlFile = File.ReadAllText(tomlFilePath);

		////	var tomlData = Toml.ToModel(tomlFile);

		////	if (!tomlData.TryGetValue(table, out var tableValues))
		////	{
		////		throw new ArgumentException($"{table} in configuration not found");
		////	}

		////	if (tableValues is not TomlTable tomlTableValues)
		////	{
		////		throw new ArgumentException($"{table} in not {nameof(TomlTable)}. Check configuration file for correct.");
		////	}

		////	if (!tomlTableValues.TryGetValue(key, out var keyData))
		////	{

		////	}
		//}
	}
}
