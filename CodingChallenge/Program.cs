using Laboratory.Domain;
using Laboratory.Domain.Config;
using Microsoft.Practices.Unity;

namespace CodingChallenge
{
    class Program
    {
		static void Main(string[] args)
		{

            // Unity IoC container to resolve dependency injection 
            var container = new UnityContainer();

            container.RegisterType<IFileGenerator, CSVFileGenerator>();
            container.RegisterType<ICustomConfiguration, CustomConfiguration>();
            container.RegisterType<ITreeBuildService, TreeBuildService>();

            InMemoryData datatree = container.Resolve<InMemoryData>();
            
            datatree.GenerateFile();
		}
    }
}
