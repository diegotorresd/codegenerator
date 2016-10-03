using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Templates
{
    public abstract class TestTemplate : DataTemplate
    {
        public static Dictionary<Type, string> TestValueForPropertyType = new Dictionary<Type, string>() {
            {typeof(Int32), "1"},
            {typeof(string), "String.Empty"},
            {typeof(Boolean), "true"},
            {typeof(DateTime), "DateTime.Now"}
        };

        public static string ModifiedValue = "2";

        public TestTemplate(TemplateData templateData)
            : base(templateData) { }
    }
}
