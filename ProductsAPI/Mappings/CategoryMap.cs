using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsAPI.Entities;

namespace ProductsAPI.Mappings
{
    /// <summary>
    /// Classe de mapeamento para a entidade Categoria.
    /// </summary>
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("CATEGORIES"); //nome da tabela do banco de dados

            builder.HasKey(c => c.Id); //chave primária da tabela

            builder.Property(c => c.Id)
                .HasColumnName("ID"); //nome do campo na tabela

            builder.Property(c => c.Name)
                .HasColumnName("NAME") //nome do campo na tabela
                .HasMaxLength(50) //máximo de caracteres
                .IsRequired(); //obrigatório (not null)

            builder.HasIndex(c => c.Name) //criando um índice para o campo
                .IsUnique(); //configurando como campo único (não pode ter valor repetido)
        }
    }

}
