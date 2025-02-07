using ProductsAPI.Contexts;
using ProductsAPI.Entities;

namespace ProductsAPI.Repositories
{
    public class CategoryRepository
    {
        /// <summary>
        /// Método para consultar todas as categorias
        /// </summary>
        /// <returns>Retorna uma lista com todas as categorias ordenadas pelo nome</returns>
        public List<Category> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Category>()
                    .OrderBy(c => c.Name)
                    .ToList();
            }
        }
    }
}
