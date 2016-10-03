using CodeGenerator.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    internal class ProjectFileGenerator
    {
        public GeneratorResult GenerateProjectFile(IEnumerable<GeneratorResult> fileNames)
        {
            var projectFileTemplate = new ProjectFileTemplate(fileNames.ToList());
            return new GeneratorResult()
            {
                TemplateText = projectFileTemplate.TransformText(),
                FileName = "MiCaseCodeGeneratorResult.csproj"
            };
        }

        public GeneratorResult GenerateTestProjectFile(IEnumerable<GeneratorResult> fileNames)
        {
            var testProjectFileTemplate = new TestProjectFileTemplate(fileNames.ToList());
            return new GeneratorResult()
            {
                TemplateText = testProjectFileTemplate.TransformText(),
                FileName = "MiCaseCodeGeneratorResultTests.csproj",
                IsTest = true
            };
        }


    }
}
