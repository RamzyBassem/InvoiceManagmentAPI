using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XlabAssignment.BL.Dtos.InvoiceDTOs;

namespace XlabAssignment.BL.Managers.InvoiceManager
{
    public interface IInvoiceManager
    {
        //Getting Invoice including Details
        Task<InvoiceReadDTO> GetInvoiceByInvoiceNumber(int InvoiceNumber);

        //Create new Invoice
        Task<InvoiceReadDTO> CreateInvoice(InvoiceAddDTO model);
        // Update Invoice
        Task<InvoiceReadDTO> UpdateInvoice(InvoiceEditDTO model);

        // Delete Invoice by Invoice Number
        Task<InvoiceReadDTO> DeleteInvoice(int InvoiceNumber);
    }
}
