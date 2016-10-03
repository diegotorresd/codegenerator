using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Templates
{
    public partial class DALTemplate : DataTemplate
    {
        public DALTemplate(TemplateData templateData)
            : base(templateData)
        {

        }
        public void WriteCommandParameters(ProcedureData procTemplate)
        {
            foreach (var p in procTemplate)
            {
                var parameter = (ProcedureParameter)p;
                PushIndent("\t\t\t");
                WriteLine("cmd.AddParameter(DbType.{0}, \"{1}\", ent.{2});",
                    parameter.Type.Name,
                    parameter.ParameterName,
                    parameter.PropertyName);
                PopIndent();
            }
        }
    }
}
