using System;
using System.Collections.Generic;

namespace CadastroJogos
{
    class Program
    {
        // Exibe menu e retorna a opção escolhida
        static int Menu()
        {
            Console.WriteLine("Cadastro de Jogos");
            Console.WriteLine("1 - Cadastrar novo jogo");
            Console.WriteLine("2 - Buscar jogos por título ou console");
            Console.WriteLine("3 - Anotar empréstimo");
            Console.WriteLine("4 - Devolução de um jogo");
            Console.WriteLine("5 - Lista de jogos emprestados");
            Console.WriteLine("0 - Sair do sistema");
            Console.Write("Digite a opção escolhida: ");
            return int.Parse(Console.ReadLine());
        }

        // Cadastrar um novo jogo
        static void CadastrarJogo(List<Jogo> lista)
        {
            Jogo j = new Jogo();
            j.info = new Emprestimo(); 

            Console.Write("Título (máx 30 letras): ");
            j.titulo = Console.ReadLine();

            Console.Write("Console (máx 15 letras): ");
            j.console = Console.ReadLine();

            Console.Write("Ano do jogo: ");
            j.ano = int.Parse(Console.ReadLine());

            Console.Write("Ranking do jogo: ");
            j.ranking = int.Parse(Console.ReadLine());

            j.info.emprestado = 'N';
            j.info.nomePessoa = "";
            j.info.data = "";

            lista.Add(j);
            Console.WriteLine("Jogo cadastrado com sucesso!");
        }

        // Busca por título ou console
        static void BuscarPorTituloOuConsole(List<Jogo> lista, string busca)
        {
            bool encontrou = false;
            foreach (Jogo j in lista)
            {
                if (j.titulo.ToUpper().Contains(busca.ToUpper()) || j.console.ToUpper().Contains(busca.ToUpper()))
                {
                    Console.WriteLine($"\nTítulo: {j.titulo}");
                    Console.WriteLine($"Console: {j.console}");
                    Console.WriteLine($"Ano: {j.ano}");
                    Console.WriteLine($"Ranking: {j.ranking}");
                    Console.WriteLine($"Emprestado: {j.info.emprestado}");
                    if (j.info.emprestado == 'S')
                        Console.WriteLine($"Para: {j.info.nomePessoa} em {j.info.data}");
                    encontrou = true;
                }
            }
            if (!encontrou)
                Console.WriteLine("Jogo ou console não foi encontrado.");
        }

        // Registra empréstimo
        static void EmprestarJogo(List<Jogo> lista, string titulo)
        {
            foreach (Jogo j in lista)
            {
                if (j.titulo.ToUpper() == titulo.ToUpper())
                {
                    if (j.info.emprestado == 'S')
                    {
                        Console.WriteLine("Este jogo está emprestado!");
                        return;
                    }
                    j.info.emprestado = 'S';
                    Console.Write("Nome da pessoa: ");
                    j.info.nomePessoa = Console.ReadLine();
                    j.info.data = DateTime.Now.ToString("dd/MM/yyyy");
                    Console.WriteLine("Empréstimo registrado com sucesso!");
                    return;
                }
            }
            Console.WriteLine("Jogo não encontrado.");
        }

        // Devolve um jogo
        static void DevolverJogo(List<Jogo> lista, string titulo)
        {
            foreach (Jogo j in lista)
            {
                if (j.titulo.ToUpper() == titulo.ToUpper())
                {
                    if (j.info.emprestado == 'N')
                    {
                        Console.WriteLine("O jogo está disponível.");
                        return;
                    }
                    j.info.emprestado = 'N';
                    j.info.nomePessoa = "";
                    j.info.data = "";
                    Console.WriteLine("Devolução feita com sucesso!");
                    return;
                }
            }
            Console.WriteLine("Jogo não encontrado.");
        }

        // Lista todos os jogos emprestados
        static void ListarEmprestados(List<Jogo> lista)
        {
            bool encontrou = false;
            foreach (Jogo j in lista)
            {
                if (j.info.emprestado == 'S')
                {
                    Console.WriteLine($"Título: {j.titulo}");
                    Console.WriteLine($"Emprestado para: {j.info.nomePessoa} em {j.info.data}");
                    encontrou = true;
                }
            }
            if (!encontrou)
                Console.WriteLine("Nenhum jogo está emprestado.");
        }

        // main
        static void Main(string[] args)
        {
            List<Jogo> listaJogos = new List<Jogo>();
            int opcao;
            do
            {
                opcao = Menu();
                switch (opcao)
                {
                    case 1:
                        CadastrarJogo(listaJogos);
                        break;
                    case 2:
                        Console.Write("Digite o título ou console: ");
                        string busca = Console.ReadLine();
                        BuscarPorTituloOuConsole(listaJogos, busca);
                        break;
                    case 3:
                        Console.Write("Digite o título do jogo para empréstimo: ");
                        string tituloEmprestimo = Console.ReadLine();
                        EmprestarJogo(listaJogos, tituloEmprestimo);
                        break;
                    case 4:
                        Console.Write("Digite o título do jogo para devolução: ");
                        string tituloDevolucao = Console.ReadLine();
                        DevolverJogo(listaJogos, tituloDevolucao);
                        break;
                    case 5:
                        Console.WriteLine("Jogos emprestados:");
                        ListarEmprestados(listaJogos);
                        break;
                    case 0:
                        Console.WriteLine("Saindo do sistema.");
                        break;
                   
                }
              
                Console.ReadKey();
                Console.Clear();
            } while (opcao != 0);
        }
    }
}
