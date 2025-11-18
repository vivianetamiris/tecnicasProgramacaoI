using System;
using System.Collections.Generic;
using System.IO;

namespace CadastroBandas
{
    class Program
    {
        // a) Adicionar bandas
        static void addBandas(List<Banda> listaBandas)
        {
            Banda novaBanda = new Banda();

            Console.Write("\nNome da Banda: ");
            novaBanda.nome = Console.ReadLine();
            Console.Write("Gênero: ");
            novaBanda.genero = Console.ReadLine();
            Console.Write("Número de integrantes: ");
            novaBanda.integrantes = int.Parse(Console.ReadLine());
            Console.Write("Ranking: ");
            novaBanda.ranking = int.Parse(Console.ReadLine());
            Console.WriteLine("--------------");

            listaBandas.Add(novaBanda);
        }

        // b) Listar bandas
        static void mostrarBandas(List<Banda> listaBandas)
        {
            int posicao = 1;

            foreach (Banda b in listaBandas)
            {
                Console.WriteLine($"*** Banda {posicao} ***");
                Console.WriteLine($"{b.nome} - {b.genero} - {b.integrantes} integrantes - Ranking {b.ranking}");
                posicao++;
            }
        }

        // f) Buscar banda por nome
        static bool buscarBanda(List<Banda> listaBandas, string nomeBusca)
        {
            foreach (Banda b in listaBandas)
            {
                if (b.nome.ToUpper() == nomeBusca.ToUpper())
                {
                    Console.WriteLine($"Nome: {b.nome}");
                    Console.WriteLine($"Gênero: {b.genero}");
                    Console.WriteLine($"Integrantes: {b.integrantes}");
                    Console.WriteLine($"Ranking: {b.ranking}");
                    return true;
                }
            }
            return false;
        }

        // Buscar índice
        static int buscarIndiceBanda(List<Banda> listaBandas, string nomeBusca)
        {
            for (int i = 0; i < listaBandas.Count; i++)
            {
                if (listaBandas[i].nome.ToUpper() == nomeBusca.ToUpper())
                {
                    return i;
                }
            }
            return -1;
        }

        // d) Buscar por ranking
        static bool buscarPorRanking(List<Banda> listaBandas, int rankingBuscado)
        {
            bool encontrou = false;

            foreach (Banda b in listaBandas)
            {
                if (b.ranking == rankingBuscado)
                {
                    Console.WriteLine($"Nome: {b.nome}");
                    Console.WriteLine($"Gênero: {b.genero}");
                    Console.WriteLine($"Integrantes: {b.integrantes}");
                    Console.WriteLine($"Ranking: {b.ranking}");
                    Console.WriteLine("------------------------------");
                    encontrou = true;
                }
            }

            return encontrou;
        }

		// e) Crie uma função em que peça ao usuário um gênero de música e exiba todos dados das bandas com este genero.
		static bool buscarPorGenero(List<Banda> listaBandas, string generoBuscado)
		{
		bool encontrou = false;

		foreach (Banda b in listaBandas)
		{
        if (b.genero == generoBuscado)
        {
            Console.WriteLine($"Nome: {b.nome}");
            Console.WriteLine($"Gênero: {b.genero}");
            Console.WriteLine($"Integrantes: {b.integrantes}");
            Console.WriteLine($"Ranking: {b.ranking}");
            Console.WriteLine("------------------------------");
            encontrou = true;
        }
    }

    return encontrou;
}

        // h) Crie uma função para alterar os dados de uma banda [após encontrar a banda, leia novamente todos os dados].
        static bool atualizarBanda(List<Banda> listaBandas, string nomeBanda)
        {
            int i = buscarIndiceBanda(listaBandas, nomeBanda);
            if (i == -1)
                return false;

            Console.WriteLine("*** Dados atuais da banda ***");
            Console.WriteLine($"{listaBandas[i].nome} - {listaBandas[i].genero} - {listaBandas[i].integrantes} - {listaBandas[i].ranking}");

            Console.WriteLine("\nNovos dados:");

            Console.Write("Nome: ");
            listaBandas[i].nome = Console.ReadLine();

            Console.Write("Gênero: ");
            listaBandas[i].genero = Console.ReadLine();

            Console.Write("Integrantes: ");
            listaBandas[i].integrantes = int.Parse(Console.ReadLine());

            Console.Write("Ranking: ");
            listaBandas[i].ranking = int.Parse(Console.ReadLine());

            return true;
        }

