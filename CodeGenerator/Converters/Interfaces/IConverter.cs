using CodeGenerator;
using System;

namespace Converters.Interfaces
{
    internal interface IConverter : IDisposable
    {
        ObjectData GetObjectDataFromTable(string tableName);
        ProcedureData GetProcedure(string procName, ObjectData columnTemplate);
    }
}
