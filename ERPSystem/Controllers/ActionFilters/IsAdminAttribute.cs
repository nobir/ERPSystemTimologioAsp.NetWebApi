using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ERPSystem.Controllers.ActionFilters
{
    public class IsAdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            int user_id = ((dynamic)actionContext.ActionArguments.FirstOrDefault().Value)?.AuthId ?? -1 ;
            var user = UserService.Get(user_id);
            if(user == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Either AuthId not present or Invalid Token");
                return;
            }

            if (user != null && !(user.Type <= 1))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "User must be admin or above");

                return;
            }
        }
    }
}