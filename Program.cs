using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, int> acoes = new Dictionary<string, int>();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== GERENCIAMENTO DE AÇÕES =====");
            Console.WriteLine("1 - Cadastrar compra de ação");
            Console.WriteLine("2 - Pesquisar transações");
            Console.WriteLine("3 - Listar todas as ações");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
            
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarAcao();
                    break;
                case "2":
                    PesquisarAcao();
                    break;
                case "3":
                    ListarAcoes();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void CadastrarAcao()
    {
        Console.Write("Digite o código da ação: ");
        string codigo = Console.ReadLine().ToUpper();

        Console.Write("Digite a quantidade comprada: ");
        if (int.TryParse(Console.ReadLine(), out int quantidade) && quantidade > 0)
        {
            if (acoes.ContainsKey(codigo))
            {
                acoes[codigo] += quantidade;
                Console.WriteLine("Quantidade atualizada com sucesso!");
            }
            else
            {
                acoes[codigo] = quantidade;
                Console.WriteLine("Ação cadastrada com sucesso!");
            }
        }
        else
        {
            Console.WriteLine("Quantidade inválida!");
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    static void PesquisarAcao()
    {
        Console.Write("Digite o código da ação para pesquisar: ");
        string codigo = Console.ReadLine().ToUpper();

        if (acoes.ContainsKey(codigo))
        {
            Console.WriteLine($"Ação: {codigo} | Quantidade Total: {acoes[codigo]}");
        }
        else
        {
            Console.WriteLine("Ação não encontrada!");
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    static void ListarAcoes()
    {
        Console.WriteLine("===== LISTA DE AÇÕES CADASTRADAS =====");
        if (acoes.Count == 0)
        {
            Console.WriteLine("Nenhuma ação cadastrada.");
        }
        else
        {
            foreach (var acao in acoes)
            {
                Console.WriteLine($"Código: {acao.Key} | Quantidade: {acao.Value}");
            }
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}
