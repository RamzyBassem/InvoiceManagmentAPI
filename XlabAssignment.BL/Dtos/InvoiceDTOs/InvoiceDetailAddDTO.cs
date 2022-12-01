using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XlabAssignment.BL.Dtos.InvoiceDTOs
{
    public class InvoiceDetailAddDTO
    {

        public string ProductName { get; set; } = String.Empty;
        public double Price { get; set; }
        public double Quantity { get; set; }
    }
}
