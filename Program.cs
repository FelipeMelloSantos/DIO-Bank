using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;

                    default:
                        MensagemInvalida();
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar os nossos serviços !");
        }

        private static void MensagemInvalida()
        {
            Console.WriteLine("Informe um valor válido.");
            Continuar();
        }

        private static void Continuar()
        {
            Console.WriteLine();
            Console.WriteLine("Digite qualquer botão para continuar...");
            Console.ReadLine();
        }

        public static double LerValorDouble()
        {
            if (double.TryParse(Console.ReadLine(), out double valorDouble))
            {
                return valorDouble;
            }
            else
            {
                Console.WriteLine("Informe um número válido: ");
                return LerValorDouble();
            }
        }

        public static int LerValorInteiro()
        {
            if (int.TryParse(Console.ReadLine(), out int valorInteiro))
            {
                return valorInteiro;
            }
            else
            {
                Console.WriteLine("Informe um número válido: ");
                return LerValorInteiro();
            }
        }

        private static void Transferir()
        {
            Console.Clear();

            Console.WriteLine("Transferir valores entre contas: ");

            Console.WriteLine("Digite o número da conta de origem: ");
            int indiceContaOrigem = LerValorInteiro();

            Console.WriteLine("Digite o número da conta de destino: ");
            int indiceContaDestino = LerValorInteiro();

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTranferencia = LerValorDouble();

            listContas[indiceContaOrigem].Transferir(valorTranferencia, listContas[indiceContaDestino]);

            Continuar();

        }

        private static void Sacar()
        {
            Console.Clear();

            Console.WriteLine("Sacar valor da conta: ");

            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = LerValorInteiro();

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = LerValorDouble();

            listContas[indiceConta].Sacar(valorSaque);

            Continuar();
        }

        private static void Depositar()
        {
            Console.Clear();

            Console.WriteLine("Sacar valor da conta: ");

            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = LerValorInteiro();

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = LerValorDouble();

            listContas[indiceConta].Depositar(valorDeposito);

            Continuar();
        }

        private static void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("Listar Contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                Continuar();
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];

                Console.Write("#{0} - ", i);

                Console.WriteLine(conta);
            }

            Continuar();
        }

        private static void InserirConta()
        {
            Console.Clear();
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            int entradaTipoConta = LerValorInteiro();

            Console.WriteLine("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = LerValorDouble();

            Console.WriteLine("Digite o crédito: ");
            double entradaCredito = LerValorDouble();

            Conta novaConta = new Conta(
                tipoConta: (TipoConta)entradaTipoConta,
                saldo: entradaSaldo,
                credito: entradaCredito,
                nome: entradaNome
            );

            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.Clear();
            Console.WriteLine("DIO Bank a seu dispor !");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
