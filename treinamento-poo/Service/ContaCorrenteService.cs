using System;
using System.Collections.Generic;
using System.Threading;
using treinamento_poo.Model;
using static treinamento_poo.Utils.Utils;

namespace treinamento_poo.Service
{
    public class ContaCorrenteService
    {

        public void OperacaoDeposito(ContaCorrente contaCorrente)
        {
            Console.Clear();
            Console.WriteLine("=== DEPÓSITO ===" + "\n");
            Console.WriteLine($"Saldo na conta: {contaCorrente.Saldo}" + "\n\n");
            Console.WriteLine("Depositar: R$ ");

            var valor = Convert.ToDouble(Console.ReadLine());
            Depositar(valor, contaCorrente);

            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Olá {contaCorrente.Titular}," + "\n" + "depósito realizado com sucesso!" + "\n" + $"Valor do depósito: {valor}" + "\n");
            Console.WriteLine($"Agencia: {contaCorrente.Agencia}" + "\n" + $"Numero: {contaCorrente.Numero}" + "\n" + $"Saldo: R${contaCorrente.Saldo}");
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.ReadKey();

        }

        private void Depositar(double valor, ContaCorrente contaCorrente)
        { 
            contaCorrente.Saldo += valor;
        }

        public void OperacaoSaque(ContaCorrente contaCorrente)
        {
            Console.Clear();
            Console.WriteLine("=== SAQUE ===" + "\n");
            Console.WriteLine($"Saldo disponível: {contaCorrente.Saldo}" + "\n\n");
            Console.WriteLine("Sacar: R$ ");

            var valor = Convert.ToDouble(Console.ReadLine());
            Sacar(valor, contaCorrente);

            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Olá {contaCorrente.Titular}," + "\n" + "saque realizado com sucesso!" + "\n" + $"Valor da retirada: {valor}" + "\n");
            Console.WriteLine($"Agencia: {contaCorrente.Agencia}" + "\n" + $"Numero: {contaCorrente.Numero}" + "\n" + $"Saldo: R${contaCorrente.Saldo}");
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.ReadKey();
        }

        private void Sacar(double valor, ContaCorrente contaCorrente)
        {

            if (valor > contaCorrente.Saldo)
            {
                Console.WriteLine($"Não foi possível concluir a transação. Seu saldo R${contaCorrente.Saldo} é inferior ao valor do saque R${valor}.");
                Console.ReadKey();
            }
            else
            {
                contaCorrente.Saldo -= valor;
            }

        }

        public void OperacaoConsultaSaldo(ContaCorrente contaCorrente)
        {
            Console.Clear();
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Dados da sua conta");
            Console.WriteLine();
            Console.WriteLine($"Titular: {contaCorrente.Titular}" + "\n" + $"Agencia: {contaCorrente.Agencia}" + "\n" + $"Numero: {contaCorrente.Numero}" + "\n" + $"Saldo: R${contaCorrente.Saldo}");
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.ReadKey();
        }

        public void OperacaoTransferencia(ContaCorrente contaCorrente, List<ContaCorrente> listaDeContas)
        {
            Console.Clear();
            Console.WriteLine("=== TRANSFERÊNCIA ===" + "\n");
            Console.WriteLine($"Saldo disponível: {contaCorrente.Saldo}" + "\n\n");
            Console.WriteLine("Transferir: R$ ");

            var valor = Convert.ToDouble(Console.ReadLine());

            // Só pra facilitar...
            ListarOutrasContas(listaDeContas);

            Console.WriteLine();
            Console.WriteLine("Informe a AGÊNCIA da conta de destino:" + "\n");
            var agencia = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Informe o NÚMERO da conta de destino:" + "\n");
            var numero = Convert.ToDouble(Console.ReadLine());

            var contaDestino = BuscarContaDestino(agencia, numero, listaDeContas);

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
                var transferencia = Transferir(valor, contaCorrente, contaDestino);

                if (transferencia == true)
                {
                    Console.Clear();
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Conta de destino encontrada!" + "\n");
                    Console.WriteLine("Transferindo..." + "\n");
                    Console.WriteLine();
                    Console.WriteLine("Transferência realizada com sucesso!" + "\n" + $"Seu saldo é de: R${contaCorrente.Saldo}");
                    Console.WriteLine();
                    Console.WriteLine("Dados da conta destino");
                    Console.WriteLine($"Nome: {contaDestino.Titular}" + "\n" + $"Agencia: {contaDestino.Agencia}" + "\n" + $"Numero: {contaDestino.Numero}" + "\n" + $"Valor transferido: R${valor}");
                    Console.WriteLine();
                    Console.WriteLine("------------------------------------");
                    Console.ReadKey();
                }
            }
        }
        
        private bool Transferir(double valor, ContaCorrente contaCorrente, ContaCorrente contaDestino)
        {
            if (contaCorrente.Saldo < valor)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine();
                Console.WriteLine("\n" + $"Não foi possível concluir a transação. Seu saldo R${contaCorrente.Saldo} é inferior ao valor que deseja transferir. R${valor}");
                Console.ReadKey();

                return false;
            }
            else
            {

                contaCorrente.Saldo -= valor;
                Depositar(valor, contaDestino);

                return true;
            }
        }

        private void ListarOutrasContas(List<ContaCorrente> listaDeContas)
        {
            Console.WriteLine("Contas disponíveis para transferência:" + "\n\n");
            Console.WriteLine("TITULAR\t\tAGÊNCIA\t\tNÚMERO:" + "\n");
            foreach (var conta in listaDeContas)
            {
                Console.WriteLine($"{conta.Titular}   \t{conta.Agencia}\t\t{conta.Numero}\n");
            }
        }

        private ContaCorrente BuscarContaDestino(double agencia, double numero, List<ContaCorrente> listaDeContas)
        {
            var contaDestino = listaDeContas.Find(conta => conta.Agencia == agencia && conta.Numero == numero);

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
