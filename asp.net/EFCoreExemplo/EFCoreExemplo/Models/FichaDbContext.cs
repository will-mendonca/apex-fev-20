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

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Instrutor> Instrutores { get; set; }
        
        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Avaliacao> Avaliacoes { get; set; }

        public FichaDbContext(DbContextOptions<FichaDbContext> options)
            :base(options)
        {

        }

    }
}
