using Microsoft.AspNetCore.Mvc;
using VendasPos.Models;
using VendasPos.Services;

namespace VendasPos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        [HttpGet("ListarProdutos")]
        public IActionResult GetProdutos()
        {
            return Ok(DataService.Produtos);
        }

        [HttpGet("PesquisarProduto/{id}")]
        public IActionResult GetProdutoById(int id)
        {
            var produto = DataService.Produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return NotFound();
            return Ok(produto);
        }

        [HttpPost("InserirProduto")]
        public IActionResult CreateProduto([FromBody] Produto produto)
        {
            produto.Id = DataService.Produtos.Max(p => p.Id) + 1;
            DataService.Produtos.Add(produto);
            return CreatedAtAction(nameof(GetProdutoById), new { id = produto.Id }, produto);
        }

        [HttpPut("AtualizarProduto/{id}")]
        public IActionResult UpdateProduto(int id, [FromBody] Produto produtoAtualizado)
        {
            var produto = DataService.Produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return NotFound();

            produto.Nome = produtoAtualizado.Nome;
            produto.Preco = produtoAtualizado.Preco;

            return NoContent();
        }

        [HttpDelete("RemoverProduto/{id}")]
        public IActionResult DeleteProduto(int id)
        {
            var produto = DataService.Produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return NotFound();

            DataService.Produtos.Remove(produto);
            return NoContent();
        }
    }
}
