using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XlabAssignment.DAL.Data.Model
{
    public class Invoice_Details
    {
        public Guid Invoice_DetailsID { get; set; }
        public string ProductName { get; set; } = String.Empty;
        public double Price { get; set; }

        public double Quantity { get; set; }
        [ForeignKey("Invoice")]
        public Guid InvoiceID { get; set; }
        public Invoice Invoice { get; set; }
    }
}
