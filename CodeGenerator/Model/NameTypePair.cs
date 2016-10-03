using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class NameTypePair
    {
        public string ColumnName;
        public Type Type;

        public virtual string PropertyName
        {
            get
            {
                return this.ColumnName.UppercaseUnderscoreToPascalCase();
            }
        }
        public string VariableName
        {
            get
            {
                string value = this.PropertyName;
                return string.Format("{0}{1}", Char.ToLower(value[0]), value.Substring(1));
            }
        }

        public NameTypePair(string columnName, Type type)
        {
            this.ColumnName = columnName;
            this.Type = type;
        }   
    }
}
