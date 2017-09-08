using Container;
using Container.Config;
using Newtonsoft.Json;
using System.IO;

namespace CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: invoke your code here, OR use the unit test to invoke your code and compare to one of the two provided expected files.                        
            var node = JsonConvert.DeserializeObject<node>(File.ReadAllText(@"..\..\Config\tree.json"));

            dataTree datatree = new dataTree(new CSVFileGenerator(), node);
            datatree.GenerateFile();            
        }
    }
}
