using CodeGenerator.Templates;
using System;

namespace CodeGenerator.Generators
{
    internal class LogicTestGenerator : Generator
    {
        public LogicTestGenerator(TemplateData templateData) : base(templateData) { }

        public override GeneratorResult Generate()
        {
            return Generate(
                String.Format("{0}LogicTests.cs", templateData.ObjectData.ObjectName), 
                "Logic", 
                isTest: true);
        }

        internal override DataTemplate GetTemplate()
        {
            return new LogicTestTemplate(templateData);
        }
    }
}
