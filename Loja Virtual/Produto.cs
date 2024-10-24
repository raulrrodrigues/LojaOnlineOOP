// Classe abstrata Produto
// Representa um modelo geral de Produto, não pode ser instanciada diretamente
// Demonstração de abstração, pois encapsula propriedades e força a implementação do método CalcularPrecoFinal nas classes derivadas.

public abstract class Produto
{
  // Propriedade pública Nome, com encapsulamento através de get e set
  public string Nome { get; set; }

  // Propriedade pública Código, pode ser gerada automaticamente
  public string Codigo { get; set; }

  // Propriedade pública Preço, também encapsulada com get e set
  public decimal Preco { get; set; }

  // Construtor da classe Produto
  public Produto(string nome, string codigo, decimal preco)
  {
    Nome = nome;
    Codigo = codigo;
    Preco = preco;
  }

  // Método abstrato para calcular o preço final
  // Força as classes derivadas a implementar sua própria lógica
  public abstract decimal CalcularPrecoFinal();
}

// Explicações:
// Abstração: A classe Produto é abstrata e não pode ser instanciada diretamente. Isso força a implementação do método CalcularPrecoFinal() nas subclasses, garantindo que cada tipo de produto tenha sua lógica de cálculo.
// Encapsulamento: As propriedades Nome, Codigo e Preco estão encapsuladas com get e set, permitindo acesso controlado.