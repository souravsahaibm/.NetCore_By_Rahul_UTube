using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Routing
{
    public class CustomContraints : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if(values.TryGetValue(routeKey,out object val))
            {
                if(val is string stringval)
                {
                    return stringval.StartsWith("0");
                }              
            }
            return false;
        }
    }
}
