using System;
using treinamento_poo.Service;
using treinamento_poo.Model;
using System.Threading;
using static treinamento_poo.Utils.Utils;
using System.Collections.Generic;

namespace treinamento_poo
{
    public class Program
    {
        static void Main(string[] args)
        {

            SplashScreen();
            ContaCorrente minhaConta = CriarMinhaConta();
            List<ContaCorrente> listaDeContas = CriarOutrasContas();

            {
                while (!Console.KeyAvailable)
                {

                    ExibeMenu();
                    var opcao = Console.ReadKey();

                    switch (opcao.KeyChar)
                    {
                        case '1':
                            new ContaCorrenteService().OperacaoDeposito(minhaConta);
                            break;

                        case '2':
                            new ContaCorrenteService().OperacaoSaque(minhaConta);
                            break;

                        case '3':
                            new ContaCorrenteService().OperacaoTransferencia(minhaConta, listaDeContas);
                            break;

                        case '4':
                            new ContaCorrenteService().OperacaoConsultaSaldo(minhaConta);
                            break;
                        case '0':
                            Console.WriteLine("\n\nAgradecemos à preferencia!");
                            Thread.Sleep(1000);
                            System.Environment.Exit(1);
                            break;
                        default:
                            Console.WriteLine("\nOpção inválida!\n\n");
                            Thread.Sleep(500);
                            Console.Clear();
                            break;
                    }
                }
                

            } while (Console.ReadKey(true).Key != 0);

        }
    }
}
