using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Error
{
    public enum ErrorCode
    {
        DataConnectorError = 10,
        TableMetadataRetrievalError,
        ProcedureMetadataRetrievalError
    }
}