        // g) Remover banda
        static bool removerBanda(List<Banda> listaBandas, string nomeBanda)
        {
            int i = buscarIndiceBanda(listaBandas, nomeBanda);
            if (i == -1)
                return false;

            Console.Write($"Tem certeza que deseja remover a banda {nomeBanda}? [1-Sim | 0-Não]: ");
            int resp = int.Parse(Console.ReadLine());

            if (resp == 1)
                listaBandas.RemoveAt(i);

            return true;
        }

        // Menu
        static int menu()
        {
            Console.WriteLine("\n=== Sistema de Cadastro de Bandas ===");
            Console.WriteLine("1 - Adicionar Banda");
            Console.WriteLine("2 - Mostrar Bandas");
            Console.WriteLine("3 - Buscar Banda por Nome");
            Console.WriteLine("4 - Buscar Banda por Ranking");
			Console.WriteLine("5 - Buscar banda por gênero");
            Console.WriteLine("6 - Atualizar Banda");
            Console.WriteLine("7 - Remover Banda");
            Console.WriteLine("0 - Sair");
            Console.Write("Digite sua escolha: ");

            return int.Parse(Console.ReadLine());
        }

        // c) Salvar arquivo
        static void salvarDados(List<Banda> listaBandas, string nomeArquivo)
        {
            using (StreamWriter writer = new StreamWriter(nomeArquivo))
            {
                foreach (Banda b in listaBandas)
                {
                    writer.WriteLine($"{b.nome},{b.genero},{b.integrantes},{b.ranking}");
                }
            }

            Console.WriteLine("Dados salvos com sucesso!");
        }

        // Carregar arquivo
        static void carregarDados(List<Banda> listaBandas, string nomeArquivo)
        {
            if (File.Exists(nomeArquivo))
            {
                string[] linhas = File.ReadAllLines(nomeArquivo);

                foreach (string linha in linhas)
                {
                    string[] campos = linha.Split(',');

                    Banda nova = new Banda();
                    nova.nome = campos[0];
                    nova.genero = campos[1];
                    nova.integrantes = int.Parse(campos[2]);
                    nova.ranking = int.Parse(campos[3]);

                    listaBandas.Add(nova);
                }

                Console.WriteLine("Dados carregados!");
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado!");
            }
        }

        // MAIN
        static void Main()
        {
            List<Banda> listaBandas = new List<Banda>();
            carregarDados(listaBandas, "bandas.txt");

            int opcao;

            do
            {
                opcao = menu();

                switch (opcao)
                {
                    case 1:
                        addBandas(listaBandas);
                        break;

                    case 2:
                        mostrarBandas(listaBandas);
                        break;

                    case 3:
                        Console.Write("Nome da banda: ");
                        string nome = Console.ReadLine();
                        if (!buscarBanda(listaBandas, nome))
                            Console.WriteLine("Banda não encontrada.");
                        break;

                    case 4:
                        Console.Write("Ranking desejado: ");
                        int r = int.Parse(Console.ReadLine());
                        if (!buscarPorRanking(listaBandas, r))
                            Console.WriteLine("Nenhuma banda com esse ranking.");
                        break;
						
					case 5:
					Console.Write("Digite o gênero que deseja buscar: ");
					string generoBuscado = Console.ReadLine();
					if (!buscarPorGenero(listaBandas, generoBuscado))
					{
					Console.WriteLine("Nenhuma banda encontrada com esse gênero.");
					}
					break;


                    case 6:
                        Console.Write("Nome da banda a atualizar: ");
                        nome = Console.ReadLine();
                        if (!atualizarBanda(listaBandas, nome))
                            Console.WriteLine("Banda não encontrada.");
                        break;

                    case 7:
                        Console.Write("Nome da banda a remover: ");
                        nome = Console.ReadLine();
                        if (!removerBanda(listaBandas, nome))
                            Console.WriteLine("Banda não encontrada.");
                        break;

                    case 0:
                        salvarDados(listaBandas, "bandas.txt");
                        Console.WriteLine("Saindo...");
                        break;
                }

                Console.ReadKey();
                Console.Clear();

            } while (opcao != 0);
        }
    }
}