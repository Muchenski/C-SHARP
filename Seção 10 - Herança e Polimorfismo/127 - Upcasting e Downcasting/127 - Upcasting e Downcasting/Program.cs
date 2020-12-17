using _126___Herança.Entities;
using _127___Upcasting_e_Downcasting.Entities;
using System;

namespace _127___Upcasting_e_Downcasting {
    class Program {
        static void Main(string[] args) {

            Account acc = new Account(1001, "Henrique", 0.0);
            BusinessAccount bacc = new BusinessAccount(1002, "Maria", 0.0, 0.0);

            // Upcasting - SubClasse para SuperClasse

            Account acc1 = bacc;

            Account acc2 = new BusinessAccount(1003, "Bob", 0.0, 0.0);
            Account acc3 = new SavingAccount(1004, "Ana", 0.0, 0.0);

            // Downcasting

            // O DownCasting é o casting de uma superclasse para uma subclasse, 
            // porém a superclasse tem que ser instanciada como uma subclasse(a mesma que você deseja fazer o casting).

            //No caso do Account e do BusinessAccount, podemos fazer isso:

            Account acc4 = new BusinessAccount(1005, "Endrigo", 0.0, 0.0);
            BusinessAccount bacc1 = (BusinessAccount)acc4;

            // No caso da SavingAccount, podemso fazer isso:

            Account acc5 = new SavingAccount(1006, "Henrique", 0.0, 0.0);

            SavingAccount sacc = (SavingAccount)acc5;


            /*
             * Não podemos fazer:
             * 
             * SuperClasse x = new SuperClasse();
             * SubClasse y = (SubClasse) x;
             * 
             * Nem podemos:
             * 
             * SuperClasse y = new SubclasseY();
             * SubClasseX x = (SubClasseX) y;
             * 
             * */


            // Para que não ocorram erros, podemos verificar com condições se
            // o Downcasting é possível:

            Account accTest1 = new BusinessAccount();
            Account accTest2 = new SavingAccount();

            if(accTest1 is BusinessAccount) {
                BusinessAccount accTest4 = (BusinessAccount)accTest1;
                Console.WriteLine("accTest1 é uma instância de BusinessAccount");

                // Agora conseguimos acessar métodos da subclasse.
                accTest4.Loan(100);
            }
            else {
                Console.WriteLine("accTest1 não é instância de BusinessAccount");
            }

            if(accTest2 is SavingAccount) {

                // Outra maneira de realizar Casting, utilizando o operador "as":
                SavingAccount accTest5 = accTest2 as SavingAccount;
                Console.WriteLine("accTest2 é uma instância de SavingAccount");

                // Agora conseguimos acessar métodos da subclasse.
                accTest5.UpdateBalance();
            }
            else {
                Console.WriteLine("accTest2 não é instância de SavingAccount");
            }
        }
    }
}
