using BLL;
using BLL.BOs.Admin;
using BLL.Services;
using ERPSystem.Controllers.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ERPSystem.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/admin")]
    [ValidationModel]
    [IsAdmin]
    public class AdminController : ApiController
    {
        [Route("user/create")]
        [HttpPost]
        public HttpResponseMessage CreateUser([FromBody] CreateUserDTO obj)
        {
            var isDuplicateEmail = UserService.GetByEmail(obj.User.Email);
            var isDuplicateUsername = UserService.GetByUsername(obj.User.Username);

            if(isDuplicateEmail != null)
            {
                return Request.CreateResponse(
                       HttpStatusCode.NotAcceptable,
                       new
                       {
                           ErrorMessage = "Email already registered"
                       }
                   );
            }

            if (isDuplicateUsername != null)
            {
                return Request.CreateResponse(
                       HttpStatusCode.NotAcceptable,
                       new
                       {
                           ErrorMessage = "Username already been taken"
                       }
                   );
            }

            if(obj.User != null )
                obj.User.Address = obj.Address;

            if(obj.Region == null)
            {
                obj.User.Branch = obj.Branch;
            }

            if(obj.Region != null)
            {
                obj.User.Region = obj.Region;
            }
            else
            {
                obj.User.Region = obj.Branch?.Region;
            }

            if (obj.PermissionIds?.Count() > 0)
            {
                obj.PermissionIds.RemoveAll(n => n== 0);
                obj.PermissionIds = obj.PermissionIds.Distinct().ToList();
            }

            for (var i = 0; i < obj.PermissionIds.Count(); ++i)
            {
                var id = obj.PermissionIds[i];
                var permission = PermissionService.Get(id);

                obj.User.Permissions.Add(permission);
            }

            var isUserCreated = UserService.Create(obj.User);

            return isUserCreated ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        SuccessMessage = "Successfully user created"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.NotAcceptable,
                    new
                    {
                        ErrorMessage = "Unsuccessfull user created"
                    }
                );
        }


        [Route("user/delete")]
        [HttpPost]
        public HttpResponseMessage DeleteUser([FromBody] DeleteUserDTO obj)
        {
            var isUserFound = UserService.Get(obj.Id);

            if(isUserFound == null)
            {
                return Request.CreateResponse(
                    HttpStatusCode.NotAcceptable,
                    new
                    {
                        ErrorMessage = "User not found"
                    }
                );
            }

            var isDeleted = UserService.Delete(obj.Id);

            return isDeleted ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        SuccessMessage = "Successfully user deleted"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.NotAcceptable,
                    new
                    {
                        ErrorMessage = "Unsuccessfull user deleted"
                    }
                );
        }

        [Route("user/update")]
        [HttpPost]
        public HttpResponseMessage UpdateUser([FromBody] UpdateUserDTO obj)
        {
            var _user = UserService.Get(obj.User.Id);
            var isDuplicateEmail = UserService.GetByEmail(obj.User?.Email) != null && !UserService.GetByEmail(obj.User?.Email).Email.Equals(_user.Email) && UserService.GetByEmail(obj.User?.Email) != null;
            var isDuplicateUsername = UserService.GetByUsername(obj.User?.Username) != null && !UserService.GetByUsername(obj.User?.Username).Username.Equals(_user.Username) && UserService.GetByUsername(obj.User?.Username) != null;

            if (isDuplicateEmail)
            {
                return Request.CreateResponse(
                       HttpStatusCode.NotAcceptable,
                       new
                       {
                           ErrorMessage = "Email already registered"
                       }
                   );
            }

            if (isDuplicateUsername)
            {
                return Request.CreateResponse(
                       HttpStatusCode.NotAcceptable,
                       new
                       {
                           ErrorMessage = "Username already been taken"
                       }
                   );
            }

            obj.Address.Id = _user.Address.Id;

            var isAddressUpdated = AddressService.Update(obj.Address);

            obj.Address.Id = 0;

            if (obj.Region == null)
            {
                _user.BranchId = obj.Branch?.Id;
            }

            if (obj.Region != null)
            {
                _user.RegionId = obj.Region?.Id;
            }
            else
            {
                _user.RegionId = obj.Branch?.Region.Id;
            }

            if (obj.PermissionIds?.Count() > 0)
            {
                obj.PermissionIds.RemoveAll(n => n == 0);
                obj.PermissionIds = obj.PermissionIds.Distinct().ToList();
            }

            for (var i = 0; i < obj.PermissionIds.Count(); ++i)
            {
                var id = obj.PermissionIds[i];
                var permission = PermissionService.Get(id);

                _user.Permissions.Add(permission);
            }

            //var x = Mapping.Mapper.Map<List<Permission>>();
            obj.User.Permissions = _user.Permissions;

            var isUserCreated = UserService.Update(obj.User);

            return isUserCreated ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        SuccessMessage = "Successfully user updated"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.NotAcceptable,
                    new
                    {
                        ErrorMessage = "Unsuccessfull user updated"
                    }
                );
        }

        [Route("user/search")]
        [HttpPost]
        public HttpResponseMessage ViewUsers([FromBody] SearchUserDTO obj)
        {
            var users = UserService.GetBySearch(obj.SearchBy, obj.SearchValue);

            return Request.CreateResponse(HttpStatusCode.OK, users);
        }
    }
}
