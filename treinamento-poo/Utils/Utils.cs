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

            CreateAccounts();
        }

        private static void CreateAccounts()
        {

            var accounts = new List<ContaCorrente>();

            var myAccount = new ContaCorrente(001, "Matheus", 9999, 5000);
            accounts.Add(myAccount);

            string[] clients = { "Jéssica", "Henrique", "Isabela", "Thales" };

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

            for (int i = 0; i < accounts.Count; i++)
            {
                Console.WriteLine(accounts[i].Agencia);
                Console.WriteLine(accounts[i].Titular);
                Console.WriteLine(accounts[i].Numero);
                Console.WriteLine(accounts[i].Saldo);
                Console.WriteLine();
            }
        }

    }

}
