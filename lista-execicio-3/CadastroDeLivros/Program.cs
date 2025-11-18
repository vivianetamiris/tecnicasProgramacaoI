using System;
using System.Collections.Generic;

namespace CadastroLivros
{
    class Program
    {
        // b. Permita cadastrar livros.
        static void addLivros(List<Livro> listaLivros)
        {
            Livro novoLivro = new Livro();

            Console.Write("Título do livro: ");
            novoLivro.titulo = Console.ReadLine();

            Console.Write("Autor do livro: ");
            novoLivro.autor = Console.ReadLine();

            Console.Write("Ano de edição do livro: ");
            novoLivro.ano = int.Parse(Console.ReadLine());

            Console.Write("Número da prateleira do livro: ");
            novoLivro.prateleira = int.Parse(Console.ReadLine());

            listaLivros.Add(novoLivro);
        }

        // c. Procurar livro por título
        static bool buscarLivro(List<Livro> listaLivros, string nomeBusca)
        {
            foreach (Livro l in listaLivros)
            {
                if (l.titulo.ToUpper().Equals(nomeBusca.ToUpper()))
                {
                    Console.WriteLine($"Título do livro: {l.titulo}");
                    Console.WriteLine($"Prateleira: {l.prateleira}");
                    return true;
                }
            }
            return false;
        }

        // d. Mostrar todos os livros cadastrados
        static void mostrarLivros(List<Livro> listaLivros)
        {
            Console.WriteLine("--------Livros Cadastrados--------");

            foreach (Livro l in listaLivros)
            {
                Console.WriteLine($"{l.titulo} - {l.autor} - {l.ano} - {l.prateleira}");
            }
        }

        // e. Buscar livros mais novos que um ano
        static void buscarLivrosMaisNovos(List<Livro> listaLivros, int anoLido)
        {
            bool encontrou = false;

            foreach (Livro l in listaLivros)
            {
                if (l.ano > anoLido)
                {
                    Console.WriteLine($"{l.titulo} - {l.autor} - {l.ano}");
                    encontrou = true;
                }
            }

            if (!encontrou)
            {
                Console.WriteLine("Nenhum livro mais novo que esse ano.");
            }
        }

        // Menu
        static int menu()
        {
            int opcao;

            Console.WriteLine("----------Cadastro de Livros da Biblioteca---------------");
            Console.WriteLine("1 - Cadastrar Livros");
            Console.WriteLine("2 - Buscar livro por título");
            Console.WriteLine("3 - Exibir livros cadastrados");
            Console.WriteLine("4 - Buscar livros mais novos que um ano");
            Console.Write("Digite a opção desejada: ");

            opcao = int.Parse(Console.ReadLine());
            return opcao;
        }

        // Main
        static void Main()
        {
            List<Livro> listaLivros = new List<Livro>();
            int opcao;

            do
            {
                opcao = menu();

                switch (opcao)
                {
                    case 1:
                        addLivros(listaLivros);
                        break;

                    case 2:
                        Console.Write("Título do livro: ");
                        string tituloLivro = Console.ReadLine();

                        bool encontrado = buscarLivro(listaLivros, tituloLivro);

                        if (!encontrado)
                            Console.WriteLine("Livro não encontrado.");
                        break;

                    case 3:
                        mostrarLivros(listaLivros);
                        break;

                    case 4:
                        Console.Write("Digite um ano: ");
                        int ano = int.Parse(Console.ReadLine());
                        buscarLivrosMaisNovos(listaLivros, ano);
                        break;
						
					case 0:
					Console.WriteLine("Saindo...");
					break;

                }
				Console.ReadKey(); //Pausa
				Console.Clear();

            } while (opcao != 0);
        }
    }
}
