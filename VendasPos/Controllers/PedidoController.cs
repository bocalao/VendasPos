using Microsoft.AspNetCore.Mvc;
using VendasPos.Models;
using VendasPos.Services;

namespace VendasPos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        [HttpGet("ListarPedidos")]
        public IActionResult GetPedidos()
        {
            return Ok(DataService.Pedidos);
        }

        [HttpGet("PesquisarPedido/{id}")]
        public IActionResult GetPedidoById(int id)
        {
            var pedido = DataService.Pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null)
                return NotFound();
            return Ok(pedido);
        }

        [HttpPost("IncluirPedido")]
        public IActionResult CreatePedido([FromBody] Pedido pedido)
        {
            pedido.Id = DataService.Pedidos.Max(p => p.Id) + 1;
            pedido.DataPedido = DateTime.Now;
            DataService.Pedidos.Add(pedido);
            return CreatedAtAction(nameof(GetPedidoById), new { id = pedido.Id }, pedido);
        }

        
        [HttpDelete("CancelarPedido/{id}")]
        public IActionResult DeletePedido(int id)
        {
            var pedido = DataService.Pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null)
                return NotFound();

            DataService.Pedidos.Remove(pedido);
            return NoContent();
        }
    }
}
