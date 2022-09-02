using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;

public class DatabaseContext : DbContext
{
    public class DatabaseContext
    (
        DbContextOptions<DatabaseContext> options
    ) : base(options)
    {

    }

   public DbSet<Pessoa> Pessoa { get; set; }

   public DbSet<Contrato> Contratos {get; set;}

   protected override void OnModelCreating(ModelBuilder 
   builder){
     builder.Entity<Pessoa>(e =>{
        tabela.HasKey(e => e.Id);
        tabela
           .HasMany(e => e.contratos)
           .WithOne()
           .HasForeignKey( c => c.PessoaId);

     });

     builder.Entity<Contrato>(e =>{
        tabela.HasKey(e => e.Id);

     });
    
   }
}
