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

        public static List<ContaCorrente> CreateAccounts()
        {

            var accounts = new List<ContaCorrente>();
            string[] clients = {"Henrique", "Jéssica", "Isabela", "Thales" };

            for (int i = 0; i < clients.Length; i++)
            {
                var newAccount = new ContaCorrente(
                    001,
                    clients[i],
                    Convert.ToInt32($"{i + 1}{i + 1}{i + 1}{i + 1}"),
                    5000
                );

                accounts.Add(newAccount);
            }

            return accounts;
        }

        public static ContaCorrente CreateMyAccount()
        {
            ContaCorrente myAccount = new ContaCorrente(001, "Matheus", 9999, 5000);
            return myAccount;
        }

        public static void ShowAccountDetails(ContaCorrente account)
        {
            Console.WriteLine($"Titular: {account.Titular}" + "\n" + $"Agencia: {account.Agencia}" + "\n" + $"Numero: {account.Numero}" + "\n" + $"Novo Saldo: {account.Saldo}");
            Console.WriteLine("------------------------------------");
            Console.ReadKey();
        }

    }

}
