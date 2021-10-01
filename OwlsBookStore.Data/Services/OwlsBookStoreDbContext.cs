using OwlsBookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Services
{
    public class OwlsBookStoreDbContext : DbContext
    {
        public DbSet<Writer> writers { get; set; }
    }
}
