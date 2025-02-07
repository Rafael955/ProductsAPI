using Microsoft.EntityFrameworkCore;
using ProductsAPI.Mappings;

namespace ProductsAPI.Contexts
{
    /// <summary>
    /// Classe de contexto para conexão no banco de dados e para configuração do Entity Framework
    /// </summary>
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDProductsAPI;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductMap());

            //outra forma de aplicar as configurações, varre todo o projeto em busca de classes que implementam IEntityTypeConfiguration e aplica as configurações, desvantagem é que pode pegar classes que ainda estão em fase de testes
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
