namespace VendasPos.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public List<int> ProdutoIds { get; set; } = new List<int>();
        public DateTime DataPedido { get; set; }
    }
}
