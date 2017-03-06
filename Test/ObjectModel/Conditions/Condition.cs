using Intergen.FetchXml.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tofi9.FetchXml.ObjectModel
{
    [Serializable]
    public class Condition : BaseCondition
    {
        [XmlAttribute("column")]
        public string Column { get; set; }

        [XmlAttribute("entityname")]
        public string EntityName { get; set; }

        [XmlAttribute("value", Namespace = "")]
        public string Value { get; set; }

        [XmlAttribute("alias")]
        public string Alias { get; set; }

    }
}
