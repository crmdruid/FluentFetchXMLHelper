using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ACME.FluentFetchXMLHelper.Model
{
    [Serializable]
    //[XmlInclude(typeof(BaseCondition))]
    [XmlInclude(typeof(Condition))]
    [XmlInclude(typeof(ValueCondition))]
    [XmlRoot("fetch", Namespace = "")]
    public class FetchXmlObject
    {
        [XmlElement("entity")]
        public FetchEntity Entity { get; set; }

        public override string ToString()
        {
            var serializer = new XmlSerializer(typeof(FetchXmlObject));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var writer = new StringWriter();
            serializer.Serialize(new NoTypeAttributeXmlWriter(writer), this, ns);
            return writer.ToString();
        }
    }

    public class NoTypeAttributeXmlWriter : XmlTextWriter
    {
        public NoTypeAttributeXmlWriter(TextWriter w)
                   : base(w) { }
        public NoTypeAttributeXmlWriter(Stream w, Encoding encoding)
                   : base(w, encoding) { }
        public NoTypeAttributeXmlWriter(string filename, Encoding encoding)
                   : base(filename, encoding) { }

        bool skip;

        public override void WriteStartAttribute(string prefix,
                                                 string localName,
                                                 string ns)
        {
            if (ns == "http://www.w3.org/2001/XMLSchema-instance" &&
                localName == "type")
            {
                skip = true;
            }
            else
            {
                base.WriteStartAttribute(prefix, localName, ns);
            }
        }

        public override void WriteString(string text)
        {
            if (!skip) base.WriteString(text);
        }

        public override void WriteEndAttribute()
        {
            if (!skip) base.WriteEndAttribute();
            skip = false;
        }
    }

}
