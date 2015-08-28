using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Miam.TestUtility;

namespace Miam.TestUtility
{
    public class Tools
    {
        public static string GetPropertyName<P, T>(Expression<Func<P, T>> expression)
        {
            MemberExpression memberExpression = (MemberExpression)expression.Body;
            return memberExpression.Member.Name;
        }
    }
}

public class ObjectsTool<Class>
{
    public static string GetPropertyName<T>(Expression<Func<Class, T>> Field)
    {
        return Tools.GetPropertyName(Field);
    }
}