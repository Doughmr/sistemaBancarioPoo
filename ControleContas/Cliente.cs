using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int AnoNascimento { get; set; }

        public Cliente(string nome, string cpf, int anoNascimento)
        {
            Nome = nome;
            if (2022 - anoNascimento < 18)
                throw new ArgumentException("Cliente menor de idade");
            else
                AnoNascimento = anoNascimento;

            if (cpf.Length != 11)
                throw new ArgumentException("CPF deve ter 11 digitos");
            else
                Cpf = cpf;
        }
    }
}
