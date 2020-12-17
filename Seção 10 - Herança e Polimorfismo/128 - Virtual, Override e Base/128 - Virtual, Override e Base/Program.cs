using _127___Upcasting_e_Downcasting.Entities;
using System;

namespace _128___Virtual__Override_e_Base {
    class Program {
        static void Main(string[] args) {
            Account acc = new Account(1001, "Henrique", 500);
            Account acc2 = new SavingAccount(1002, "Ana", 500, 0.01);
            Account acc3 = new BusinessAccount(1003, "João", 500, 100);

            // Repare que todos são instâncias de Account
            // Mas foram inicializados em subclasses.
            // Os métodos em comum sobrescritos serão executados conforme definido na SUBCLASSE.

            acc.WithDraw(100.0);
            acc2.WithDraw(100.0);
            acc3.WithDraw(100.0);

            Console.WriteLine($"Conta Henrique: {acc.Balance}\nConta Ana: {acc2.Balance}\nConta Jõao: {acc3.Balance}");


            // IMPORTANTE SOBRE DOWNCASTING:

            // acc2 não tem acesso ao InterestRate, apesar de ter sido instânciada em SavingAccount
            // e ter sido passado o valor no parâmetro para o atributo InterestRate.
            SavingAccount teste = (SavingAccount)acc2;
            Console.WriteLine(teste.InterestRate);
            // Porém quando realizamos o casting para SavingAccount, conseguimos acessar o InterestRate,
            // e ela mantém o mesmo valor que foi instanciado.

            // O valor não se perde, apesar de não conseguirmos acessá-lo antes de realizar o DownCasting.
            // Isso é válido para métodos e atributos de objetos que são do tipo superclasse, e foram inicializados
            // em uma subclasse.
        }
    }
}
