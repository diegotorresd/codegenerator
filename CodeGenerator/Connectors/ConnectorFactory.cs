using System;
using System.Configuration;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Converters.Interfaces;
using Converters;

namespace CodeGenerator.Connectors
{
    class ConverterFactory
    {
        private string ProviderName;
        private string ConnectionString;
        private string DatabaseUserId;

        public ConverterFactory(string connectionName)
        {
            ConnectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            ProviderName = ConfigurationManager.ConnectionStrings[connectionName].ProviderName;
            var builder = new OracleConnectionStringBuilder(ConnectionString);
            DatabaseUserId = builder.UserID;
        }

        public IConverter CreateConverter()
        {
            if (ProviderName == ConnectorType.ORA.ToString())
               return new OracleConverter(new OracleConnection(ConnectionString), DatabaseUserId);

            //TODO Implement MySQL and SQL...

            throw new Exception("Not valid converter type.");
        }
    }
}
