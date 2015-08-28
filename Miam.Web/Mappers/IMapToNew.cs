using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Miam.Web.Mappers
{
    public interface IMapToNew<in TSource, out TTarget>
    {
        TTarget Map(TSource source);
    }
}