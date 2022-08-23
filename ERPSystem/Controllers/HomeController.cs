using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.BOs;
using BLL.Services;
using ERPSystem.Controllers.ActionFilters;

namespace ERPSystem.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class HomeController : ApiController
    {
        [Route("login")]
        [HttpPost]
        [ValidationModel]
        public HttpResponseMessage Login([FromBody] UserDTO user)
        {
            var _user = UserService.GetByEmail(user?.Email.ToString().Trim());

            if (_user == null || !_user.Password.Equals(user?.Password))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new
                {
                    ErrorMessage = "Invalid credential"
                });
            }

            _user.Status = 1;

            TokenDTO _token = new TokenDTO
            {
                UserId = _user.Id
            };

            WorkingHourDTO _working_hour = new WorkingHourDTO
            {
                UserId = _user.Id
            };

            var isUpdate = UserService.Update(_user) || (TokenService.Create(_token) && WorkingHourService.Create(_working_hour));

            return isUpdate ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        User = _user,
                        Token = _token.Token1
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        ErrorMessage = "Unsuccessfull login"
                    }
                );

            //return Request.CreateResponse(HttpStatusCode.OK, token);
            //var isDeleted = TokenService.Delete(Request.Content.);

            //return isDeleted ? Request.CreateResponse(
            //        HttpStatusCode.OK,
            //        new
            //        {
            //            Message = "Permission Deleted successfully"
            //        }
            //    ) : Request.CreateResponse(
            //        HttpStatusCode.BadRequest,
            //        new
            //        {
            //            Message = "Permission Delete unsuccessfully"
            //        }
            //    );

            //return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Route("logout")]
        [HttpPost]
        [IsAuthorized]
        [ValidationModel]
        public HttpResponseMessage Logout([FromBody] dynamic user)
        {
            var _user = UserService.Get((int)(user.AuthId));

            if (_user == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new
                {
                    ErrorMessage = "User not found"
                });
            }

            _user.Status = 0;

            var token = TokenService.GetByTokenKeyUserIdExpiredNull(_user.Id, Request.Headers.Authorization.ToString());
            token.ExpiredAt = DateTime.Now;

            if(token == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new
                {
                    ErrorMessage = "Invalid Token"
                });
            }

            var working_hour = WorkingHourService.GetByUserIdExitNull(_user.Id);
            working_hour.ExitTime = DateTime.Now;

            if (working_hour == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new
                {
                    ErrorMessage = "Working Hours record not found"
                });
            }

            bool isUpdate = UserService.Update(_user) || (TokenService.Update(token) && WorkingHourService.Update(working_hour));

            return isUpdate ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        SuccessMessage = "Successfully logout"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        ErrorMessage = "Unsuccessfull logout"
                    }
                );
        }
    }
}
