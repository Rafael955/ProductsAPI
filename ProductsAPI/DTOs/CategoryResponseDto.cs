namespace ProductsAPI.DTOs
{
    /// <summary>
    /// Modelo de dados (DTO) para retornar uma consulta
    /// de categorias nos serviços da API
    /// </summary>
    public class CategoryResponseDto
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }
    }
}
