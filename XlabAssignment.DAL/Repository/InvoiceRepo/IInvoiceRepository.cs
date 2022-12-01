using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XlabAssignment.DAL.Data.Context;
using XlabAssignment.DAL.Data.Model;

namespace XlabAssignment.DAL.Repository.InvoiceRepo
{
    public interface IInvoiceRepository
    {
      
        //Getting Invoice including Details
        Task<Invoice> GetInvoiceByInvoiceNumber(int InvoiceNumber);
        Task<Invoice> GetInvoiceByInvoiceId(Guid InvoiceId);

        //Create new Invoice
        Task<Invoice> CreateInvoice(Invoice invoice);
        Task<Invoice_Details> CreateInvoiceDetails(Invoice_Details invoice_Detail);
        // Delete Invoice by Invoice Number
        Task<Invoice> DeleteInvoice(int InvoiceNumber);
        Task SaveAsync();
    }
}
