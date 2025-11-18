using System;
using System.Collections.Generic;
using System.IO;

namespace CadastroFazenda
{
    class Program
    {
        // a) Cadastrar gado
        static void addGado(List<Registros> lista)
        {
            Registros gado = new Registros();

            Console.Write("Código do animal: ");
            gado.codigo = int.Parse(Console.ReadLine());

            Console.Write("Produção de leite semanal (Litros): ");
            gado.leite = double.Parse(Console.ReadLine());

            Console.Write("Quantidade de alimento semanal (KG): ");
            gado.alim = double.Parse(Console.ReadLine());

            gado.nasc = new Data();
            Console.Write("Mês de nascimento (1-12): ");
            gado.nasc.mes = int.Parse(Console.ReadLine());

            Console.Write("Ano de nascimento: ");
            gado.nasc.ano = int.Parse(Console.ReadLine());

            int idade = DateTime.Now.Year - gado.nasc.ano;
            if (idade > 5 || gado.leite < 40)
            {
                gado.abate = 'S';
            }
            else
            {
                gado.abate = 'N';
            }

            lista.Add(gado);
            Console.WriteLine("Gado cadastrado com sucesso!");
        }

        // c) Total de leite por semana
        static void totalLeite(List<Registros> lista)
        {
            double total = 0;
            foreach (Registros gado in lista)
            {
                total += gado.leite;
            }
            Console.WriteLine("Total de leite por semana: " + total + " Litros");
        }

        // d) Total de alimento por semana
        static void totalAlimento(List<Registros> lista)
        {
            double total = 0;
            foreach (Registros gado in lista)
            {
                total += gado.alim;
            }
            Console.WriteLine("Total de alimento por semana: " + total + " KG");
        }

        // e) Listar gados para abate
        static void listarAbate(List<Registros> lista)
        {
            bool encontrou = false;
            foreach (Registros gado in lista)
            {
                if (gado.abate == 'S')
                {
                    Console.WriteLine($"Código: {gado.codigo} - Leite: {gado.leite} L - Alimento: {gado.alim} KG - Nasc: {gado.nasc.mes}/{gado.nasc.ano}");
                    encontrou = true;
                }
            }
            if (!encontrou)
            {
                Console.WriteLine("Nenhum animal para abate.");
            }
        }

        // f) Salvar dados em arquivo
        static void salvarDados(List<Registros> lista)
        {
            using (StreamWriter sw = new StreamWriter("fazenda.txt"))
            {
                foreach (Registros gado in lista)
                {
                    sw.WriteLine($"{gado.codigo};{gado.leite};{gado.alim};{gado.nasc.mes};{gado.nasc.ano};{gado.abate}");
                }
            }
            Console.WriteLine("Dados salvos com sucesso!");
        }

        // f) Carregar dados de arquivo
        static void carregarDados(List<Registros> lista)
        {
            if (File.Exists("fazenda.txt"))
            {
                using (StreamReader sr = new StreamReader("fazenda.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] partes = line.Split(';');
                        Registros gado = new Registros();
                        gado.codigo = int.Parse(partes[0]);
                        gado.leite = double.Parse(partes[1]);
                        gado.alim = double.Parse(partes[2]);
                        gado.nasc = new Data();
                        gado.nasc.mes = int.Parse(partes[3]);
                        gado.nasc.ano = int.Parse(partes[4]);
                        gado.abate = char.Parse(partes[5]);
                        lista.Add(gado);
                    }
                }
                Console.WriteLine("Dados carregados com sucesso!");
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.");
            }
        }

        // Menu
        static int menu()
        {
            Console.WriteLine("\n--- Sistema de Controle de Gado ---");
            Console.WriteLine("1 - Cadastrar gado");
            Console.WriteLine("2 - Total de leite por semana");
            Console.WriteLine("3 - Total de alimento por semana");
            Console.WriteLine("4 - Listar gados para abate");
            Console.WriteLine("5 - Salvar dados em arquivo");
            Console.WriteLine("6 - Carregar dados de arquivo");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
            return int.Parse(Console.ReadLine());
        }

        static void Main()
        {
            List<Registros> lista = new List<Registros>();
            int opcao;
            do
            {
                opcao = menu();
                switch (opcao)
                {
                    case 1: addGado(lista); break;
                    case 2: totalLeite(lista); break;
                    case 3: totalAlimento(lista); break;
                    case 4: listarAbate(lista); break;
                    case 5: salvarDados(lista); break;
                    case 6: carregarDados(lista); break;
                    case 0: Console.WriteLine("Saindo do programa..."); break;
                    default: Console.WriteLine("Opção inválida!"); break;
                }
          
                Console.ReadKey();
                Console.Clear();
            } while (opcao != 0);
        }
    }
}
