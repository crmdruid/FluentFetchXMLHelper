using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Intergen.FetchXml.Querying;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;
using Intergen.FetchXml.ObjectModel;
using Tofi9.FetchXml.ObjectModel;

namespace Intergen.FetchXml.Tests
{
    [TestClass]
    public class DemoQueries
    {
        [TestMethod]
        public void DemoAttributes()
        {
            var query = new FetchQuery("lead")
                .Filter(f => f.Gt("budgetamount", 5000))
                .Attributes("fullname", "companyname", "budgetamount");

            var fetchxml = query.ToString();

            Assert.AreEqual(@"<?xml version=""1.0"" encoding=""utf-16""?><fetch><entity name=""lead""><filter><condition attribute=""budgetamount"" operator=""gt"" value=""5000"" /></filter><attribute name=""fullname"" /><attribute name=""companyname"" /><attribute name=""budgetamount"" /></entity></fetch>", fetchxml);
        }

        [TestMethod]
        public void DemoFilter()
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
        public void TestValueCondition()
        {
            string[] _statuscodes = new string[] { "1", "2", "3" };

            var test = new ValueConditionSection();
            test.Value = "1";

            var test2 = new ValueConditionSection();
            test2.Value = "2";

            var _statuscode = new List<ValueConditionSection>();
            _statuscode.Add(test);
            _statuscode.Add(test2);


            var query = new FetchQuery("new_annualreturn")
                         .Filter(f2 => f2.In("statuscode", _statuscode))
                            .AllAttributes();

            var fetchxml = query.ToString();

            Assert.AreEqual(@"<fetch top=""10"">
    <entity name=""new_annualreturn"" >
        <filter>
            <condition attribute=""statuscode"" operator=""in"" >
                <value>1</value>
                <value>2</value>
                <value>3</value>
                <value>4</value>
            </condition>
        </filter>
    </entity>
</fetch>", fetchxml);
        }
    }
}
