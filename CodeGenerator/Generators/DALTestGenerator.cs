using CodeGenerator.Templates;
using System;

namespace CodeGenerator.Generators
{
    internal class DALTestGenerator : Generator
    {
        public DALTestGenerator(TemplateData templateData) : base(templateData) { }

        public override GeneratorResult Generate()
        {
            return Generate(
                String.Format("{0}DALTests.cs", templateData.ObjectData.ObjectName), 
                "DAL", 
                isTest: true);
        }

        internal override DataTemplate GetTemplate()
        {
            return new DALTestTemplate(templateData);
        }
    }
}
