using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Templates
{
    public partial class ProjectFileTemplate
    {
        public List<GeneratorResult> FilesToInclude;
        public ProjectFileTemplate()
        {

        }
        public ProjectFileTemplate(List<GeneratorResult> files)
        {
            FilesToInclude = files;
        }

        public void WriteIncludes()
        {
            foreach (var f in FilesToInclude)
            {
                PushIndent("\t");
                WriteLine("<Compile Include=\"{0}\\{1}\" />", f.Folder, f.FileName);
                PopIndent();
            }
        }
    }
}
