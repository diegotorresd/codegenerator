using CodeGenerator.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Generators
{
    class FactoryFileGenerator
    {
        public GeneratorResult GenerateDALFactory(IEnumerable<string> generatorResults)
        {
            var dalFactoryTemplate = new DALFactoryTemplate(generatorResults.ToList());
            return Generate(dalFactoryTemplate.TransformText(), "DALFactory.cs", "DAL");            
        }
        public GeneratorResult GenerateLogicFactory(IEnumerable<string> generatorResults)
        {
            var logicFactoryTemplate = new LogicFactoryTemplate(generatorResults.ToList());
            return Generate(logicFactoryTemplate.TransformText(), "LogicFactory.cs", "Logic");
        }

        private GeneratorResult Generate(string templateText, string fileName, string folder)
        {
            return new GeneratorResult()
            {
                TemplateText = templateText,
                FileName = fileName,
                Folder = folder
            };
        }
    }
}
