using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.DTOs
{
    /// <summary>
    /// Modelo de dados (DTO) para receber uma solicitação / requisição
    /// de cadastrou atualização de dados de produto.
    /// </summary>
    public class ProductRequestDto
    {
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres")]
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres")]
        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        public string? Name { get; set; }

        [Range(0.01, 999999, ErrorMessage = "Por favor, informe um preço entre {1} e {2}")]
        [Required(ErrorMessage = "Por favor, informe o preço do produto.")]
        public decimal? Price { get; set; }

        [Range(1, 99999, ErrorMessage = "Por favor, informe a quantidade entre {1} e {2}.")]
        [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Por favor, informe a categoria do produto.")]
        public Guid? CategoryId { get; set; }
    }
}
