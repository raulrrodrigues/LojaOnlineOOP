// Classe Cliente
// Demonstra encapsulamento e manipulação de dados dos clientes.

public class Cliente
{
  // Propriedades públicas com encapsulamento através de get e set
  public string Nome { get; set; }
  public string NumeroIdentificacao { get; set; }
  public string Endereco { get; set; }
  public string Contato { get; set; }

  // Construtor da classe Cliente
  public Cliente(string nome, string numeroIdentificacao, string endereco, string contato)
  {
    Nome = nome;
    NumeroIdentificacao = numeroIdentificacao;
    Endereco = endereco;
    Contato = contato;
  }

  // Método para exibir as informações do cliente
  // Exibe de maneira organizada todas as propriedades do cliente
  public void ExibirInformacoes()
  {
    Console.WriteLine($"Nome: {Nome}");
    Console.WriteLine($"Número de Identificação: {NumeroIdentificacao}");
    Console.WriteLine($"Endereço: {Endereco}");
    Console.WriteLine($"Contato: {Contato}");
  }
}


// Explicações:
// Encapsulamento: Todas as propriedades do cliente, como Nome, NumeroIdentificacao, Endereco e Contato, estão encapsuladas com get e set, permitindo um controle adequado sobre os dados.
// Método ExibirInformacoes(): Mostra de forma organizada os dados do cliente, útil para visualização e debug.