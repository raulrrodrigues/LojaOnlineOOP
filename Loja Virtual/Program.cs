using System;

class Program
{
    static void Main(string[] args)
    {
        // Criação de uma nova loja
        Loja loja = new Loja();
        bool rodando = true;

        // Menu de opções
        while (rodando)
        {
            Console.WriteLine("\n--- Sistema de Gerenciamento de Loja Online ---");
            Console.WriteLine("1. Cadastrar Produto");
            Console.WriteLine("2. Cadastrar Cliente");
            Console.WriteLine("3. Listar Produtos");
            Console.WriteLine("4. Listar Clientes");
            Console.WriteLine("5. Criar Pedido");
            Console.WriteLine("6. Finalizar Pedido");
            Console.WriteLine("7. Listar Pedidos");
            Console.WriteLine("8. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarProduto(loja);
                    break;
                case "2":
                    CadastrarCliente(loja);
                    break;
                case "3":
                    loja.ListarProdutos();
                    break;
                case "4":
                    loja.ListarClientes();
                    break;
                case "5":
                    CriarPedido(loja);
                    break;
                case "6":
                    FinalizarPedido(loja);
                    break;
                case "7":
                    loja.ListarPedidos();
                    break;
                case "8":
                    rodando = false;
                    Console.WriteLine("Saindo do sistema...");
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }

    // Função para cadastrar um novo produto
    static void CadastrarProduto(Loja loja)
    {
        Console.WriteLine("\nCadastro de Produto");
        Console.Write("Nome do produto: ");
        string nome = Console.ReadLine();

        Console.Write("Código do produto: ");
        string codigo = Console.ReadLine();

        Console.Write("Preço do produto: ");
        decimal preco = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Produto é Físico ou Digital? (F/D): ");
        string tipo = Console.ReadLine().ToUpper();

        if (tipo == "F")
        {
            Console.Write("Peso do produto (kg): ");
            double peso = Convert.ToDouble(Console.ReadLine());

            Console.Write("Altura do produto (cm): ");
            double altura = Convert.ToDouble(Console.ReadLine());

            Console.Write("Largura do produto (cm): ");
            double largura = Convert.ToDouble(Console.ReadLine());

            Console.Write("Profundidade do produto (cm): ");
            double profundidade = Convert.ToDouble(Console.ReadLine());

            Dimensoes dimensoes = new Dimensoes(altura, largura, profundidade);

            Console.Write("Categoria do produto: ");
            string categoria = Console.ReadLine();

            ProdutoFisico produtoFisico = new ProdutoFisico(nome, codigo, preco, peso, dimensoes, categoria);
            loja.CadastrarProduto(produtoFisico);
        }
        else if (tipo == "D")
        {
            Console.Write("Tamanho do arquivo (MB): ");
            double tamanhoArquivo = Convert.ToDouble(Console.ReadLine());

            Console.Write("Formato do arquivo: ");
            string formato = Console.ReadLine();

            ProdutoDigital produtoDigital = new ProdutoDigital(nome, codigo, preco, tamanhoArquivo, formato);
            loja.CadastrarProduto(produtoDigital);
        }
        else
        {
            Console.WriteLine("Tipo de produto inválido.");
        }
    }

    // Função para cadastrar um novo cliente
    static void CadastrarCliente(Loja loja)
    {
        Console.WriteLine("\nCadastro de Cliente");
        Console.Write("Nome do cliente: ");
        string nome = Console.ReadLine();

        Console.Write("Número de Identificação: ");
        string numeroIdentificacao = Console.ReadLine();

        Console.Write("Endereço do cliente: ");
        string endereco = Console.ReadLine();

        Console.Write("Contato do cliente: ");
        string contato = Console.ReadLine();

        Cliente cliente = new Cliente(nome, numeroIdentificacao, endereco, contato);
        loja.CadastrarCliente(cliente);
    }

    // Função para criar um novo pedido
    static void CriarPedido(Loja loja)
    {
        Console.WriteLine("\nCriação de Pedido");
        Console.Write("Número de Identificação do Cliente: ");
        string numeroIdentificacao = Console.ReadLine();

        Cliente cliente = loja.ConsultarClientePorID(numeroIdentificacao);
        if (cliente != null)
        {
            Pedido pedido = loja.CriarPedido(cliente);
            bool adicionandoProdutos = true;

            while (adicionandoProdutos)
            {
                Console.Write("Digite o código do produto para adicionar ao pedido (ou 'finalizar' para concluir): ");
                string codigoProduto = Console.ReadLine();

                if (codigoProduto.ToLower() == "finalizar")
                {
                    break;
                }

                Produto produto = loja.ConsultarProdutoPorCodigo(codigoProduto);
                if (produto != null)
                {
                    pedido.AdicionarProduto(produto);
                }
                else
                {
                    Console.WriteLine("Produto não encontrado.");
                }
            }

            Console.WriteLine($"Total do pedido: {pedido.CalcularTotal()}");
        }
        else
        {
            Console.WriteLine("Cliente não encontrado.");
        }
    }

    // Função para finalizar um pedido
    static void FinalizarPedido(Loja loja)
    {
        Console.WriteLine("\nFinalização de Pedido");
        Console.Write("Número de Identificação do Cliente: ");
        string numeroIdentificacao = Console.ReadLine();

        Cliente cliente = loja.ConsultarClientePorID(numeroIdentificacao);
        if (cliente != null)
        {
            Pedido pedido = loja.Pedidos.FirstOrDefault(p => p.Cliente == cliente && p.Status == "Em Processamento");
            if (pedido != null)
            {
                loja.FinalizarPedido(pedido);
                Console.WriteLine("Pedido finalizado.");
            }
            else
            {
                Console.WriteLine("Pedido não encontrado ou já concluído.");
            }
        }
        else
        {
            Console.WriteLine("Cliente não encontrado.");
        }
    }
}
