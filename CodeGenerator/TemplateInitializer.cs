using CodeGenerator.Connectors;
using Converters.Interfaces;
using System;
using System.Collections.Generic;

namespace CodeGenerator
{
    internal class TemplateInitializer : IDisposable
    {
        private IConverter Converter;
        private string TableName;
        private List<string> ProceduresName;

        public TemplateInitializer(string tableName, string connectionName)
        {
            this.TableName = tableName;

            var connectorFactory = new ConverterFactory(connectionName);
            this.Converter = connectorFactory.CreateConverter();

            this.ProceduresName = new List<string> { "PR_UPDATE", "PR_GET", "PR_INSERT", "PR_GET_ALL", "PR_DELETE" };
        }

        public TemplateData GetTemplateData()
        {
            var templateData = new TemplateData(Converter.GetObjectDataFromTable(TableName));
            
            ProceduresName.ForEach(name => {
                var procedure = Converter.GetProcedure(name, templateData.ObjectData);
                templateData.AddProcedureDataList(procedure);
            });

            return templateData;
        }

        public void Dispose()
        {
            this.Converter.Dispose();
        }
    }
}
