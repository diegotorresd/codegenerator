using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class ProcedureParameter : NameTypePair
    {
        public string ParameterName;
        public string InOut;

        public ProcedureParameter(string parameterName, Type type, string inOut)
            : base(parameterName.ProcedureParameterNameToColumnName(), type)
        {
            this.ParameterName = parameterName;
            this.InOut = inOut;
        }
    }
}
