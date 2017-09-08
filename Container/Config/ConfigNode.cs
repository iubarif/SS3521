using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container.Config
{
    /*
     * will be used to read JSON configuration, the configuration file will be stored a client application    
     */

    public class ConfigNode
    {
        public string alias { get; set; }
        public NodeType type { get; set; }
        public int count { get; set; }
        public List<ConfigNode> childs { get; set; }
        public int startIndex { get; set; } = 0;
    }

    public enum NodeType
    {
        Building = 100,
        Freezer = 200,
        Section = 300,
        Frame = 400,
        Rack = 500,
        Shelf = 600,
        Box = 700,
        Position = 1000
    }
}
