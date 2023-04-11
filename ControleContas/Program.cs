
using ControleContas;

try
{
    List<Conta> contas = new List<Conta>();
    Cliente cliente1 = new Cliente("Douglas Moreira Rodrigues", "28202020446", 1998);
    Conta conta1 = new Conta(987654321);
    contas.Add(conta1);
    Conta conta2 = new Conta(654321);
    contas.Add(conta2);

    conta1.Deposito(2000);
    conta2.Deposito(2341.42m);

    Console.WriteLine(conta1.ToString());

    if (conta1.Saque(1100))
    {
        Console.WriteLine($"Saque efetuado com sucesso");
        Console.WriteLine(conta1.ToString());
    }
    else
    {
        Console.WriteLine("O valor do saque é maior que o saldo");
    }

    if (conta1.Transferencia(500, conta2))
    {
        Console.WriteLine(conta1.ToString());
        Console.WriteLine(conta2.ToString());
    }

    Console.WriteLine("A soma de todas as contas é de R$ " + (conta1.Saldo + conta2.Saldo));

    Console.WriteLine($"A conta com maior saldo é {Conta.ContaMaiorSaldo(contas)}");

    Console.WriteLine($"O saldo total geral é de R$ {Conta.SaldoTotalGeral}");

    Console.Write("Informe o núnmero da nova conta: ");
    Conta conta3 = new Conta(Convert.ToInt64(Console.ReadLine()));
    contas.Add(conta3);

    Console.Write($"Informe o valor para deposito na conta {conta3.Numero}: ");

    conta3.Deposito(Decimal.Parse(Console.ReadLine()));

    Console.WriteLine($"O saldo total geral é de R$ {Conta.SaldoTotalGeral}");
}
catch(ArgumentException e)
{
    Console.WriteLine(e.Message);
}