using System.Collections.Generic;

namespace Container.Config
{
	/*
     * will be used to read JSON configuration, the configuration file will be stored a client application    
     */

	public class ConfigNode
    {
        public string Alias { get; set; }
        public NodeType Type { get; set; }
        public int Count { get; set; }
        public List<ConfigNode> Childs { get; set; }
        public int StartIndex { get; set; } = 0;
    }
}
