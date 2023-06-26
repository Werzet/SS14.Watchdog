using Microsoft.AspNetCore.Mvc;

namespace SS14.Watchdog.Controllers
{
	[Route("/instanceConfiguration/{key}")]
	[Controller]
	public class InstanceConfigurationController : ControllerBase
	{
		[HttpPost("{path}/{value}")]
		public void Create(string path, string value)
		{

		}

		[HttpPut("{path}/{value}")]
		public void Update(string path, string value)
		{

		}

		[HttpDelete("{path}")]
		public void Delete(string path, string value)
		{

		}

		[HttpGet("{path}")]
		public void Get(string path, string value)
		{

		}
	}
}
