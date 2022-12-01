using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XlabAssignment.DAL.Data.Context;
using XlabAssignment.DAL.Data.Model;

namespace XlabAssignment.DAL.Repository.InvoiceRepo
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;
        public InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Invoice> GetInvoiceByInvoiceNumber(int InvoiceNumber)
        {
            return await _context.Invoices.Include(e=>e.Invoice_Details).FirstOrDefaultAsync(a => a.InvoiceNumber == InvoiceNumber);
        }
        public async Task<Invoice> CreateInvoice(Invoice invoice)
        {
            if(await GetInvoiceByInvoiceNumber(invoice.InvoiceNumber) != null)
            {
                return null;
            }
            await _context.Invoices.AddAsync(invoice);
            return invoice;
        }

        public async Task<Invoice> DeleteInvoice(int InvoiceNumber)
        {
           var Invoice = await GetInvoiceByInvoiceNumber(InvoiceNumber);
            if (Invoice == null)
                return null;
            _context.Invoices.Remove(Invoice);
            return Invoice;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Invoice_Details> CreateInvoiceDetails(Invoice_Details invoice_Detail)
        {
            await _context.Invoice_Details.AddAsync(invoice_Detail);
            return invoice_Detail;
        }

        public async Task<Invoice> GetInvoiceByInvoiceId(Guid InvoiceId)
        {
            return await _context.Invoices.Include(e => e.Invoice_Details).FirstOrDefaultAsync(a => a.InvoiceID == InvoiceId);
        }
    }
}
