using MiCaseCodeGeneratorResult.Connection;
using System.Configuration;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System;

namespace DAL
{
    internal class ConnectionFactory
    {
        private const string CURRENT_CONNECTION = "CurrentConnection";

        private string CurrentConnection;
        private string ConnectionString;
        private string ProviderName;

        public ConnectionFactory()
        {
            CurrentConnection = ConfigurationManager.AppSettings[CURRENT_CONNECTION];
            ConnectionString = ConfigurationManager.ConnectionStrings[CurrentConnection].ConnectionString;
            ProviderName = ConfigurationManager.ConnectionStrings[CurrentConnection].ProviderName;
        }

        public IDbConnection Create()
        {
            if (ProviderName == ConnectorType.ORA.ToString())
                return new OracleConnection(ConnectionString);

            //TODO Implement others connection MySQL... SQL... etc
            throw new Exception("Not valid connection type.");
        }
    }
}