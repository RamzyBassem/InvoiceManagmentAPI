using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XlabAssignment.DAL.Data.Model;

namespace XlabAssignment.DAL.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions options ):base(options)
        {
        }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Invoice_Details> Invoice_Details { get; set; }


    }
}
