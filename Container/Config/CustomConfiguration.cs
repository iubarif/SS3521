using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;

namespace Laboratory.Domain.Config
{
    // Get data structure configuration from JSON configuration file
    public class CustomConfiguration : ICustomConfiguration
	{
		public ConfigNode GetDataStructureConfiguration()
		{
			var appSettings = ConfigurationManager.AppSettings;

			if (!string.IsNullOrEmpty(appSettings["DSConfigFile"]))
			{
				return JsonConvert.DeserializeObject<ConfigNode>(File.ReadAllText(appSettings["DSConfigFile"]));
			}
			else
			{
				throw new Exception("DSConfigFile file setting is missing!");
			}
		}
	}
}
