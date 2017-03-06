using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ACME.FluentFetchXMLHelper.Model
{
    public enum ConditionOperator
    {
        [XmlEnum("eq")]
        Eq,

        [XmlEnum("neq")]
        Neq,

        [XmlEnum("ne")]
        Ne,

        [XmlEnum("gt")]
        Gt,

        [XmlEnum("ge")]
        Ge,

        [XmlEnum("le")]
        Le,

        [XmlEnum("lt")]
        Lt,

        [XmlEnum("like")]
        Like,

        [XmlEnum("not-like")]
        NotLike,

        [XmlEnum("in")]
        In,

        [XmlEnum("not-in")]
        NotIn,
    }
}
