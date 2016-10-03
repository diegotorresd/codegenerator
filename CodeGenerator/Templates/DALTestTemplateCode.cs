using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Templates
{
    public partial class DALTestTemplate : TestTemplate
    {
        public DALTestTemplate(TemplateData templateData)
            : base(templateData)
        {

        }

        protected void SetupGet()
        {
            PushIndent("\t\t\t");
            foreach (var field in templateData.ObjectData)
            {
                WriteLine("Reader.SetupGet(r => r[\"{0}\"]).Returns(TestEntity.{1});", field.ColumnName, field.PropertyName);
            }
            PopIndent();
        }
    }
}
