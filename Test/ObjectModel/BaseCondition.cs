using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tofi9.FetchXml.ObjectModel
{
    [Serializable]
    public class BaseCondition
    {
        [XmlAttribute("attribute")]
        public string Attribute { get; set; }

        [XmlAttribute("operator")]
        public ConditionOperator Operator { get; set; }

        public static string TranslateValueToString(object value)
        {
            if (value is DateTime)
            {
                return ((DateTime)value).ToString("O");
            }

            return value?.ToString();
        }
    }
}
