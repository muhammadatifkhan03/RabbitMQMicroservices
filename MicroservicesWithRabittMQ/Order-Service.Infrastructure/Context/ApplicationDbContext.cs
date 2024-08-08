using Microsoft.EntityFrameworkCore;
using Order_Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Service.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Adding Orders DBSet Property
        public DbSet<Order> Orders { get; set; }
    }
}
