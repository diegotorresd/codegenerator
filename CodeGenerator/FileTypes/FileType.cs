using System;

namespace CodeGenerator.FileTypes
{
    public enum FileType
    {
        Entity,
        DAL,
        [Obsolete]
        DALInterface,
        DALTest,
        Logic,
        LogicTest,
        Service,
        Contract
    }
}
