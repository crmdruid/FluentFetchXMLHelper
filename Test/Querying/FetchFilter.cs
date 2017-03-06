using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.FluentFetchXMLHelper.Model.Querying
{
    public class FetchFilter
    {
        private Filter filter;

        public FetchFilter(Filter filter)
        {
            this.filter = filter;
        }

        public FetchFilter SubFilterOr(Action<FetchFilter> filterFn)
        {
            var subFilter = new Filter { Type = FilterType.Or };

            filterFn(new FetchFilter(subFilter));

            filter.Filters.Add(subFilter);
            return this;
        }

        public FetchFilter SubFilterAnd(Action<FetchFilter> filterFn)
        {
            var subFilter = new Filter { Type = FilterType.And };

            filterFn(new FetchFilter(subFilter));

            filter.Filters.Add(subFilter);
            return this;
        }

        public FetchFilter Condition(string attribute, ConditionOperator op, object value)
        {
            filter.Conditions.Add(new Condition
            {
                Attribute = attribute,
                Operator = op,
                Value = BaseCondition.TranslateValueToString(value)
            });

            return this;
        }

        public FetchFilter ValueCondition(string attribute, ConditionOperator op, List<ValueConditionSection> values)
        {
            filter.Conditions.Add(new ValueCondition
            {
                Attribute = attribute,
                Operator = op,
                values = values,
            });

            return this;
        }

        public FetchFilter Eq(string attribute, object value)
        {
            Condition(attribute, ConditionOperator.Eq, value);
            return this;
        }
        public FetchFilter Gt(string attribute, object value)
        {
            Condition(attribute, ConditionOperator.Gt, value);
            return this;
        }

        public FetchFilter Like(string attribute, object value)
        {
            Condition(attribute, ConditionOperator.Like, value);
            return this;
        }

        public FetchFilter In(string attribute, List<ValueConditionSection> values)
        {
            ValueCondition(attribute, ConditionOperator.In, values);
            return this;
        }


        public static void Apply(Filter filter, Action<FetchFilter> filterFn)
        {
            filterFn(new FetchFilter(filter));
        }
    }
}
