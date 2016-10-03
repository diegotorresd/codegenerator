using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class ObjectData : List<NameTypePair>
    {
        public string ObjectName
        {
            get
            {
                return this.TableName.UppercaseUnderscoreToPascalCase();
            }
        }
        public string TableName;
        public ObjectData() {}
        public ObjectData(string name)
        {
            this.TableName = name;
        }

        public string PrimaryKeyName;

        public string EntityName
        {
            get
            {
                return this.ObjectName + "Entity";
            }
        }

        public void AddParam(string paramName, Type paramType)
        {
            this.Add(new NameTypePair(paramName, paramType));
        }
    }
}
