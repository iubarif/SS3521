using Container;

namespace CodingChallenge
{
	class Program
    {
        static void Main(string[] args)
        {
			// TODO: invoke your code here, OR use the unit test to invoke your code and compare to one of the two provided expected files.            

			dataTree datatree = new dataTree(new CSVFileGenerator());
			datatree.GenerateFile();
		}
    }
}
