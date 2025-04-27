using Microsoft.AspNetCore.Mvc;
using VendasPos.Models;
using VendasPos.Services;

namespace VendasPos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        [HttpGet("ListarClientes")]
        public IActionResult GetClientes()
        {
            return Ok(DataService.Clientes);
        }

        [HttpGet("PesquisarCliente/{id}")]       
        public IActionResult GetClienteById(int id)
        {
            var cliente = DataService.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        [HttpGet("PesquisarClienteNome/{nome}")]
        public IActionResult PesquisarClientesPorNome(string nome)
        {
            var clientesEncontrados = DataService.Clientes
                .Where(c => c.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (clientesEncontrados == null || !clientesEncontrados.Any())
                return NotFound("Nenhum cliente encontrado com esse nome.");

            return Ok(clientesEncontrados);
        }

        [HttpPost("InserirCliente")]
        public IActionResult CreateCliente([FromBody] Cliente cliente)
        {
            cliente.Id = DataService.Clientes.Max(c => c.Id) + 1;
            DataService.Clientes.Add(cliente);
            return CreatedAtAction(nameof(GetClienteById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("AtualizarCliente/{id}")]
        public IActionResult UpdateCliente(int id, [FromBody] Cliente clienteAtualizado)
        {
            var cliente = DataService.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                return NotFound();

            cliente.Nome = clienteAtualizado.Nome;
            cliente.Email = clienteAtualizado.Email;

            return NoContent();
        }

        [HttpDelete("RemoverCliente/{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var cliente = DataService.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                return NotFound();

            DataService.Clientes.Remove(cliente);
            return NoContent();
        }

    }
}
