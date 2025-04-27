using VendasPos.Models;

namespace VendasPos.Services
{
    public static class DataService
    {
        public static List<Cliente> Clientes { get; } = new List<Cliente>
        {
            new Cliente { Id = 1, Nome = "João Silva", Endereco = "R. Paulo Jose, 284", Telefone = "(41)96485-2254",Email = "joao@email.com" },
            new Cliente { Id = 2, Nome = "Maria Souza", Endereco = "R. Antonio Silva, 351", Telefone = "(42)98526-3341", Email = "maria@email.com" }
        };
        public static List<Produto> Produtos { get; } = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Produto A", Preco = 10.50M },
            new Produto { Id = 2, Nome = "Produto B", Preco = 20.00M }
        };

        public static List<Pedido> Pedidos { get; } = new List<Pedido>
        {
            new Pedido { Id = 1, ClienteId = 1, ProdutoIds = new List<int> { 1, 2 }, DataPedido = DateTime.Now.AddDays(-1) }
        };

    }
}
