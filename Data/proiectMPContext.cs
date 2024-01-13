using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proiectMP.Models;

namespace proiectMP.Data
{
    public class proiectMPContext : DbContext
    {
        public proiectMPContext (DbContextOptions<proiectMPContext> options)
            : base(options)
        {
        }

        public DbSet<proiectMP.Models.Product> Product { get; set; } = default!;
    }
}
