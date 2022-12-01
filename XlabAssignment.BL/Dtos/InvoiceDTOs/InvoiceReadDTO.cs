using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XlabAssignment.BL.Dtos.InvoiceDTOs
{
    public class InvoiceReadDTO
    {
        public Guid InvoiceID { get; set; }

        public int InvoiceNumber { get; set; }
        public string ClientName { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; }
        public IEnumerable<InvoiceDetailReadDTO> Invoice_Details { get; set; } = new HashSet<InvoiceDetailReadDTO>();

        public string ErrorMessage = String.Empty;
    }
}
