// Classe Loja
// Demonstra a interação entre classes e o gerenciamento de produtos, clientes e pedidos.

public class Loja
{
  // Listas encapsuladas para armazenar produtos, clientes e pedidos
  public List<Produto> Produtos { get; private set; }
  public List<Cliente> Clientes { get; private set; }
  public List<Pedido> Pedidos { get; private set; }

  // Construtor da classe Loja inicializando as listas
  public Loja()
  {
    Produtos = new List<Produto>();
    Clientes = new List<Cliente>();
    Pedidos = new List<Pedido>();
  }

  // Método para cadastrar um novo produto na loja
  public void CadastrarProduto(Produto produto)
  {
    if (produto != null && !Produtos.Contains(produto))
    {
      Produtos.Add(produto);
      Console.WriteLine($"Produto {produto.Nome} cadastrado com sucesso.");
    }
  }

  // Método para consultar produto por código
  public Produto ConsultarProdutoPorCodigo(string codigo)
  {
    return Produtos.FirstOrDefault(p => p.Codigo == codigo);
  }

  // Método para listar todos os produtos
  public void ListarProdutos()
  {
    Console.WriteLine("Produtos Disponíveis:");
    foreach (var produto in Produtos)
    {
      Console.WriteLine($"- {produto.Nome} (Código: {produto.Codigo})");
    }
  }

  // Método para cadastrar um novo cliente
  public void CadastrarCliente(Cliente cliente)
  {
    if (cliente != null && !Clientes.Contains(cliente))
    {
      Clientes.Add(cliente);
      Console.WriteLine($"Cliente {cliente.Nome} cadastrado com sucesso.");
    }
  }

  // Método para consultar cliente por número de identificação
  public Cliente ConsultarClientePorID(string numeroIdentificacao)
  {
    return Clientes.FirstOrDefault(c => c.NumeroIdentificacao == numeroIdentificacao);
  }

  // Método para listar todos os clientes cadastrados
  public void ListarClientes()
  {
    Console.WriteLine("Clientes Cadastrados:");
    foreach (var cliente in Clientes)
    {
      Console.WriteLine($"- {cliente.Nome} (ID: {cliente.NumeroIdentificacao})");
    }
  }

  // Método para criar um novo pedido
  public Pedido CriarPedido(Cliente cliente)
  {
    var pedido = new Pedido(cliente);
    Pedidos.Add(pedido);
    return pedido;
  }

  // Método para finalizar um pedido e atualizar o status
  public void FinalizarPedido(Pedido pedido)
  {
    if (pedido != null)
    {
      pedido.FinalizarPedido();
      Console.WriteLine("Pedido finalizado com sucesso.");
    }
  }

  // Método opcional para listar todos os pedidos
  public void ListarPedidos()
  {
    Console.WriteLine("Pedidos Realizados:");
    foreach (var pedido in Pedidos)
    {
      Console.WriteLine($"- Pedido de {pedido.Cliente.Nome} (Status: {pedido.Status})");
    }
  }
}


// Explicações:
// Encapsulamento: As listas de produtos, clientes e pedidos são encapsuladas, acessadas apenas por métodos controlados.
// Gerenciamento de Produtos, Clientes e Pedidos: A classe Loja centraliza o cadastro e consulta de produtos, clientes e a criação/finalização de pedidos.
// Interação entre classes: A Loja interage com outras classes, como Produto, Cliente e Pedido, demonstrando como os objetos se relacionam no sistema.