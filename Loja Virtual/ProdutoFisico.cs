// Classe ProdutoFisico herda de Produto
// Demonstração de herança e polimorfismo, já que a classe filha sobrescreve o método CalcularPrecoFinal com sua própria lógica.

public class ProdutoFisico : Produto
{
  // Propriedades específicas de ProdutoFisico
  public double Peso { get; set; }
  public string Categoria { get; set; }

  // Propriedade Dimensoes representada como uma classe separada
  public Dimensoes DimensoesProduto { get; set; }

  // Construtor da classe ProdutoFisico, passando parâmetros para o construtor da classe base Produto
  public ProdutoFisico(string nome, string codigo, decimal preco, double peso, Dimensoes dimensoes, string categoria)
      : base(nome, codigo, preco)
  {
    Peso = peso;
    DimensoesProduto = dimensoes;
    Categoria = categoria;
  }

  // Implementação do método abstrato CalcularPrecoFinal
  // Demonstra polimorfismo ao sobrescrever o método da classe base
  public override decimal CalcularPrecoFinal()
  {
    // Definição de uma taxa de imposto fixa (exemplo: 10%)
    decimal taxaDeImposto = 0.10m;
    decimal valorImposto = Preco * taxaDeImposto;

    // Cálculo dos custos de envio com base no peso (exemplo: R$5 por kg)
    decimal custoEnvio = (decimal)(Peso * 5);

    // Soma preço base, imposto e custo de envio para obter o preço final
    decimal precoFinal = Preco + valorImposto + custoEnvio;

    return precoFinal;
  }
}

// Classe para representar as dimensões de um produto físico
public class Dimensoes
{
  public double Altura { get; set; }
  public double Largura { get; set; }
  public double Profundidade { get; set; }

  // Construtor para a classe Dimensoes
  public Dimensoes(double altura, double largura, double profundidade)
  {
    Altura = altura;
    Largura = largura;
    Profundidade = profundidade;
  }
}


// Explicações:
// Herança: A classe ProdutoFisico herda de Produto e reutiliza propriedades e métodos da classe base.
// Polimorfismo: O método CalcularPrecoFinal() é sobrescrito, implementando uma lógica específica para produtos físicos.
// Encapsulamento: Propriedades como Peso, Categoria e DimensoesProduto são encapsuladas com get e set.
// Abstração: ProdutoFisico implementa o método abstrato da classe Produto.