using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ACME.FluentFetchXMLHelper.Model
{
    [Serializable]
    public class ValueCondition : BaseCondition
    {
        //[XmlArrayItem(ElementName = "value", Namespace = "")]
        //public string[] Value { get; set; }
        [XmlElement("value")]
        public string[] values { get; set; }
    }
}
