using System;
using System.Linq.Expressions;

namespace Miam.AcceptanceTests.Automation.HtmlIdTag
{
    public class PropertiesTool<TClass>
    {
        public static string GetPropertyName<T>(Expression<Func<TClass, T>> field)
        {
            MemberExpression memberExpression = (MemberExpression)field.Body;
            return memberExpression.Member.Name;
        }
    }
}