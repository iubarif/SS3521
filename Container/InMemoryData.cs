using Container.Config;
using System;

namespace Container
{
    /*
     * This class is the entry point of the application. 
     * Collect file generation service and configuration and generates data file
     */
    public class InMemoryData
	{
		private IFileGenerator _fileGenerator;
		private ICustomConfiguration _customConfiguration;
		private Place _root;


        // Dependency injection
        public InMemoryData(IFileGenerator fileGenerator, ICustomConfiguration customConfiguration)
		{
			_fileGenerator = fileGenerator;
			_customConfiguration = customConfiguration;

			BuildDataTree(_customConfiguration.GetDataStructureConfiguration());
		}

        private void BuildDataTree(ConfigNode rootConfiguration)
        {
            RecursiveTreeBuild(ref _root, rootConfiguration);
        }

        // Build in memory tree data structure from provided JSON configuration
        private void RecursiveTreeBuild(ref Place parent, ConfigNode currentNode)
        {
            if (parent == null)
            {
                parent = new Place { Alias = currentNode.Alias, TypeOfPlace = GetPlaceTypeByNodeType(currentNode.Type) };

                if (currentNode.Childs != null)
                {
                    if (currentNode.Childs.Count > 0)
                    {
                        foreach (var child in currentNode.Childs)
                            RecursiveTreeBuild(ref parent, child);
                    }
                }
            }
            else
            {
                if (currentNode.Count == 1)
                {
                    var childPlace = new Place { Alias = currentNode.Alias, TypeOfPlace = GetPlaceTypeByNodeType(currentNode.Type) };

                    parent.AddAsChild(childPlace);

                    if (currentNode.Childs != null)
                    {
                        if (currentNode.Childs.Count > 0)
                        {
                            foreach (var child in currentNode.Childs)
                                RecursiveTreeBuild(ref childPlace, child);
                        }
                    }
                }
                else
                {
                    for (int i = currentNode.StartIndex; i < currentNode.StartIndex + currentNode.Count; i++)
                    {
                        var childPlace = new Place
                        {
                            Alias = $"{currentNode.Alias} {(i + 1).ToString()}", TypeOfPlace = GetPlaceTypeByNodeType(currentNode.Type)
                        };

                        parent.AddAsChild(childPlace);

                        if (currentNode.Childs != null)
                        {
                            if (currentNode.Childs.Count > 0)
                            {
                                foreach (var child in currentNode.Childs)
                                    RecursiveTreeBuild(ref childPlace, child);
                            }
                        }
                    }
                }
            }


        }

        private PlaceType GetPlaceTypeByNodeType(NodeType nodeType)
        {
            switch (nodeType)
            {
                case NodeType.Building:
                    return PlaceType.Building;
                case NodeType.Freezer:
                    return PlaceType.Freezer;
                case NodeType.Section:
                    return PlaceType.Section;
                case NodeType.Frame:
                    return PlaceType.Frame;
                case NodeType.Rack:
                    return PlaceType.Rack;
                case NodeType.Shelf:
                    return PlaceType.Shelf;
                case NodeType.Box:
                    return PlaceType.Box;
                case NodeType.Position:
                    return PlaceType.Position;
                default:
                    return PlaceType.Position;
            }
        }

        public void GenerateFile()
		{
            if (_root != null)
            {
                _fileGenerator.GenerateFile(_root);
            }
            else {
                throw new Exception("Call BuildDataTree function before generating File!.");
            }
        }
	}
}
