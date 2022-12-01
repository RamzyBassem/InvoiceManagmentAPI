using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XlabAssignment.BL.Dtos.InvoiceDTOs
{
    public class InvoiceAddDTO
    {

        public int InvoiceNumber { get; set; }
        public string ClientName { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; }
        public IEnumerable<InvoiceDetailAddDTO> Invoice_Details { get; set; } = new HashSet<InvoiceDetailAddDTO>();
    }
}
