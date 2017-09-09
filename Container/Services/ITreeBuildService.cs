using Laboratory.Domain.Config;

namespace Laboratory.Domain
{
    // Build in memory tree data structure from provided JSON configuration

    public interface ITreeBuildService
    {
        IPlace RecursiveTreeBuild(IPlace parent, ConfigNode currentNode);
    }
}
