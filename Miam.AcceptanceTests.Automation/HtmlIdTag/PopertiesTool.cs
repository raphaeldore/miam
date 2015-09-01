using System;
using System.Linq.Expressions;

namespace Miam.AcceptanceTests.Automation.HtmlIdTag
{ //Todo: trouver un aute nom
    public class Tools
    {
        public static string GetPropertyName<P, T>(Expression<Func<P, T>> expression)
        {
            MemberExpression memberExpression = (MemberExpression)expression.Body;
            return memberExpression.Member.Name;
        }
    }

    public class ObjectsTool<Class>
    {
        public static string GetPropertyName<T>(Expression<Func<Class, T>> Field)
        {
            return Tools.GetPropertyName(Field);
        }
    }
}