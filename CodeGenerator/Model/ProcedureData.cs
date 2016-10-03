using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class ProcedureData : ObjectData
    {
        public string PackageName
        {
            get
            {
                return "PKG_" + this.TableName;
            }
        }
        public string ProcedureName;

        public ProcedureParameter OutParam;

        public ProcedureParameter InParam
        {
            get
            {
                return (ProcedureParameter)this.First();
            }
        }

        public ProcedureData(string tableName, string procedureName)
            : base(tableName)
        {
            this.ProcedureName = procedureName;
        }

    }
}
