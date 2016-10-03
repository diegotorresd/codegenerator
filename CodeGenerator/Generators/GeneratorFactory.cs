using CodeGenerator.FileTypes;
using System;

namespace CodeGenerator.Generators
{
    internal class GeneratorFactory
    {
        private TemplateData TemplateData;

        public GeneratorFactory(TemplateData templateData)
        {
            this.TemplateData = templateData;
        }

        public Generator GetGeneratorFor(FileType fileType)
        {
            if (fileType == FileType.Entity)
                return new EntityGenerator(TemplateData);

            if (fileType == FileType.DAL)
                return new DALGenerator(TemplateData);

            if (fileType == FileType.DALTest)
                return new DALTestGenerator(TemplateData);

            if (fileType == FileType.Logic)
                return new LogicGenerator(TemplateData);

            if (fileType == FileType.LogicTest)
                return new LogicTestGenerator(TemplateData);

            throw new NotImplementedException();
        }
    }
}
