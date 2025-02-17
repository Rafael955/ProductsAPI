using Microsoft.EntityFrameworkCore;
using ProductsAPI.Contexts;
using ProductsAPI.DTOs;
using ProductsAPI.Entities;

namespace ProductsAPI.Repositories
{
    public class ProductRepository
    {
        /// <summary>
        /// Método para gravar um produto no banco de dados
        /// </summary>
        /// <param name="product">Produto a ser cadastrado</param>
        public void Add(Product product)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(product);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Método para atualizar um produto no banco de dados
        /// </summary>
        /// <param name="product">Produto a ser atualizado</param>
        public void Update(Product product)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(product);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Método para excluir um produto no banco de dados
        /// </summary>
        /// <param name="product">Produto a ser removido</param>
        public void Delete(Product product)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(product);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Método para consultar produtos no banco de dados
        /// </summary>
        /// <returns>Retorna uma lista de produtos ordenados pelo nome</returns>
        public List<Product> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Product>()
                    .Include(p => p.Category) //Similar a um JOIN no Banco de Dados
                    .OrderBy(p => p.Name)
                    .ToList();
            }
        }

        /// <summary>
        /// Método para consultar um produto pelo ID
        /// </summary>
        /// <param name="id">O id do produto</param>
        /// <returns></returns>
        public Product? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Product>()
                    .Find(id);
                    //.Include(p => p.Category) //Similar a um JOIN no Banco de Dados
                    //.FirstOrDefault(p => p.Id == id);
            }
        }


        /// <summary>
        /// Método para consultar o somatório da quantidade de produtos
        /// para cada categoria do banco de dados
        /// </summary>
        /// <returns>Uma lista com as categorias e o somatório de seus produtos</returns>
        public List<CategoryProductsResponseDto> GroupByCategory()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Product>() //Tabela de produtos
                    .Include(p => p.Category) //Junção com tabela de categorias
                    .GroupBy(p => p.Category.Name) //Agrupando pelo nome da categoria
                    .Select(g => new CategoryProductsResponseDto
                    {
                        Category = g.Key, //Nome da categoria
                        Products = g.Sum(p => p.Quantity) //Somatório da quantidade de produtos
                    })
                    .ToList(); //Retornar uma lista do DTO
            }
        }
    }
}
