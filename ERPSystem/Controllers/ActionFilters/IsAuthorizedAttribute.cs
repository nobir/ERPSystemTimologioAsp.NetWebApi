using BLL.BOs;
using BLL.BOs.Logout;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ERPSystem.Controllers.ActionFilters
{
    public class IsAuthorizedAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization != null ? actionContext.Request.Headers.Authorization.ToString() : "";
            int user_id = ((AuthIdDTO)actionContext.ActionArguments.FirstOrDefault().Value).AuthId;

            if(token.Length < 0 || token == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid Token");

                return;
            }

            var _token = TokenService.GetByTokenKeyUserIdExpiredNull(user_id, token);

            if(_token == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid Token");

                return;
            }
        }
    }
}