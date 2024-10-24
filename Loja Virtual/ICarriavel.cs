// Interface ICarriavel
// Define os métodos que devem ser implementados por classes que podem carregar produtos.

public interface ICarriavel
{
    void AdicionarProduto(Produto produto);
    void RemoverProduto(Produto produto);
    decimal CalcularTotal();
}

// Classe Pedido implementa ICarriavel
// Demonstração de polimorfismo e encapsulamento ao gerenciar pedidos de clientes.

public class Pedido : ICarriavel
{
    // Propriedades da classe Pedido
    public Cliente Cliente { get; set; }
    public DateTime DataPedido { get; private set; }
    public string Status { get; private set; }
    public List<Produto> Produtos { get; private set; }

    // Construtor da classe Pedido
    public Pedido(Cliente cliente)
    {
        Cliente = cliente;
        DataPedido = DateTime.Now;
        Status = "Em Processamento";
        Produtos = new List<Produto>();
    }

    // Implementação do método AdicionarProduto da interface ICarriavel
    public void AdicionarProduto(Produto produto)
    {
        if (produto != null)
        {
            Produtos.Add(produto);
            Console.WriteLine($"Produto {produto.Nome} adicionado ao pedido.");
        }
    }

    // Implementação do método RemoverProduto da interface ICarriavel
    public void RemoverProduto(Produto produto)
    {
        if (Produtos.Contains(produto))
        {
            Produtos.Remove(produto);
            Console.WriteLine($"Produto {produto.Nome} removido do pedido.");
        }
    }

    // Implementação do método CalcularTotal da interface ICarriavel
    public decimal CalcularTotal()
    {
        decimal total = 0;
        foreach (var produto in Produtos)
        {
            total += produto.CalcularPrecoFinal(); // Polimorfismo: chama o método específico de cada tipo de produto
        }
        return total;
    }

    // Método FinalizarPedido, que atualiza o status do pedido
    public void FinalizarPedido()
    {
        Status = "Concluído";
        Console.WriteLine("Pedido finalizado com sucesso.");
    }
}


// Explicações:
// Interface ICarriavel: Define os métodos obrigatórios (AdicionarProduto, RemoverProduto e CalcularTotal), implementados na classe Pedido. Isso demonstra polimorfismo, pois permite que diferentes classes implementem os mesmos métodos.
// Encapsulamento: A lista de produtos e o status do pedido são encapsulados para garantir que só sejam manipulados por métodos controlados.
// Polimorfismo: O método CalcularTotal() usa polimorfismo para chamar o método CalcularPrecoFinal() de cada produto na lista, independentemente de ser um produto físico ou digital.