using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XlabAssignment.DAL.Data.Model
{
    public class Invoice
    {
        public Guid InvoiceID { get; set; }
        public int InvoiceNumber { get; set; }
        public string ClientName { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; }
        public ICollection<Invoice_Details> Invoice_Details { get; set; } = new HashSet<Invoice_Details>();

    }
}
