using CodeGenerator;
using CodeGenerator.Error;
using Converters.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Converters
{
    internal class OracleConverter : IConverter
    {
        private string DatabaseUserId;
        private Dictionary<string, Type> TypeAssoc = new Dictionary<string, Type>()
        {
            {"NUMBER", typeof(int)},
            {"VARCHAR2", typeof(string)},
            {"DATE", typeof(DateTime)},
            {"CHAR", typeof(bool)}
        };

        private IDbConnection DbConnection;

        public OracleConverter(IDbConnection dbConnection)
        {
            this.DbConnection = dbConnection;
            this.DbConnection.Open();
        }

        public OracleConverter(IDbConnection dbConnection, string databaseUserId) : this(dbConnection)
        {
            this.DatabaseUserId = databaseUserId;
        }

        public ObjectData GetObjectDataFromTable(string tableName)
        {
            var result = new ObjectData(tableName);

            string cmdText = "select t.COLUMN_NAME, t.DATA_TYPE, cons.CONSTRAINT_TYPE " +
                              "from USER_TAB_COLUMNS t " +
                              "left join all_cons_columns cols " +
                              "on t.TABLE_NAME = cols.TABLE_NAME " +
                              "and t.COLUMN_NAME = cols.COLUMN_NAME " +
                              "left join all_constraints cons " +
                              "on cols.CONSTRAINT_NAME = cons.CONSTRAINT_NAME " +
                              "where t.table_name = :tableName " +
                              "and (cons.constraint_type is null or cons.constraint_type = 'P')";

            try
            {
                var cmd = DbConnection.CreateCommand();
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;

                cmd.AddParameter(DbType.String, "tableName", tableName);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader.GetString(0);
                    string dataType = reader.GetString(1);
                    result.AddParam(columnName, TypeAssoc[dataType]);
                    if (!reader.IsDBNull(2))
                    {
                        string constraint = reader.GetString(2);                       
                        if (constraint == "P")
                        {
                            result.PrimaryKeyName = columnName;
                        }
                    }
                }

                if (result.Count == 0)
                    throw new TableMetadataRetrievalException(null, tableName);
            }
            catch (Exception ex)
            {
                throw new TableMetadataRetrievalException(ex, tableName);
            }
            return result;
        }

        private List<ProcedureParameter> GetProcedureParams(string tableName, string procName, string owner = "")
        {
            var result = new List<ProcedureParameter>();
            string cmdTextFormat = "SELECT ARGUMENT_NAME, DATA_TYPE, IN_OUT " +
                                "FROM SYS.ALL_ARGUMENTS " +
                                "WHERE PACKAGE_NAME = :pkgName AND " +
                                "{0} " +
                                "OBJECT_NAME = :procName AND " +
                                "argument_name NOT IN ('PO_SQL_ERROR', 'CUR_OUT') " +
                                "ORDER BY POSITION";

            var cmd = DbConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string cmdText = String.Format(cmdTextFormat, "");

            if (!String.IsNullOrEmpty(owner))
            {
                cmdText = String.Format(cmdTextFormat, "OWNER = :packageOwner AND ");
            }
            cmd.CommandText = cmdText;

            cmd.AddParameter(DbType.String, "pkgName", "PKG_" + tableName);

            if (!String.IsNullOrEmpty(owner))
                cmd.AddParameter(DbType.String, "packageOwner", owner);

            cmd.AddParameter(DbType.String, "procName", procName);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string argName = reader.GetString(0);
                string argType = reader.GetString(1);
                string inOut = reader.GetString(2);
                result.Add(new ProcedureParameter(argName, TypeAssoc[argType], inOut));
            }

            if (result.Count == 0)
                throw new ProcedureMetadataRetrievalException(null, tableName, procName);

            return result;
        }

        public ProcedureData GetProcedure(string procName, ObjectData columnTemplate)
        {
            var procTemplate = new ProcedureData(columnTemplate.TableName, procName);
            try
            {
                var list = GetProcedureParams(columnTemplate.TableName, procName, DatabaseUserId);
                foreach (var parameter in list.FindAll(p => p.InOut == "IN"))
                {
                    var match = columnTemplate.Find(t => t.ColumnName.Equals(parameter.ColumnName));
                    if (match != null)
                        procTemplate.Add(parameter);
                }

                procTemplate.OutParam = list.FirstOrDefault(p => p.InOut == "OUT");
            }
            catch (Exception ex)
            {
                throw new ProcedureMetadataRetrievalException(ex, columnTemplate.TableName, procName);
            }

            return procTemplate;
        }

        public void Dispose()
        {
            this.DbConnection.Dispose();
        }
    }
}
