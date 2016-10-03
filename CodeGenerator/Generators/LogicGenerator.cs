using CodeGenerator.Templates;
using System;

namespace CodeGenerator.Generators
{
    internal class LogicGenerator : Generator
    {
        public LogicGenerator(TemplateData templateData) : base(templateData) { }

        public override GeneratorResult Generate()
        {
            return Generate(
                String.Format("{0}Logic.cs", templateData.ObjectData.ObjectName), 
                "Logic");
        }

        internal override DataTemplate GetTemplate()
        {
            return new LogicTemplate(templateData);
        }
    }
}
