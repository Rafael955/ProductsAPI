using ProductsAPI.Contexts;
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
            }
        }
    }
}
