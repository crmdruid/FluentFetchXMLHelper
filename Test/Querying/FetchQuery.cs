using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using ACME.FluentFetchXMLHelper.Model;
using ACME.FluentFetchXMLHelper.Model.ObjectModel;

namespace ACME.FluentFetchXMLHelper.Model.Querying
{
    public class FetchQuery
    {
        FetchXmlObject fetch;

        public FetchQuery(string entity)
        {
            fetch = new FetchXmlObject
            {
                Entity = new FetchEntity { Name = entity }
            };
        }

        public FetchQuery AllAttributes()
        {
            fetch.Entity.Attributes.Add(new AllAttributes());
            return this;
        }

        public FetchQuery Attributes(params string[] attributes)
        {
            fetch.Entity.Attributes.AddRange(attributes.Select(x => new ACME.FluentFetchXMLHelper.Model.Attribute { Name = x }));
            return this;
        }

        public FetchQuery Filter(Action<FetchFilter> filterFn)
        {
            var filter = fetch.Entity.Filter;
            if (filter == null)
            {
                fetch.Entity.Filter = filter = new Filter();
            }

            FetchFilter.Apply(filter, filterFn);

            return this;
        }

        public override string ToString()
        {
            return this.fetch.ToString();
        }

        public IReadOnlyList<Entity> RetrieveMultiple(IOrganizationService service)
        {
            var fetch = this.ToString();
            var result = service.RetrieveMultiple(new FetchExpression(fetch)).Entities.ToList();
            return result;
        }
    }
}
