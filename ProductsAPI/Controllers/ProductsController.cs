using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOs;
using ProductsAPI.Entities;
using ProductsAPI.Repositories;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Serviço para cadastro de produto da API
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ProductResponseDto), 200)]
        public IActionResult Post([FromBody] ProductRequestDto request)
        {
            //criando um objeto da classe Produto
            var product = new Product
            {
                Id = Guid.NewGuid(), //gerando um novo identificador único
                Name = request.Name, //preenchendo o nome do produto
                Price = request.Price, //preenchendo o preço do produto
                Quantity = request.Quantity, //preenchendo a quantidade do produto
                CategoryId = request.CategoryId //preenchendo o di da categoria do produto
            };

            //criando um objeto da classe de repositório
            var productRepository = new ProductRepository();
            productRepository.Add(product);// gravando o produto no banco de dados

            //retornar um status de sucesso na API (HTTP 200 - OK)
            return Ok(new
            {
                Message = "Produto cadastrado com sucesso.", //mensagem de sucesso
                CreatedAt = DateTime.Now, //data e hora do cadastro
                ProductId = product.Id, //ID do produto que foi cadastrado
            });
        }

        /// <summary>
        /// Serviço para atualização de produto da API
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductResponseDto), 200)]
        public IActionResult Put(Guid id, [FromBody] ProductRequestDto request)
        {
            //criando um objeto da classe de repositório
            var productRepository = new ProductRepository();

            //consultar o produto no banco de dados através do ID
            var product = productRepository.GetById(id);

            //modificando os dados do produto com as informações da requisição
            product.Name = request.Name; //preenchendo o nome do produto
            product.Price = request.Price; //preenchendo o preço do produto
            product.Quantity = request.Quantity; //preenchendo a quantidade do produ.to
            product.CategoryId = request.CategoryId; //preenchendo o id da categoria do produto

            //atualizar o produto no banco de dados
            productRepository.Update(product);

            //retornar um status de sucesso na API (HTTP 200 - OK)
            return Ok(new
            {
                Message = "Produto alterado com sucesso.", //mensagem de sucesso
                CreatedAt = DateTime.Now, //data e hora da atualização
                ProductId = product.Id, //ID do produto que foi atualizado
            });
        }

        /// <summary>
        /// Serviço para exclusão de produto da API
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProductResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            //criando um objeto da classe de repositório
            var productRepository = new ProductRepository();
            //consultar o produto no banco de dados através do ID
            var product = productRepository.GetById(id);

            //excluindo o produto
            productRepository.Delete(product);

            //retornando os dados da resposta
            return Ok(new
            {
                Message = "Produto excluído com sucesso.", //mensagem de sucesso
                DeletedAt = DateTime.Now, //data e hora da exclusão
                ProductId = id, //id do produto que foi excluido
            });
        }

        /// <summary>
        /// Serviço para consulta de produtos da API
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ProductResponseDto), 200)]
        public IActionResult Get()
        {
            //criando um objeto da classe de repositório
            var productRepository = new ProductRepository();
            //consultar o produto no banco de dados através do ID
            var products = productRepository.GetAll();

            //criando uma lista de objetos da classe DTO
            var response = new List<ProductResponseDto>();

            //percorrer os produtos obtidos do banco de dados
            foreach (var product in products)
            {
                //adicionando cada registro na lista como um DTO
                response.Add(new ProductResponseDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    CategoryId = product.Category?.Id,
                    CategoryName = product.Category?.Name
                });
            }

            //Carregando a lista DTO de produtos
            //products.ForEach(product =>
            //    response.Add(
            //        new ProductResponseDto
            //        {
            //            Id = product.Id,
            //            Name = product.Name,
            //            Price = product.Price,
            //            Quantity = product.Quantity,
            //            CategoriaId = product.CategoryId
            //        }));

            //retornar os dados dos produtos
            return Ok(response);
        }

        /// <summary>
        /// Serviço para consulta de um produto da API pelo id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            //criando um objeto da classe de repositório
            var productRepository = new ProductRepository();
            //consultar o produto no banco de dados através do ID
            var product = productRepository.GetById(id);

            //criando um objeto da classe DTO para retornar os dados do produto
            var response = new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CategoryId = product.CategoryId
            };

            //retornar os dados do produto
            return Ok(response);
        }
    }
}
