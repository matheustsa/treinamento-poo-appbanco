using System;
using System.Collections.Generic;
using treinamento_poo.Model;
using static treinamento_poo.Utils.Utils;

namespace treinamento_poo.Service
{
    public class ContaCorrenteService
    {

        public void OperacaoDeposito(ContaCorrente myAccount)
        {
            Console.Clear();
            Console.WriteLine("=== DEPÓSITO ===" + "\n");
            Console.WriteLine($"Saldo na conta: {myAccount.Saldo}" + "\n\n");
            Console.WriteLine("Depositar: R$ ");

            var valor = Convert.ToDouble(Console.ReadLine());
            Depositar(valor, myAccount);

            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Dados da conta do cliente");
            Console.WriteLine();
            Console.WriteLine($"Olá {myAccount.Titular}," + "\n" + "depósito realizado com sucesso!" + "\n" + $"Valor do depósito: {valor}" + "\n");
            Console.WriteLine($"Agencia: {myAccount.Agencia}" + "\n" + $"Numero: {myAccount.Numero}" + "\n" + $"Saldo: {myAccount.Saldo}");
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.ReadKey();

        }

        private void Depositar(double valor, ContaCorrente account)
        { 
            account.Saldo += valor;
        }

        public void OperacaoSaque(ContaCorrente myAccount)
        {
            Console.Clear();
            Console.WriteLine("=== SAQUE ===" + "\n");
            Console.WriteLine($"Saldo disponível: {myAccount.Saldo}" + "\n\n");
            Console.WriteLine("Sacar: R$ ");

            var valor = Convert.ToDouble(Console.ReadLine());
            Sacar(valor, myAccount);

            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Dados da conta do cliente");
            Console.WriteLine();
            Console.WriteLine($"Olá {myAccount.Titular}," + "\n" + "saque realizado com sucesso!" + "\n" + $"Valor da retirada: {valor}" + "\n");
            Console.WriteLine($"Agencia: {myAccount.Agencia}" + "\n" + $"Numero: {myAccount.Numero}" + "\n" + $"Saldo: {myAccount.Saldo}");
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.ReadKey();
        }

        private void Sacar(double valor, ContaCorrente account)
        {

            if (valor > account.Saldo)
            {
                Console.WriteLine($"Não foi possível concluir a transação. Seu saldo {account.Saldo} é inferior ao valor do saque {valor}.");
                Console.ReadKey();
            }
            else
            {
                account.Saldo -= valor;
            }

        }

        internal void OperacaoConsultaSaldo(ContaCorrente myAccount)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Dados da conta do cliente");
            Console.WriteLine();
            Console.WriteLine($"Titular: {myAccount.Titular}" + $"Agencia: {myAccount.Agencia}" + "\n" + $"Numero: {myAccount.Numero}" + "\n" + $"Saldo: {myAccount.Saldo}");
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.ReadKey();
        }

        public void OperacaoTransferencia(ContaCorrente myAccount, ContaCorrente contaDestino)
        {
            Console.WriteLine();
            Console.WriteLine("Digite seu nome: " + "\n");
            var nome = Console.ReadLine();
            Console.WriteLine("Informe um valor que deseja transferir: " + "\n");

            var valor = Convert.ToDouble(Console.ReadLine());

            var transferencia = Transferir(valor, myAccount.Saldo, contaDestino);

            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Dados da conta do cliente");
            Console.WriteLine();
            Console.WriteLine($"Olá {nome}," + "\n" + "a transferência realizada com sucesso!" + "\n");
        }

        private bool Transferir(double valor, double saldo, ContaCorrente contaDestino)
        {
            if (saldo < valor)
            {
                Console.WriteLine($"Não foi possível concluir a transação. Seu saldo {saldo} é inferior ao valor que deseja transferir. {saldo}");
                Console.ReadKey();
            }

            saldo -= valor;

            Depositar(valor, contaDestino);
            Console.WriteLine($"Transferência realizada com sucesso! Seu saldo é de: {saldo}");
            Console.WriteLine();
            Console.WriteLine("Dados da conta destino");
            Console.WriteLine($"Nome: {contaDestino.Titular}" + "\n" + $"Agencia: {contaDestino.Agencia}" + "\n" + $"Numero: {contaDestino.Numero}" + "\n" + $"Valor transferido: {valor}");
            Console.ReadKey();
            Console.WriteLine("------------------------------------");
            Console.ReadKey();
            return true;
        }
    }
}
