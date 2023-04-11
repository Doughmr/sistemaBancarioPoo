using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas
{
    public class Conta
    {
        public long Numero { get; private set; }
        public decimal Saldo { get; private set; }

        private static decimal _maiorSaldo;
        private static long _contaMaiorSaldo;

        public static decimal SaldoTotalGeral { get; private set; }
        public Conta(long numero)
        {
            Numero = numero;
        }

        public void Deposito(decimal valor)
        {
            Saldo += valor;
            SaldoTotalGeral += valor;
        }

        public bool Saque(decimal valor)
        {
            if (valor < 0)
            {
                throw new ArgumentOutOfRangeException("Quantia negativa");
            }
            if (valor <= Saldo)
            {
                Saldo -= valor; // Saldo = Saldo - valor;
                SaldoTotalGeral -= valor;
                return true;
            }
            throw new ArgumentOutOfRangeException("Saque maior que o saldo");
        }

        public bool Transferencia(decimal valor, Conta destino)
        {
            if (Saque(valor))
            {
                destino.Deposito(valor);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Conta {Numero}, saldo {Saldo}";
        }

        public static long ContaMaiorSaldo(List<Conta> contas)
        {
            foreach (Conta conta in contas)
            {
                if (conta.Saldo > _maiorSaldo)
                {
                    _maiorSaldo = conta.Saldo;
                    _contaMaiorSaldo = conta.Numero;
                }
            }
            return _contaMaiorSaldo;
        }
    }
}
