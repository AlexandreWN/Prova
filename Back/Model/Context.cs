using Microsoft.EntityFrameworkCore;
namespace Model;

public class Context : DbContext
{
    public DbSet<User> User { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source = SNCCH01LABF113\\TEW_SQLEXPRESS; Initial Catalog = AbsolsMask; Integrated Security = True");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.id);
            entity.Property(u => u.login);
            entity.Property(u => u.password);
            entity.Property(u => u.idade);
            entity.Property(u => u.raca);
            entity.Property(u => u.foto);
        });
    }
}