using System.Collections.Generic;

namespace CodeGenerator.Templates
{
    public partial class LogicFactoryTemplate
    {
        private List<string> ObjectNames;

        public LogicFactoryTemplate(List<string> objectNames)
        {
            ObjectNames = objectNames;
        }
    }
}
