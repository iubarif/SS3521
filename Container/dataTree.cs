using Container.Config;
using System;

namespace Container
{
    /*
     * This class is the entry point of the application. 
     * Collect file generation service and configuration and generates data file
     */
    public class DataTree
	{
		private IFileGenerator _fileGenerator;
		private Place _root;


        // Dependency injection
        public DataTree(IFileGenerator fileGenerator, ConfigNode rootConfiguration)
		{
			_fileGenerator = fileGenerator;
			BuildDataTree(rootConfiguration);
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
                parent = new Place { Alias = currentNode.alias, TypeOfPlace = GetPlaceTypeByNodeType(currentNode.type) };

                if (currentNode.childs != null)
                {
                    if (currentNode.childs.Count > 0)
                    {
                        foreach (var child in currentNode.childs)
                            RecursiveTreeBuild(ref parent, child);
                    }
                }
            }
            else
            {
                if (currentNode.count == 1)
                {
                    var childPlace = new Place { Alias = currentNode.alias, TypeOfPlace = GetPlaceTypeByNodeType(currentNode.type) };

                    parent.AddAsChild(childPlace);

                    if (currentNode.childs != null)
                    {
                        if (currentNode.childs.Count > 0)
                        {
                            foreach (var child in currentNode.childs)
                                RecursiveTreeBuild(ref childPlace, child);
                        }
                    }
                }
                else
                {
                    for (int i = currentNode.startIndex; i < currentNode.startIndex + currentNode.count; i++)
                    {
                        var childPlace = new Place
                        {
                            Alias = $"{currentNode.alias} {(i + 1).ToString()}", TypeOfPlace = GetPlaceTypeByNodeType(currentNode.type)
                        };

                        parent.AddAsChild(childPlace);

                        if (currentNode.childs != null)
                        {
                            if (currentNode.childs.Count > 0)
                            {
                                foreach (var child in currentNode.childs)
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
