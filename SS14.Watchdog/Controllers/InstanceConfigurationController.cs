using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using SS14.Watchdog.Components.ServerManagement;
using SS14.Watchdog.Utility;

namespace SS14.Watchdog.Controllers
{
	[Route("/instanceConfiguration/{instanceKey}")]
	[Controller]
	public class InstanceConfigurationController : ControllerBase
	{
		private readonly IServerManager _serverManager;

		public InstanceConfigurationController(IServerManager serverManager)
		{
			_serverManager = serverManager;
		}

		[HttpPost("{table}/{key}")]
		public IActionResult Create([FromHeader(Name = "Authorization")] string authorization, string instanceKey, string table, string key, [FromQuery, Required(AllowEmptyStrings = false)] string value)
		{
			if (!TryAuthorize(authorization, instanceKey, out var failure, out var instance))
			{
				return failure;
			}

			instance.CreateConfigParameter(table, key, value);

			return Created($"{table}/{key}", value);
		}

		[HttpPut("{table}/{key}")]
		public void Update([FromHeader(Name = "Authorization")] string authorization, string instanceKey, string table, string key, [FromQuery, Required(AllowEmptyStrings = false)] string value)
		{

		}

		[HttpDelete("{table}/{key}")]
		public void Delete([FromHeader(Name = "Authorization")] string authorization, string instanceKey, string table, string key)
		{

		}

		[HttpGet("{table}/{key}")]
		public void Get([FromHeader(Name = "Authorization")] string authorization, string instanceKey, string table, string key)
		{

		}

		private bool TryAuthorize(string authorization,
			string key,
			[NotNullWhen(false)] out IActionResult? failure,
			[NotNullWhen(true)] out IServerInstance? instance)
		{
			instance = null;

			if (!AuthorizationUtility.TryParseBasicAuthentication(authorization, out failure, out var authKey,
				out var token))
			{
				return false;
			}

			if (authKey != key)
			{
				failure = Forbid();
				return false;
			}

			if (!_serverManager.TryGetInstance(key, out instance))
			{
				failure = NotFound();
				return false;
			}

			// TODO: we probably need constant-time comparisons for this?
			// Maybe?
			if (token != instance.ApiToken)
			{
				failure = Unauthorized();
				return false;
			}

			return true;
		}
	}
}
