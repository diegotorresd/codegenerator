using System.Data;

namespace CodeGeneratorResult
{
    public static class ExtensionMethods
    {
        public static void AddParameter(this IDbCommand command, DbType type, string name, object value)
        {
            var tableIdParameter = command.CreateParameter();
            tableIdParameter.ParameterName = name;
            tableIdParameter.DbType = type;
            tableIdParameter.Value = value;

            command.Parameters.Add(tableIdParameter);
        }

        public static void AddOutParameter(this IDbCommand command, DbType type, string name)
        {
            var tableIdParameter = command.CreateParameter();
            tableIdParameter.ParameterName = name;
            tableIdParameter.DbType = type;
            tableIdParameter.Direction = ParameterDirection.Output;

            command.Parameters.Add(tableIdParameter);
        }
    }
}
