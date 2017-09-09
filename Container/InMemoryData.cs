using Laboratory.Domain.Config;
using System;

namespace Laboratory.Domain
{
    /*
     * This class is the entry point of the application. 
     * Collect file generation service and configuration and generates data file
     */
    public class InMemoryData
    {
        private IFileGenerator _fileGenerator;
        private ICustomConfiguration _customConfiguration;
        private ITreeBuildService _treeBuildService;

        // Dependency injection
        public InMemoryData(IFileGenerator fileGenerator,
            ICustomConfiguration customConfiguration,
            ITreeBuildService treeBuildService
            )
        {
            _fileGenerator = fileGenerator;
            _customConfiguration = customConfiguration;
            _treeBuildService = treeBuildService;

        }
        
        public void GenerateFile()
        {

            IPlace rootOfTheTree = null;

            rootOfTheTree = _treeBuildService.RecursiveTreeBuild(
                rootOfTheTree, 
                _customConfiguration.GetDataStructureConfiguration()
                );

            if (rootOfTheTree != null)
            {
                _fileGenerator.GenerateFile(rootOfTheTree);
            }
            else
            {
                throw new Exception("Call BuildDataTree function before generating File!.");
            }
        }
    }
}
