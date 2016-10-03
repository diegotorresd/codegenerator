using CodeGenerator.FileTypes;
using CodeGenerator.Generators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator
{
    public class GeneratorManager
    {
        private List<string> TableNames;
        private List<FileType> FileTypes;
        private string ConnectionName;

        public Dictionary<string,List<GeneratorResult>> Results;
        public GeneratorResult ProjectFileResult;
        public GeneratorResult TestProjectFileResult;

        public GeneratorResult DALFactoryFileResult { get; private set; }
        public GeneratorResult LogicFactoryFileResult { get; private set; }

        public GeneratorManager(List<string> tableNames, List<FileType> fileTypes, string connectionName)
        {
            this.TableNames = tableNames;
            this.FileTypes = fileTypes;
            this.ConnectionName = connectionName;
            this.Results = new Dictionary<string, List<GeneratorResult>>();
        }

        public void Execute()
        {
            foreach (var tableName in TableNames)
            {
                GenerateFor(tableName);
            }
            GenerateFactoryFiles();
            GenerateProjectFiles();
        }

        private void GenerateFactoryFiles()
        {
            var factoryFileGenerator = new FactoryFileGenerator();
            var objectNames = Results.Select(r => r.Key);
            DALFactoryFileResult = factoryFileGenerator.GenerateDALFactory(objectNames);
            LogicFactoryFileResult = factoryFileGenerator.GenerateLogicFactory(objectNames);
        }

        private void GenerateProjectFiles()
        {
            var projectFileGenerator = new ProjectFileGenerator();
            var fileNames = Results.SelectMany(r => r.Value).Where(r => !r.IsTest);
            var testFileNames = Results.SelectMany(r => r.Value).Where(r => r.IsTest);

            ProjectFileResult = projectFileGenerator.GenerateProjectFile(fileNames);
            TestProjectFileResult = projectFileGenerator.GenerateTestProjectFile(testFileNames);
        }

        private void GenerateFor(string tableName)
        {
            using (var initializer = new TemplateInitializer(tableName, ConnectionName))
            {
                var templateData = initializer.GetTemplateData();
                var generatorFactory = new GeneratorFactory(templateData);
                var fileResults = new List<GeneratorResult>();
                foreach (var fileType in FileTypes)
                {
                    var generator = generatorFactory.GetGeneratorFor(fileType);
                    var result = generator.Generate();
                    fileResults.Add(result);
                }
                Results.Add(templateData.ObjectData.ObjectName, fileResults);
            }
        }
    }
}
