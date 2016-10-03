using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class GeneratorResult
    {
        public string TemplateText;
        public string FileName { get; set; }
        public Boolean IsTest;
        public string Folder { get; set; }
        public string ObjectName { get; set; }

        public GeneratorResult()
        {
            IsTest = false;
        }
    }
}
