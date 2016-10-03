using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Templates
{
    public class DataTemplate : BaseTemplate
    {
        protected TemplateData templateData;
        public DataTemplate()
        {

        }
        public DataTemplate(TemplateData _templateData)
        {
            this.templateData = _templateData;
        }
    }
}
