using Laboratory.Domain.Config;

namespace Laboratory.Domain
{
    // This Implementation is for Place concrete class 
    public class TreeBuildService : ITreeBuildService
    {

        // Build in memory tree data structure from provided JSON configuration

        public IPlace RecursiveTreeBuild(IPlace parent, ConfigNode currentNode)
        {
            if (parent == null)
            {
                parent = new Place { Alias = currentNode.Alias, TypeOfPlace = GetPlaceTypeByNodeType(currentNode.Type) };

                if (currentNode.Childs != null)
                {
                    if (currentNode.Childs.Count > 0)
                    {
                        foreach (var child in currentNode.Childs)
                            RecursiveTreeBuild(parent, child);
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
                                RecursiveTreeBuild(childPlace, child);
                        }
                    }
                }
                else
                {
                    for (int i = currentNode.StartIndex; i < currentNode.StartIndex + currentNode.Count; i++)
                    {
                        var childPlace = new Place
                        {
                            Alias = $"{currentNode.Alias} {(i + 1).ToString()}",
                            TypeOfPlace = GetPlaceTypeByNodeType(currentNode.Type)
                        };

                        parent.AddAsChild(childPlace);

                        if (currentNode.Childs != null)
                        {
                            if (currentNode.Childs.Count > 0)
                            {
                                foreach (var child in currentNode.Childs)
                                    RecursiveTreeBuild(childPlace, child);
                            }
                        }
                    }
                }
            }

            return parent;
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

    }
}
