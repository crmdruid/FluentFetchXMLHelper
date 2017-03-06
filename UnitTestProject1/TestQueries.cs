using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;
using ACME.FluentFetchXMLHelper.Model;
using ACME.FluentFetchXMLHelper.Model.Querying;

namespace ACME.FetchXml.Tests
{
    [TestClass]
    public class TestQueries
    {
        [TestMethod]
        public void Selected_Attributes_With_Greater_Than()
        {
            var query = new FetchQuery("lead")
                .Filter(f => f.Gt("budgetamount", 5000))
                .Attributes("fullname", "companyname", "budgetamount");

            var fetchxml = query.ToString();

            Assert.AreEqual(@"<?xml version=""1.0"" encoding=""utf-16""?><fetch><entity name=""lead""><filter><condition attribute=""budgetamount"" operator=""gt"" value=""5000"" /></filter><attribute name=""fullname"" /><attribute name=""companyname"" /><attribute name=""budgetamount"" /></entity></fetch>", fetchxml);
        }

        [TestMethod]
        public void All_Attributes_With_Or_Equal_Or_Like()
        {
            var query = new FetchQuery("contact")
                .Attributes("firstname", "lastname", "fullname")
                .Filter(f => f
                    .SubFilterOr(f2 => f2
                        .SubFilterAnd(f3 => f3
                            .Eq("firstname", "Sam")
                            .Eq("lastname", "Jones"))
                        .SubFilterAnd(f3 => f3
                            .Like("lastname", "%(sample)%"))))
                .AllAttributes();

            var fetchxml = query.ToString();

            Assert.AreEqual(@"<?xml version=""1.0"" encoding=""utf-16""?><fetch><entity name=""contact""><filter><filter type=""or""><filter><condition attribute=""firstname"" operator=""eq"" value=""Sam"" /><condition attribute=""lastname"" operator=""eq"" value=""Jones"" /></filter><filter><condition attribute=""lastname"" operator=""like"" value=""%(sample)%"" /></filter></filter></filter><attribute name=""firstname"" /><attribute name=""lastname"" /><attribute name=""fullname"" /><all-attributes /></entity></fetch>", fetchxml);
        }

        [TestMethod]
        public void All_Attributes_In()
        {
            string[] _statuscodes = new string[] { "1", "2", "3" };

            var query = new FetchQuery("new_annualreturn")
                         .Filter(f2 => f2.In("statuscode", _statuscodes))
                            .AllAttributes();

            var fetchxml = query.ToString();

            Assert.AreEqual(@"<?xml version=""1.0"" encoding=""utf-16""?><fetch><entity name=""new_annualreturn""><filter><condition attribute=""statuscode"" operator=""in""><value>1</value><value>2</value><value>3</value></condition></filter><all-attributes /></entity></fetch>", fetchxml);
        }

        [TestMethod]
        public void All_Attributes_NotIn()
        {
            string[] _statuscodes = new string[] { "3", "10", "200" };

            var query = new FetchQuery("new_annualreturn")
                            .Filter(f => f.NotIn("statuscode",_statuscodes))
                             .AllAttributes();

            var fetchxml = query.ToString();

            Assert.AreEqual(@"<?xml version=""1.0"" encoding=""utf-16""?><fetch><entity name=""new_annualreturn""><filter><condition attribute=""statuscode"" operator=""not-in""><value>3</value><value>10</value><value>200</value></condition></filter><all-attributes /></entity></fetch>", fetchxml);
        }
    }
}
