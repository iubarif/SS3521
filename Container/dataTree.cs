using Container.Config;
using System;

namespace Container
{
    /*
     * This class is the entry point of the application. 
     * Collect file generation service and configuration and generates data file
     */
    public class dataTree
	{
		private IFileGenerator _fileGenerator;
		private place _root;


        // Dependency injection
        public dataTree(IFileGenerator fileGenerator, node rootConfiguration)
		{
			_fileGenerator = fileGenerator;
			BuildDataTree(rootConfiguration);
		}

        private void BuildDataTree(node rootConfiguration)
        {
            recursiveTreeBuild(ref _root, rootConfiguration);
        }

        // Build in memory tree data structure from provided JSON configuration
        private void recursiveTreeBuild(ref place parent, node currentNode)
        {
            if (parent == null)
            {
                parent = new place { Alias = currentNode.alias, TypeOfPlace = getPlaceTypeByNodeType(currentNode.type) };

                if (currentNode.childs != null)
                {
                    if (currentNode.childs.Count > 0)
                    {
                        foreach (var child in currentNode.childs)
                            recursiveTreeBuild(ref parent, child);
                    }
                }
            }
            else
            {
                if (currentNode.count == 1)
                {
                    var childPlace = new place { Alias = currentNode.alias, TypeOfPlace = getPlaceTypeByNodeType(currentNode.type) };

                    parent.AddAsChild(childPlace);

                    if (currentNode.childs != null)
                    {
                        if (currentNode.childs.Count > 0)
                        {
                            foreach (var child in currentNode.childs)
                                recursiveTreeBuild(ref childPlace, child);
                        }
                    }
                }
                else
                {
                    for (int i = currentNode.startIndex; i < currentNode.startIndex + currentNode.count; i++)
                    {
                        var childPlace = new place
                        {
                            Alias = string.Format("{0} {1}", currentNode.alias, (i + 1).ToString())
                            ,
                            TypeOfPlace = getPlaceTypeByNodeType(currentNode.type)
                        };

                        parent.AddAsChild(childPlace);

                        if (currentNode.childs != null)
                        {
                            if (currentNode.childs.Count > 0)
                            {
                                foreach (var child in currentNode.childs)
                                    recursiveTreeBuild(ref childPlace, child);
                            }
                        }
                    }
                }
            }


        }

        private placeType getPlaceTypeByNodeType(nodeType nodeType)
        {
            switch (nodeType)
            {
                case nodeType.Building:
                    return placeType.Building;
                case nodeType.Freezer:
                    return placeType.Freezer;
                case nodeType.Section:
                    return placeType.Section;
                case nodeType.Frame:
                    return placeType.Frame;
                case nodeType.Rack:
                    return placeType.Rack;
                case nodeType.Shelf:
                    return placeType.Shelf;
                case nodeType.Box:
                    return placeType.Box;
                case nodeType.Position:
                    return placeType.Position;
                default:
                    return placeType.Position;
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
