using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XlabAssignment.BL.Dtos.InvoiceDTOs
{
    public class InvoiceDetailEditDTO
    {
        public Guid Invoice_DetailsID { get; set; }  = Guid.Empty;
        public string ProductName { get; set; } = String.Empty;
        public double Price { get; set; }

        public double Quantity { get; set; }
        public Guid InvoiceID { get; set; }
    }
}
