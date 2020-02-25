using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreExemplo.Models;

namespace EFCoreExemplo.Models
{
    public class FichaDbContext : DbContext
    {

        public virtual DbSet<Aluno> Alunos { get; set; }

        public virtual DbSet<Instrutor> Instrutores { get; set; }

        public FichaDbContext(DbContextOptions<FichaDbContext> options)
            :base(options)
        {

        }

        public DbSet<EFCoreExemplo.Models.Curso> Curso { get; set; }

    }
}
