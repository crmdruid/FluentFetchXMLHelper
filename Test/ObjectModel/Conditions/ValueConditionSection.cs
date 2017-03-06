using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tofi9.FetchXml.ObjectModel
{
    public class ValueConditionSection
    {
        [XmlElement("value")]
        public string Value { get; set; }

    }
}
