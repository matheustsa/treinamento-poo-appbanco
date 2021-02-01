namespace treinamento_poo.Model
{
    public class ContaCorrente
    {
        public string Titular { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set; }
        public double Saldo { get; set; }

        public ContaCorrente(int Agencia, string Titular, int Numero, double Saldo)
        {
            this.Titular = Titular;
            this.Agencia = Agencia;
            this.Numero = Numero;
            this.Saldo = Saldo;
        }
    }
}
