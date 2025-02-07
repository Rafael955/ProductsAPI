namespace ProductsAPI.DTOs
{
    public class ProductResponseDto
    {
        public Guid? Id { get; set; }
        
        public string? Name { get; set; }
        
        public decimal? Price { get; set; }
        
        public int? Quantity { get; set; }
        
        public decimal? Total { get => Price * Quantity; }

        public Guid? CategoriaId { get; set; }
    }
}
