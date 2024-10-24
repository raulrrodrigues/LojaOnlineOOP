// Classe ProdutoDigital herda de Produto
// Demonstra herança e polimorfismo, com uma lógica de cálculo diferente de ProdutoFisico.

public class ProdutoDigital : Produto
{
    // Propriedades específicas de ProdutoDigital
    public double TamanhoArquivo { get; set; }
    public string Formato { get; set; }

    // Construtor da classe ProdutoDigital, passando parâmetros para o construtor da classe base Produto
    public ProdutoDigital(string nome, string codigo, decimal preco, double tamanhoArquivo, string formato)
        : base(nome, codigo, preco)
    {
        TamanhoArquivo = tamanhoArquivo;
        Formato = formato;
    }

    // Implementação do método abstrato CalcularPrecoFinal
    // Demonstra polimorfismo ao sobrescrever o método da classe base
    public override decimal CalcularPrecoFinal()
    {
        // Definição de um desconto fixo para produtos digitais (exemplo: 10%)
        decimal taxaDeDesconto = 0.10m;
        decimal valorDesconto = Preco * taxaDeDesconto;

        // Preço final é o preço base menos o desconto, sem custos de envio ou impostos
        decimal precoFinal = Preco - valorDesconto;

        return precoFinal;
    }
}

// Explicações:
// Herança: A classe ProdutoDigital herda da classe Produto, utilizando as propriedades comuns.
// Polimorfismo: Sobrescreve o método CalcularPrecoFinal(), implementando uma lógica diferente de ProdutoFisico, aqui com desconto.
// Encapsulamento: As propriedades TamanhoArquivo e Formato são encapsuladas com get e set.
// Abstração: Implementa o método abstrato da classe Produto, garantindo que o cálculo de preço seja específico para produtos digitais.