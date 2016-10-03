using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class Options
    {
        [OptionArray('t', "tableNames", Required = true,
            HelpText = "List of tables to be processed")]
        public String[] TableNames { get; set; }

        [OptionArray('f', "fileTypes", Required = false,
            HelpText = "File types: list of Entity, DAL, DALTest, Logic, LogicTest")]
        public String[] FileTypes { get; set; }

        [Option('o', "outputDir", Required = false,
            DefaultValue = "Results")]
        public String OutputDir { get; set; }

        //TODO Default Value of ConnectionName
        [Option('c', "connectionName", Required = true,
           DefaultValue = "XE")]
        public String ConnectionName { get; set; }


        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
            (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }


}
