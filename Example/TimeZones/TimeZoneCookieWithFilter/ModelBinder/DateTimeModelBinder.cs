using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeZoneCookieWithFilter.Filters;

namespace TimeZoneCookieWithFilter.ModelBinder
{
    public class DateTimeModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext,
                                         ModelBindingContext bindingContext)
        {
            //TimeZoneFilterAttribute.ReadCookie(controllerContext.RequestContext);
            var value = base.BindModel(controllerContext, bindingContext);
            if (value is DateTime)
            {
                return ((DateTime)value).FromUserTime();
            }

            return value;
        }
    }
}