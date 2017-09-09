using Container;
using Container.Config;

namespace CodingChallenge
{
	class Program
    {
		static void Main(string[] args)
		{
			InMemoryData datatree = new InMemoryData(new CSVFileGenerator(), new CustomConfiguration());
			datatree.GenerateFile();
		}
    }
}
