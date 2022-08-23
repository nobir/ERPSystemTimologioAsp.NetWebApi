using BLL.BOs;
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
    [RoutePrefix("api")]
   // [IsAuthorized]
    public class BranchManagerController : ApiController
    {
        [Route("categoryinvoices/create")]
        [ValidationModel]
        [HttpPost]
        public HttpResponseMessage Create(CategoryInvoiceDTO catinvoice)
        {
            var isCreated = CategoryInvoiceService.Create(catinvoice);

            return isCreated ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        Message = "Category Invoice Created successfully"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "Category Invoice Create unsuccessfully"
                    }
                );
        }

        [Route("categoryinvoices/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var isDeleted = CategoryInvoiceService.Delete(id);

            return isDeleted ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        Message = "Category Invoice Deleted successfully"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "Category Invoice Delete unsuccessfully"
                    }
                );
        }

        [Route("categoryinvoices/{id}")]
        [HttpGet]
        public HttpResponseMessage Details(int id)
        {
            var catinvoice = CategoryInvoiceService.Get(id);

            return catinvoice != null ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    catinvoice
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "No Category Invoice found"
                    }
                );
        }

        [Route("~/api/categoryinvoices")]
        [HttpGet]
        public HttpResponseMessage ShowAll()
        {
            var permissions = CategoryInvoiceService.Gets();

            return permissions.Count() > 0 ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    permissions
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "No Category Invoice found"
                    }
                );
        }

        [Route("categoryinvoices/update")]
        [ValidationModel]
        [HttpPost]
        public HttpResponseMessage Update(CategoryInvoiceDTO catinvoice)
        {
            var isUpdated = CategoryInvoiceService.Update(catinvoice);

            return isUpdated ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        Message = "Category Invoice Updated successfully"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "Category Invoice Update unsuccessfully"
                    }
                );
        }



        [Route("customer/create")]
        [ValidationModel]
        [HttpPost]
        public HttpResponseMessage CreateCustomer(CustomerDTO Customer)
        {
            var isCreated = CustomerService.Create(Customer);

            return isCreated ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        Message = "Customer Created successfully"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "Customer Create unsuccessfully"
                    }
                );
        }

        [Route("customer/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteCustomer(int id)
        {
            var isDeleted = CustomerService.Delete(id);

            return isDeleted ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        Message = "Customer Deleted successfully"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "Customer Delete unsuccessfully"
                    }
                );
        }

        [Route("customer/{id}")]
        [HttpGet]
        public HttpResponseMessage DetailsCustomer(int id)
        {
            var Customer = CustomerService.Get(id);

            return Customer != null ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    Customer
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "No Customer found"
                    }
                );
        }

        [Route("~/api/customers")]
        [HttpGet]
        public HttpResponseMessage ShowAllCustomer()
        {
            var permissions = CustomerService.Gets();

            return permissions.Count() > 0 ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    permissions
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "No Customer found"
                    }
                );
        }

        [Route("customer/update")]
        [ValidationModel]
        [HttpPost]
        public HttpResponseMessage UpdateCustomer(CustomerDTO Customer)
        {
            var isUpdated = CustomerService.Update(Customer);

            return isUpdated ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        Message = "Customer Updated successfully"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "Customer Update unsuccessfully"
                    }
                );
        }






        

        [Route("vacation/reject/{id}")]
        [HttpPost]
        public HttpResponseMessage RejectEmployeeVacation(int id)
        {
            var isDeleted = VacationDetailService.Delete(id);

            return isDeleted ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        Message = "Vacation Request rejected successfully"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "Vacation Request rejected unsuccessfully"
                    }
                );
        }

        [Route("vacation/{id}")]
        [HttpGet]
        public HttpResponseMessage DetailsVacation(int id)
        {
            var VacationDetail = VacationDetailService.Get(id);

            return VacationDetail != null ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    VacationDetail
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "No Vacation Request found"
                    }
                );
        }

        [Route("~/api/vacations")]
        [HttpGet]
        public HttpResponseMessage VacationDetails()
        {
            var permissions = VacationDetailService.Gets();

            return permissions.Count() > 0 ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    permissions
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "No Vacation Request found"
                    }
                );
        }

        [Route("vacation/accept")]
        [ValidationModel]
        [HttpPost]
        public HttpResponseMessage AcceptVacationRequest(VacationDetailDTO Vacations)
        {
            var isUpdated = VacationDetailService.Update(Vacations);

            return isUpdated ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        Message = "Vacation Accept successfully"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "Vacation Accept unsuccessfully"
                    }
                );
        }


        [Route("payment/manage")]
        [ValidationModel]
        [HttpPost]
        public HttpResponseMessage ManageEmployeeSalary(PaymentDTO Payment)
        {
            var isUpdated = PaymentService.Update(Payment);

            return isUpdated ? Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        Message = "Employee Salary Manage successfully"
                    }
                ) : Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    new
                    {
                        Message = "Employee Salary Manage unsuccessfully"
                    }
                );
        }
    }
}
