using CodeGenerator.Templates;
using System;

namespace CodeGenerator.Generators
{
    internal abstract class Generator
    {
        protected TemplateData templateData;

        public Generator(TemplateData _templateData)
        {
            this.templateData = _templateData;
        }

        public abstract GeneratorResult Generate();

        protected GeneratorResult Generate(string filename, string folder, Boolean isTest = false)
        {
            return new GeneratorResult()
            {
                TemplateText = GetTemplate().TransformText(),
                FileName = filename,
                ObjectName = templateData.ObjectData.ObjectName,
                Folder = folder,
                IsTest = isTest
            };
        }

        internal abstract DataTemplate GetTemplate();
    }

}
