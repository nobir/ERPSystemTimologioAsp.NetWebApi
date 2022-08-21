using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.Services;
using ERPSystem.Controllers.ActionFilters;

namespace ERPSystem.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class HomeController : ApiController
    {
        [Route("users")]
        [HttpGet]
        public HttpResponseMessage Index()
        {
            var user = UserService.Gets();
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
    }
}
