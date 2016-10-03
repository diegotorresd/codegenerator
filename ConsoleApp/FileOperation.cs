using System;
using System.IO;

namespace CodeGenerator
{
    public class FileOperation
    {
        public String OutputDir;

        public FileOperation(string outputDir)
        {
            OutputDir = outputDir;
        }

        public void WriteTemplateToFile(GeneratorResult result)
        {
            String outDir = OutputDir;
            if (result.IsTest)
                outDir = Path.Combine(OutputDir, "Tests");

            if (result.Folder != null)
                outDir = Path.Combine(outDir, result.Folder);

            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            String path = Path.Combine(outDir, result.FileName);
            FileInfo fi = new FileInfo(path);
            using (var sw = fi.CreateText())
            {
                sw.Write(result.TemplateText);
            }
            Console.WriteLine(String.Format("Written to {0}", path));
        }
    }
}
