

using AutoMapper;
using XlabAssignment.BL.Dtos.InvoiceDTOs;
using XlabAssignment.DAL.Data.Model;

namespace AirBnb.BL.AutoMapper
{
    public class AutoMapperProfiler:Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<Invoice_Details, InvoiceDetailReadDTO>();
            CreateMap<InvoiceDetailAddDTO, Invoice_Details>();

            CreateMap<InvoiceDetailEditDTO, Invoice_Details>();
            //Converting from InvoiceAddDto to Invoice 
            CreateMap<InvoiceAddDTO, Invoice>();

            //Converting a Invoice to InvoiceReadDto
            CreateMap<Invoice, InvoiceReadDTO>();

            //Converting from editInvoice to Invoice 
            CreateMap<InvoiceEditDTO, Invoice>();

          



        }
    }
}
