
namespace Laboratory.Domain.Config
{
	public interface ICustomConfiguration
	{
        // Get data structure configuration from JSON or other kinds of  configuration file
        ConfigNode GetDataStructureConfiguration();
	}
}
