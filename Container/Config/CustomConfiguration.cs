using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container.Config
{
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
