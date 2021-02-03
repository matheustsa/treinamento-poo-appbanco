using System;
using System.Collections.Generic;
using System.Threading;
using treinamento_poo.Model;
using static treinamento_poo.Utils.Utils;

namespace treinamento_poo.Service
{
    public class ContaCorrenteService
    {

        public void OperacaoDeposito(ContaCorrente minhaConta)
        {
            Console.Clear();
            Console.WriteLine("=== DEPÓSITO ===" + "\n");
            Console.WriteLine($"Saldo na conta: {minhaConta.Saldo}" + "\n\n");
            Console.WriteLine("Depositar: R$ ");

            var valor = Convert.ToDouble(Console.ReadLine());
            Depositar(valor, minhaConta);

            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Olá {minhaConta.Titular}," + "\n" + "depósito realizado com sucesso!" + "\n" + $"Valor do depósito: {valor}" + "\n");
            Console.WriteLine($"Agencia: {minhaConta.Agencia}" + "\n" + $"Numero: {minhaConta.Numero}" + "\n" + $"Saldo: R${minhaConta.Saldo}");
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.ReadKey();

        }

        private void Depositar(double valor, ContaCorrente conta)
        { 
            conta.Saldo += valor;
        }

        public void OperacaoSaque(ContaCorrente minhaConta)
        {
            Console.Clear();
            Console.WriteLine("=== SAQUE ===" + "\n");
            Console.WriteLine($"Saldo disponível: {minhaConta.Saldo}" + "\n\n");
            Console.WriteLine("Sacar: R$ ");

            var valor = Convert.ToDouble(Console.ReadLine());
            Sacar(valor, minhaConta);

            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Olá {minhaConta.Titular}," + "\n" + "saque realizado com sucesso!" + "\n" + $"Valor da retirada: {valor}" + "\n");
            Console.WriteLine($"Agencia: {minhaConta.Agencia}" + "\n" + $"Numero: {minhaConta.Numero}" + "\n" + $"Saldo: R${minhaConta.Saldo}");
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.ReadKey();
        }

        private void Sacar(double valor, ContaCorrente conta)
        {

            if (valor > conta.Saldo)
            {
                Console.WriteLine($"Não foi possível concluir a transação. Seu saldo R${conta.Saldo} é inferior ao valor do saque R${valor}.");
                Console.ReadKey();
            }
            else
            {
                conta.Saldo -= valor;
            }

        }

        public void OperacaoConsultaSaldo(ContaCorrente minhaConta)
        {
            Console.Clear();
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Dados da sua conta");
            Console.WriteLine();
            Console.WriteLine($"Titular: {minhaConta.Titular}" + "\n" + $"Agencia: {minhaConta.Agencia}" + "\n" + $"Numero: {minhaConta.Numero}" + "\n" + $"Saldo: R${minhaConta.Saldo}");
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.ReadKey();
        }

        public void OperacaoTransferencia(ContaCorrente minhaConta, List<ContaCorrente> clientsList)
        {
            Console.Clear();
            Console.WriteLine("=== TRANSFERÊNCIA ===" + "\n");
            Console.WriteLine($"Saldo disponível: {minhaConta.Saldo}" + "\n\n");
            Console.WriteLine("Transferir: R$ ");

            var valor = Convert.ToDouble(Console.ReadLine());

            ListaOutrasContas(clientsList);

            Console.WriteLine();
            Console.WriteLine("Informe a AGÊNCIA da conta de destino:" + "\n");
            var agencia = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Informe o NÚMERO da conta de destino:" + "\n");
            var numero = Convert.ToDouble(Console.ReadLine());

            var contaDestino = BuscarContaDestino(agencia, numero, clientsList);

            if (contaDestino == null)
            {
                Console.Clear();
                Console.WriteLine("------------------------------------");
                Console.WriteLine();
                Console.WriteLine("ERRO, Conta de destino não encontrada!" + "\n");
                Console.WriteLine("(pressione qualquer tecla para retornar)");
                Console.ReadKey();
            }
            else
            {
                var transferencia = Transferir(valor, minhaConta, contaDestino);

                if (transferencia == true)
                {
                    Console.Clear();
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Conta de destino encontrada!" + "\n");
                    Console.WriteLine("Transferindo..." + "\n");
                    Console.WriteLine();
                    Console.WriteLine("Transferência realizada com sucesso!" + "\n" + $"Seu saldo é de: R${minhaConta.Saldo}");
                    Console.WriteLine();
                    Console.WriteLine("Dados da conta destino");
                    Console.WriteLine($"Nome: {contaDestino.Titular}" + "\n" + $"Agencia: {contaDestino.Agencia}" + "\n" + $"Numero: {contaDestino.Numero}" + "\n" + $"Valor transferido: R${valor}");
                    Console.WriteLine();
                    Console.WriteLine("------------------------------------");
                    Console.ReadKey();
                }
            }
        }
        
        private bool Transferir(double valor, ContaCorrente minhaConta, ContaCorrente contaDestino)
        {
            if (minhaConta.Saldo < valor)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine();
                Console.WriteLine("\n" + $"Não foi possível concluir a transação. Seu saldo R${minhaConta.Saldo} é inferior ao valor que deseja transferir. R${valor}");
                Console.ReadKey();

                return false;
            }
            else
            {

                minhaConta.Saldo -= valor;
                Depositar(valor, contaDestino);

                return true;
            }
        }

        private void ListaOutrasContas(List<ContaCorrente> clientsList)
        {
            Console.WriteLine("Contas disponíveis para transferência:" + "\n\n");
            Console.WriteLine("TITULAR\t\tAGÊNCIA\t\tNÚMERO:" + "\n");
            foreach (var cliente in clientsList)
            {
                Console.WriteLine($"{cliente.Titular}   \t{cliente.Agencia}\t\t{cliente.Numero}\n");
            }
        }

        private ContaCorrente BuscarContaDestino(double agencia, double numero, List<ContaCorrente> clientsList)
        {
            var contaDestino = clientsList.Find(conta => conta.Agencia == agencia && conta.Numero == numero);

            if (contaDestino != null)
            {
                return contaDestino;
            }
            else
            {
                return null;
            }
        }
    }
}
