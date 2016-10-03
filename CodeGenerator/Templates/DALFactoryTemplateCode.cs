using System.Collections.Generic;

namespace CodeGenerator.Templates
{
    public partial class DALFactoryTemplate
    {
        private List<string> ObjectNames;

        public DALFactoryTemplate(List<string> objectNames)
        {
            ObjectNames = objectNames;
        }
    }
}
