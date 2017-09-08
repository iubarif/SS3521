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
            var node = JsonConvert.DeserializeObject<ConfigNode>(File.ReadAllText(@"..\..\Config\tree.json"));

            DataTree datatree = new DataTree(new CSVFileGenerator(), node);
            datatree.GenerateFile();            
        }
    }
}
