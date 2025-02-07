namespace ProductsAPI.Entities
{
    public class Category
    {
        #region Propriedades

        public Guid? Id { get; set; }
        public string? Name { get; set; }

        #endregion

        #region Relacionamentos

        public List<Product>? Products { get; set; }

        #endregion
    }
}
