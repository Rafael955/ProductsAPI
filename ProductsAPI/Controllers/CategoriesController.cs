using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOs;
using ProductsAPI.Entities;
using ProductsAPI.Repositories;
using System.Collections.Generic;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        /// <summary>
        /// Serviço para consulta de categorias da API
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            //instanciando a classe de repositório
            var categoryRepository = new CategoryRepository();

            //executando a consulta e obter uma lista de categorias
            var categories = categoryRepository.GetAll();

            //criando uma lista de objetos da classe DTO
            var response = new List<CategoryResponseDto>();

            //percorrer as categorias obtidas do banco de dados
            foreach (var category in categories)
            {
                //adicionando cada registro na lista como um DTO
                response.Add(new CategoryResponseDto
                {
                    Id = category.Id, //preenchendo o id da categoria
                    Name = category.Name //preenchendo o nome da categoria
                });
            }

            //preencher as categorias obtidas do banco de dados
            //categories.ForEach(category =>
            //    response.Add(
            //        new CategoryResponseDto
            //        {
            //            Id = category.Id, //preenchendo o id da categoria
            //            Name = category.Name //preenchendo o nome da categoria
            //        }));

            //retornando os dados
            return Ok(response);
        }
    }
}
