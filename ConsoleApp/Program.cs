using CodeGenerator.Error;
using CodeGenerator.FileTypes;
using System;
using System.Linq;

namespace CodeGenerator
{
    class Program
    {
        private static int Main(string[] args)
        {
            try
            {
                var options = GetOptions(args);
                var tableNames = options.TableNames.ToList();
                var fileTypes = new FileTypesGenerator(options.FileTypes).GetFileTypes().ToList();
                var connectionName = options.ConnectionName;

                var manager = new GeneratorManager(tableNames, fileTypes, connectionName);
                manager.Execute();

                var fileOps = new FileOperation(options.OutputDir);

                var results = manager.Results.SelectMany(r => r.Value).ToList();
                results.ForEach(result => fileOps.WriteTemplateToFile(result));
                fileOps.WriteTemplateToFile(manager.ProjectFileResult);
                fileOps.WriteTemplateToFile(manager.TestProjectFileResult);
                fileOps.WriteTemplateToFile(manager.DALFactoryFileResult);
                fileOps.WriteTemplateToFile(manager.LogicFactoryFileResult);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.ParamName + " does not exist");
                return (int)ExitCode.ArgumentError;
            }
            catch (CodeGeneratorException ex)
            {
                Console.WriteLine(ex.ErrorMessage);
                return (int)ex.ErrorCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (int)ExitCode.GenericError;
            }

            return (int)ExitCode.Success;
        }

        private static Options GetOptions(string[] args)
        {
            try
            {
                var options = new Options();
                CommandLine.Parser.Default.ParseArguments(args, options);
                return options;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
