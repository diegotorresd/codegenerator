using CodeGenerator.Templates;
using System;

namespace CodeGenerator.Generators
{
    internal class DALGenerator : Generator
    {
        public DALGenerator(TemplateData templateData) : base(templateData) { }

        internal override DataTemplate GetTemplate()
        {
            return new DALTemplate(templateData);
        }

        public override GeneratorResult Generate()
        {
            return Generate(
                String.Format("{0}DAL.cs", templateData.ObjectData.ObjectName), 
                "DAL");
        }
    }
}
