using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Error
{
    public abstract class CodeGeneratorException : Exception
    {
        public abstract string ErrorMessage { get; }
        public abstract ErrorCode ErrorCode { get; }

        public CodeGeneratorException()
        {

        }

        public CodeGeneratorException(Exception innerException) : base("", innerException)
        {

        }
    }

    public class DataConnectorException : CodeGeneratorException
    {
        public override string ErrorMessage
        {
            get
            {
                return "Could not initialize the database connection";
            }
        }

        public override ErrorCode ErrorCode
        {
            get
            {
                return ErrorCode.DataConnectorError;
            }
        }

        public DataConnectorException(Exception innerException) : base(innerException)
        {

        }
    }

    public class TableMetadataRetrievalException : CodeGeneratorException
    {
        private string TableName;
        public override string ErrorMessage
        {
            get
            {
                return string.Format("Could not retrieve metadata for table {0}", TableName);
            }
        }

        public override ErrorCode ErrorCode
        {
            get
            {
                return ErrorCode.TableMetadataRetrievalError;
            }
        }

        public TableMetadataRetrievalException(Exception innerException, string tableName) : base(innerException)
        {
            this.TableName = tableName;
        }
    }

    public class ProcedureMetadataRetrievalException : CodeGeneratorException
    {
        private string TableName;
        private string ProcedureName;
        public ProcedureMetadataRetrievalException(Exception innerException, string tableName, string procedureName)
            : base(innerException)
        {
            this.TableName = tableName;
            this.ProcedureName = procedureName;
        }

        public override string ErrorMessage
        {
            get
            {
                return string.Format("Could not retrieve metadata for procedure {1} in table {0}", TableName, ProcedureName);
            }
        }

        public override ErrorCode ErrorCode
        {
            get { return ErrorCode.ProcedureMetadataRetrievalError; }
        }
    }
}
