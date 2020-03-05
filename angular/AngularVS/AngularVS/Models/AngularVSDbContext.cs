using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularVS.Models
{
    public class AngularVSDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public AngularVSDbContext(DbContextOptions<AngularVSDbContext> options): base(options) 
        { }
    }
}
