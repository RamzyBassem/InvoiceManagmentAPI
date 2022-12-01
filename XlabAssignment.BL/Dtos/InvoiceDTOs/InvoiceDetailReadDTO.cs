using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XlabAssignment.BL.Dtos.InvoiceDTOs
{
    public class InvoiceDetailReadDTO
    {
        public Guid Invoice_DetailsID { get; set; }

        public string ProductName { get; set; } = String.Empty;
        public double Price { get; set; }

        public double Quantity { get; set; }
        public Guid InvoiceID { get; set; }
    }
}
