using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public static class TextTransformExtensions
    {
        public static string UppercaseUnderscoreToPascalCase(this string str)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string result = textInfo.ToLower(str);
            result = result.Replace('_', ' ');

            return textInfo.ToTitleCase(result).Replace(" ", string.Empty);
        }

        public static string ProcedureParameterNameToColumnName(this string procParam)
        {
            var list = new string[] { "PO_", "PI_" };
            if (list.Any(i => procParam.StartsWith(i)))
                return procParam.Substring(3);

            return procParam;
        }
    }
}
