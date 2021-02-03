using System;
using System.Threading;
using System.Collections.Generic;
using treinamento_poo.Model;

namespace treinamento_poo.Utils
{
    public class Utils
    {

        public static void SplashScreen()
        {
            Console.WriteLine("──────────────────██████────────────────");
            Console.WriteLine("─────────────────████████─█─────────────");
            Console.WriteLine("─────────────██████████████─────────────");
            Console.WriteLine("─────────────█████████████──────────────");
            Console.WriteLine("──────────────███████████───────────────");
            Console.WriteLine("───────────────██████████───────────────");
            Console.WriteLine("────────────────████████────────────────");
            Console.WriteLine("────────────────▐██████─────────────────");
            Console.WriteLine("────────────────▐██████─────────────────");
            Console.WriteLine("──────────────── ▌─────▌────────────────");
            Console.WriteLine("────────────────███─█████───────────────");
            Console.WriteLine("────────────████████████████────────────");
            Console.WriteLine("──────────███████████─████████──────────");
            Console.WriteLine("────────████████████─────███████────────");
            Console.WriteLine("──────███████████─────────███████───────");
            Console.WriteLine("─────████████████───██─███████████──────");
            Console.WriteLine("────██████████████──────────████████────");
            Console.WriteLine("───████████████████─────█───█████████───");
            Console.WriteLine("──█████████████████████─██───█████████──");
            Console.WriteLine("──█████████████████████──██──██████████─");
            Console.WriteLine("─███████████████████████─██───██████████");
            Console.WriteLine("████████████████████████──────██████████");
            Console.WriteLine("███████████████████──────────███████████");
            Console.WriteLine("─██████████████████───────██████████████");
            Console.WriteLine("─███████████████████████──█████████████─");
            Console.WriteLine("──█████████████████████████████████████─");
            Console.WriteLine("───██████████████████████████████████───");
            Console.WriteLine("─────█████████  MTSA Corp.  ███████───");
            Console.WriteLine("───────██████████████████████████───────");
            Console.WriteLine("─────────────███████████████────────────");

            Thread.Sleep(1000);
            Console.Clear();
        }

        public static void ExibeMenu()
        {

            // Exibe menu de opções para o usuário selecionar
            Console.Clear();
            Console.WriteLine(" ..:: MENU ::..");
            Console.WriteLine();
            Console.WriteLine("1 - Depósito");
            Console.WriteLine("2 - Saque");
            Console.WriteLine("3 - Transferência");
            Console.WriteLine("4 - Consultar Saldo");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("");
        }

        public static List<ContaCorrente> CriarOutrasContas()
        {

            var listaDeContas = new List<ContaCorrente>();
            string[] clientes = {"Henrique", "Jéssica", "Isabela", "Thales" };

            for (int i = 0; i < clientes.Length; i++)
            {
                var novaConta = new ContaCorrente(
                    001,
                    clientes[i],
                    Convert.ToInt32($"{i + 1}{i + 1}{i + 1}{i + 1}"),
                    5000
                );

                listaDeContas.Add(novaConta);
            }

            return listaDeContas;
        }

        public static ContaCorrente CriarMinhaConta()
        {
            ContaCorrente minhaConta = new ContaCorrente(001, "Matheus", 9999, 5000);
            return minhaConta;
        }

    }

}
