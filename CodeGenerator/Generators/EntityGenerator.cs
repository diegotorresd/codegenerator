using CodeGenerator.Templates;
using System;

namespace CodeGenerator.Generators
{
    internal class EntityGenerator : Generator
    {
        public EntityGenerator(TemplateData templateData) : base(templateData) { }

        public override GeneratorResult Generate()
        {
            return Generate(
                String.Format("{0}Entity.cs", templateData.ObjectData.ObjectName),
                "Entities");
        }

        internal override DataTemplate GetTemplate()
        {
            return new EntityTemplate(templateData);
        }
    }
}
