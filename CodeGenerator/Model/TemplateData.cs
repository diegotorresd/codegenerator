using System;
using System.Collections.Generic;


namespace CodeGenerator
{
    public class TemplateData
    {
        public ObjectData ObjectData { get; private set; }
        public Dictionary<string, ProcedureData> ProcedureDataList { get; set; }

        public TemplateData(ObjectData objectData)
        {
            ObjectData = objectData;
            ProcedureDataList = new Dictionary<string, ProcedureData>();
        }

        public void AddProcedureDataList(ProcedureData procedureData)
        {
            this.ProcedureDataList.Add(procedureData.ProcedureName, procedureData);
        }
    }
}
