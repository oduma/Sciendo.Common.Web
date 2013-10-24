using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using Sciendo.Common.Web.Components.Base;
using Sciendo.Common.Web.Models.Grids;

namespace Sciendo.Common.Web
{
    public static class Extentions
    {
        public static Component RegisterComponent(this List<Component> components, Component newComponent)
        {
            components.Add(newComponent);
            return newComponent;
        }

        public static MvcHtmlString InitializeAllRegisterComponents(this List<Component> components)
        {
            StringBuilder buildString = new StringBuilder();
            foreach (var component in components)
            {
                buildString.Append(string.Format("{0}{1}",component.InitializeJavaScript(),Environment.NewLine));
            }
            return new MvcHtmlString(buildString.ToString());
        }

        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> inCollection, string sortColumnName, string sortOrder)
        {
            string methodName = string.Format("OrderBy{0}",sortOrder.ToLower() == "asc" ? "" : "descending");
            var queryableCollection = inCollection.AsQueryable();
            ParameterExpression parameter = Expression.Parameter(queryableCollection.ElementType, "p");
            MemberExpression memberExpression = sortColumnName.Split('.')
                .Aggregate<string, MemberExpression>(null,(current,property)=>MemberExpression.Property
                                                         (current ??(parameter as Expression),property));

            LambdaExpression orderByLambda = Expression.Lambda(memberExpression, parameter);

            MethodCallExpression result = Expression.Call(
                typeof (Queryable),
                methodName,
                new[] {queryableCollection.ElementType, memberExpression.Type},
                queryableCollection.Expression,
                Expression.Quote(orderByLambda));

            return queryableCollection.Provider.CreateQuery<T>(result);
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> inCollection, string columnName, object value, WhereOperation operation )
        {
             if (string.IsNullOrEmpty(columnName))
                return inCollection;
             var queryableCollection = inCollection.AsQueryable();

            ParameterExpression parameter = Expression.Parameter(queryableCollection.ElementType, "p");

            MemberExpression memberAccess = null;
            foreach (var property in columnName.Split('.'))
                memberAccess = MemberExpression.Property
                   (memberAccess ?? (parameter as Expression), property);

            //change param value type
            //necessary to getting bool from string
            ConstantExpression filter = Expression.Constant
                (
                    Convert.ChangeType(value, memberAccess.Type)
                );

            //switch operation
            Expression condition = null;
            LambdaExpression lambda = null;
            switch (operation)
            {
                //equal ==
                case WhereOperation.eq:
                    condition = Expression.Equal(memberAccess, filter);
                    lambda = Expression.Lambda(condition, parameter);
                    break;
                //not equal !=
                case WhereOperation.ne:
                    condition = Expression.NotEqual(memberAccess, filter);
                    lambda = Expression.Lambda(condition, parameter);
                    break;
                //string.Contains()
                case WhereOperation.cn:
                    condition = Expression.Call(memberAccess,
                        typeof(string).GetMethod("Contains"),
                        Expression.Constant(value));
                    lambda = Expression.Lambda(condition, parameter);
                    break;
            }

            
            MethodCallExpression result = Expression.Call(
                   typeof(Queryable), "Where",
                   new[] { queryableCollection.ElementType },
                   queryableCollection.Expression,
                   lambda);

            return queryableCollection.Provider.CreateQuery<T>(result);
        }

        public static IEnumerable<T> FilterBy<T>(this IEnumerable<T> inCollection, GridRequestSettings gridRequestSettings, IEqualityComparer<T> comparer)
        {
            if(gridRequestSettings.Where==null)
                return inCollection;
            if (string.IsNullOrEmpty(gridRequestSettings.Where.groupOp) || gridRequestSettings.Where.groupOp == "AND")
            {
                foreach (var rule in gridRequestSettings.Where.rules)
                {
                    WhereOperation operation;
                    if(Enum.TryParse(rule.op,out operation))
                    {
                        inCollection = inCollection.Where<T>(
                            rule.field, rule.data,operation);
                    }
                }
            }
            else
            {
                IEnumerable<T> temp = new T[]{}; 
                foreach (var rule in gridRequestSettings.Where.rules)
                {
                    WhereOperation operation;
                    if (Enum.TryParse(rule.op, out operation))
                    {
                        temp = temp.Union(inCollection.Where<T>(rule.field, rule.data, operation));
                    }
                }
                inCollection = temp.Distinct<T>(comparer);
            }

            return inCollection;
        }

        public static string ToOptionsJsonString(this IDictionary<string, string> inValues)
        {
            StringBuilder temp= new StringBuilder("");
            temp.Append("{value:'");
            temp.Append(string.Join(";", inValues.Keys.Select(key => string.Format("{0}:{1}", key, inValues[key]))));
            temp.Append("'}");
            return temp.ToString();
        }

        public static IEnumerable<T> AddRangeReturn<T>(this List<T> inCollection, IEnumerable<T> items)
        {
            inCollection.AddRange(items);
            return inCollection;
        }
    }
}
