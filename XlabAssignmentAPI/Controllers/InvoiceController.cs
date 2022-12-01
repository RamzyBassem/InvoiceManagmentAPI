using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XlabAssignment.BL.Dtos.InvoiceDTOs;
using XlabAssignment.BL.Managers.InvoiceManager;

namespace XlabAssignmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceManager _invoiceManager;
        public InvoiceController(IInvoiceManager _invoiceManager)
        {
            this._invoiceManager = _invoiceManager;
        }
        [HttpGet("{InvoiceNumber}")]
        public async Task<ActionResult<InvoiceReadDTO>> GetInvoiceByInvoiceNumber(int InvoiceNumber)
        {
            var response = await _invoiceManager.GetInvoiceByInvoiceNumber(InvoiceNumber);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);

        }

        [HttpPost("create")]
        public async Task<ActionResult<InvoiceReadDTO>> AddInvoice(InvoiceAddDTO model)
        {
           var response = await _invoiceManager.CreateInvoice(model);
           if(response == null)
            {
                return BadRequest();
            }
           return Ok(response);

        }

        [HttpPut("Edit")]
        public async Task<ActionResult<InvoiceReadDTO>> EditInvoice(InvoiceEditDTO model)
        {
            var response = await _invoiceManager.UpdateInvoice(model);
            if (response.ErrorMessage !=string.Empty )
            {
                return BadRequest(response.ErrorMessage);
            }
            return Ok(response);
        }
        [HttpDelete("Delete/{InvoiceNumber}")]
        public async Task<ActionResult<InvoiceReadDTO>> DeleteInvoice(int InvoiceNumber)
        {
            var response = await _invoiceManager.DeleteInvoice(InvoiceNumber);
            if (response==null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
