using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tofi9.FetchXml.ObjectModel
{
    [Serializable]
    public class Filter
    {
        [XmlElement("filter")]
        public List<Filter> Filters { get; } = new List<Filter>();

        [XmlElement("condition")]
        public List<BaseCondition> Conditions { get; } = new List<BaseCondition>();

        [XmlAttribute("type")]
        [DefaultValue(FilterType.And)]
        public FilterType Type { get; set; }
    }
}
