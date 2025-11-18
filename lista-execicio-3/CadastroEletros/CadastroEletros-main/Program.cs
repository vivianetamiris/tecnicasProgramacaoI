using System;
using System.Collections.Generic;
using System.IO;

namespace CadastroEletro
{
    class Program
    {
        // a) Estrutura para armazenar os dados de cada eletrodoméstico já está no Eletro.cs
        static void addEletro(List<Eletro> listaEletros)
        {
            Eletro novoEletro = new Eletro();
            Console.Write("Entre com o nome:");
            novoEletro.nome = Console.ReadLine() ?? "";
            Console.Write("Entre com a potencia:");
            novoEletro.potencia = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Entre com a tempo medio de uso diario:");
            novoEletro.tempoMedioUsoDiario = double.Parse(Console.ReadLine() ?? "0");
            listaEletros.Add(novoEletro);
        }

        // b) Permite listar em tela
        static void mostrarEletros(List<Eletro> listaEletros)
        {
            foreach (Eletro e in listaEletros)
            {
                Console.WriteLine("Nome: " + e.nome);
                Console.WriteLine("Potencia: " + e.potencia);
                Console.WriteLine("Tempo Medio de Uso Diario: " + e.tempoMedioUsoDiario);
                Console.WriteLine("-----------------------------");
            }
        }

        // b) Permite salvar em arquivo
        static void salvarEletros(List<Eletro> listaEletros)
        {
            using (StreamWriter sw = new StreamWriter("eletros.txt"))
            {
                foreach (Eletro e in listaEletros)
                {
                    sw.WriteLine(e.nome + ";" + e.potencia + ";" + e.tempoMedioUsoDiario);
                }
            }
        }

        // b) Permite carregar dados já gravados
        static void carregarEletros(List<Eletro> listaEletros)
        {
            if (File.Exists("eletros.txt"))
            {
                using (StreamReader sr = new StreamReader("eletros.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        Console.WriteLine(parts.Length);
                        Eletro e = new Eletro();
                        e.nome = parts[0];
                        e.potencia = double.Parse(parts[1]);
                        e.tempoMedioUsoDiario = double.Parse(parts[2]);
                        listaEletros.Add(e);
                    }
                }
            }
        }

        // c) Permite buscar pelo nome
        static void buscarPorNome(List<Eletro> listaEletros)
        {
            Console.Write("Digite o nome do eletrodomestico: ");
            string nomeBusca = Console.ReadLine() ?? "";
            bool encontrou = false;

            foreach (Eletro e in listaEletros)
            {
                if (e.nome.ToUpper().Contains(nomeBusca.ToUpper()))
                {
                    Console.WriteLine("Nome: " + e.nome);
                    Console.WriteLine("Potencia: " + e.potencia);
                    Console.WriteLine("Tempo Medio de Uso Diario: " + e.tempoMedioUsoDiario);
                   
                    encontrou = true;
                }
            }

            if (!encontrou)
                Console.WriteLine("Nenhum eletrodomestico encontrado.");
        }

        // d) Permite buscar pelos eletrodomésticos que gastam mais que um valor X
        static void buscarPorPotencia(List<Eletro> listaEletros)
        {
            Console.Write("Digite o valor minimo de potencia (kW): ");
            double valor = double.Parse(Console.ReadLine() ?? "0");
            bool encontrou = false;

            foreach (Eletro e in listaEletros)
            {
                if (e.potencia > valor)
                {
                    Console.WriteLine("Nome: " + e.nome);
                    Console.WriteLine("Potencia: " + e.potencia);
                    Console.WriteLine("Tempo Medio de Uso Diario: " + e.tempoMedioUsoDiario);
                    
                    encontrou = true;
                }
            }

            if (!encontrou)
                Console.WriteLine("Nenhum eletrodomestico encontrado com potencia maior que " + valor);
        }

        // e) Calcula e mostra o consumo diário e mensal da casa
        static void calcularConsumo(List<Eletro> listaEletros)
        {
            Console.Write("Digite o valor do kWh em R$: ");
            double valorKwh = double.Parse(Console.ReadLine() ?? "0");

            double consumoDiario = 0;
            foreach (Eletro e in listaEletros)
            {
                consumoDiario += e.potencia * e.tempoMedioUsoDiario;
            }

            double consumoMensal = consumoDiario * 30;

            Console.WriteLine("Consumo diario: " + consumoDiario + " kWh / R$ " + (consumoDiario * valorKwh));
            Console.WriteLine("Consumo mensal: " + consumoMensal + " kWh / R$ " + (consumoMensal * valorKwh));
        }

        // e/f) Calcula o custo total por eletrodoméstico
        static void custoPorEletro(List<Eletro> listaEletros)
        {
            Console.Write("Digite o valor do kWh em R$: ");
            double valorKwh = double.Parse(Console.ReadLine() ?? "0");

            foreach (Eletro e in listaEletros)
            {
                double consumoMensal = e.potencia * e.tempoMedioUsoDiario * 30;
                double custo = consumoMensal * valorKwh;
                Console.WriteLine("Nome: " + e.nome);
                Console.WriteLine("Consumo mensal: " + consumoMensal + " kWh");
                Console.WriteLine("Custo mensal: R$ " + custo);
                
            }
        }
		//menu
        static int menu()
        {
            Console.WriteLine("1 - Adicionar Eletrodomestico");
            Console.WriteLine("2 - Mostrar Eletrodomesticos");
            Console.WriteLine("3 - Buscar pelo nome");
            Console.WriteLine("4 - Calcular Consumo diário e mensal");
            Console.WriteLine("5 - Calcular Custo total por eletrodomestico");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opcao: ");
            return int.Parse(Console.ReadLine() ?? "0");
        }
		//main
        static void Main()
        {
            List<Eletro> listaEletros = new List<Eletro>();
            carregarEletros(listaEletros);
            int opcao;
            do
            {
                opcao = menu();
                switch (opcao)
                {
                    case 1:
                        addEletro(listaEletros);
                        break;
                    case 2:
                        mostrarEletros(listaEletros);
                        break;
                    case 3:
                        buscarPorNome(listaEletros);
                        break;
                    case 4:
                        calcularConsumo(listaEletros);
                        break;
                    case 5:
                        custoPorEletro(listaEletros);
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        salvarEletros(listaEletros);
                        break;
                    default:
                        Console.WriteLine("Opcao invalida!");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            } while (opcao != 0);
        }
    }
}
