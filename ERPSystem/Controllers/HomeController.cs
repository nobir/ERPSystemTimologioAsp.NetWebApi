using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.BOs;
using BLL.BOs.Login;
using BLL.BOs.Logout;
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
        public HttpResponseMessage Login([FromBody] UserLoginDTO user)
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

            bool isUserUpdated = UserService.Update(_user);
            bool isTokenUpdated = TokenService.Create(_token);
            bool isWorkingHourUpdated = WorkingHourService.Create(_working_hour);

            var isUpdate = isUserUpdated || (isTokenUpdated && isWorkingHourUpdated);

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
        public HttpResponseMessage Logout([FromBody] AuthIdDTO obj)
        {
            var _user = UserService.Get(obj.AuthId);

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

            bool isUserUpdated = UserService.Update(_user);
            bool isTokenUpdated = TokenService.Update(token);
            bool isWorkingHourUpdated = WorkingHourService.Update(working_hour);

            bool isUpdate = isUserUpdated || (isTokenUpdated && isWorkingHourUpdated);

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
