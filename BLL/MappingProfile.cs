using AutoMapper;
using BLL.BOs;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // create all the model map here
            // Example: CreateMap<AddressModel, Address>();
            //          CreateMap<Address, AddressModel>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Address, AddressDTO>();
            CreateMap<AddressDTO, Address>();

            CreateMap<Region, RegionDTO>();
            CreateMap<RegionDTO, Region>();

            CreateMap<Branch, BranchDTO>();
            CreateMap<BranchDTO, Branch>();

            CreateMap<Token, TokenDTO>();
            CreateMap<TokenDTO, Token>();

            CreateMap<WorkingHour, WorkingHourDTO>();
            CreateMap<WorkingHourDTO, WorkingHour>();

            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();

            CreateMap<InvoiceDTO, Invoice>();
            CreateMap<Invoice, InvoiceDTO>();

            CreateMap<CategoryInvoiceDTO, CategoryInvoice>();
            CreateMap<CategoryInvoice, CategoryInvoiceDTO>();

            CreateMap<VacationDetailDTO, VacationDetail>();
            CreateMap<VacationDetail, VacationDetailDTO>();

            CreateMap<PaymentDTO, Payment>();
            CreateMap<Payment, PaymentDTO>();
        }
    }
}
