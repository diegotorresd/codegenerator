using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public enum ExitCode
    {
        Success = 0,
        ArgumentError,
        GenericError = 1000 
    }
}
