using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XlabAssignment.BL.Dtos.InvoiceDTOs;
using XlabAssignment.DAL.Data.Model;
using XlabAssignment.DAL.Repository.InvoiceRepo;

namespace XlabAssignment.BL.Managers.InvoiceManager
{
    public class InvoiceManager : IInvoiceManager
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceManager(IInvoiceRepository invoiceRepository , IMapper mapper)
        {
            this._invoiceRepository = invoiceRepository;
            this._mapper = mapper;
        }

        public async Task<InvoiceReadDTO> CreateInvoice(InvoiceAddDTO model)
        {
            var invoice = _mapper.Map<Invoice>(model);
            invoice.InvoiceID = Guid.NewGuid();
            foreach(var detail in invoice.Invoice_Details)
            {
                detail.Invoice_DetailsID = Guid.NewGuid();
                detail.InvoiceID = invoice.InvoiceID;
            }
            var response = await _invoiceRepository.CreateInvoice(invoice);
            await _invoiceRepository.SaveAsync();
            return _mapper.Map<InvoiceReadDTO>(response);


        }

        public async Task<InvoiceReadDTO> DeleteInvoice(int InvoiceNumber)
        {
            var response = await _invoiceRepository.DeleteInvoice(InvoiceNumber);
            if (response == null)
                return null;
            await _invoiceRepository.SaveAsync();
            return _mapper.Map<InvoiceReadDTO>(response);
            
        }

        public async Task<InvoiceReadDTO> GetInvoiceByInvoiceNumber(int InvoiceNumber)
        {
           var response = await _invoiceRepository.GetInvoiceByInvoiceNumber(InvoiceNumber);
            return _mapper.Map<InvoiceReadDTO>(response);
        }

        public async Task<InvoiceReadDTO> UpdateInvoice(InvoiceEditDTO model)
        {
            foreach (var detail in model.Invoice_Details)
            {
                if (detail.Invoice_DetailsID == Guid.Empty)
                {
                    detail.Invoice_DetailsID = Guid.NewGuid();
                    detail.InvoiceID = model.InvoiceID;
                    await _invoiceRepository.CreateInvoiceDetails(_mapper.Map<Invoice_Details>(detail));
                }
            }
            await _invoiceRepository.SaveAsync();
            var invoice =await _invoiceRepository.GetInvoiceByInvoiceId(model.InvoiceID);
            if (invoice == null)
                return new InvoiceReadDTO { ErrorMessage="No Invoice Found With This Invoice Id"};
            if (invoice.InvoiceID != model.InvoiceID)
                return new InvoiceReadDTO { ErrorMessage = "Invoice Number Already Found" };
            _mapper.Map(model, invoice);
            await _invoiceRepository.SaveAsync();
            return _mapper.Map<InvoiceReadDTO>(invoice);
        }
    }
}
