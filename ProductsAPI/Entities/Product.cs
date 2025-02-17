namespace ProductsAPI.Entities
{
    public class Product
    {
        #region Propriedades

        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public Guid? CategoryId { get; set; }

        #endregion

        #region Relacionamentos

        public virtual Category? Category { get; set; }

        #endregion
    }
}
