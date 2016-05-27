using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Templar.ServiceAgent.Infrastructure
{
    public class CustomXmlFormatterData : FormatterData
    {
        public override ILogFormatter BuildFormatter()
        {
            return new CustomXmlFormatter(); 
        }
 
    }
    [ConfigurationElementType(typeof(CustomXmlFormatterData))]
    public class CustomXmlFormatter : LogFormatter
    {
        public CustomXmlFormatter()
        {

        }
        private const string DefaultValue = "";

        public override string Format(LogEntry log)
        {
            StringBuilder result = new StringBuilder();
            Format(log, result);
            return result.ToString();
        }

        private void Format(object obj, StringBuilder result)
        {
            if (obj == null) return;
            result.Append(CreateOpenElement(CreateRootName(obj)));
            if (Type.GetTypeCode(obj.GetType()) == TypeCode.Object)
            {
                foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
                {
                    result.Append(CreateOpenElement(propertyInfo.Name));
                    if (typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType) && Type.GetTypeCode(propertyInfo.PropertyType) == TypeCode.Object)
                    {
                        IEnumerable values = (IEnumerable)propertyInfo.GetValue(obj, null);
                        if (values != null)
                        {
                            foreach (object value in values)
                            {
                                Format(value, result);
                            }
                        }
                    }
                    else
                    {
                        result.Append(ConvertToString(propertyInfo, obj));
                    }
                    result.Append(CreateCloseElement(propertyInfo.Name));
                }
            }
            else
            {
                result.Append(obj.ToString());
            }
            result.Append(CreateCloseElement(CreateRootName(obj)));
        }

        private string CreateRootName(object obj)
        {
            string name = obj.GetType().Name;
            name = name.Replace('`', '_');
            name = name.Replace('[', '_');
            name = name.Replace(']', '_');
            name = name.Replace(',', '_');
            return name;
        }

        private string CreateOpenElement(string name)
        {
            return string.Format("<{0}>", name);
        }

        private string CreateCloseElement(string name)
        {
            return string.Format("</{0}>", name);
        }

        private string ConvertToString(PropertyInfo propertyInfo, object obj)
        {
            object value = propertyInfo.GetValue(obj, null);
            return value != null ? value.ToString() : DefaultValue;
        }
        
    }
}
