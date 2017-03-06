using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ACME.FluentFetchXMLHelper.Model
{
    [Serializable]
    public enum FilterType
    {
        [XmlEnum("and")]
        And,

        [XmlEnum("or")]
        Or,
    }
}
