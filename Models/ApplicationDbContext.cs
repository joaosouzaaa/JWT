using Microsoft.EntityFrameworkCore;

namespace crudapijwtdelete.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(p =>
            {
                p.HasKey(p => p.Id);
                p.Property(p => p.Nome).IsRequired().IsUnicode(false);
                p.Property(p => p.Email).IsRequired().IsUnicode(false);
                p.Property(p => p.Idade).IsRequired();
                p.Property(p => p.Sobrenome).IsRequired().IsUnicode(false);
            });

            modelBuilder.Entity<Token>(t =>
            {
                t.HasKey(t => t.Id);
                t.Property(t => t.Email).IsUnicode(false);
                t.Property(t => t.Password).IsUnicode(false);
            });
        }
    }
}
