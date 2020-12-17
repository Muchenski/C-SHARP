using _199___Exercício.entities;
using _199___Exercício.services;
using System;

namespace _199___Exercício {
    class Program {
        static void Main(string[] args) {

            Contract contract = new Contract();
            Console.WriteLine("Enter the contract data: ");
            Console.WriteLine("Number:");
            contract.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Date(dd/MM/yyyy): ");
            contract.DataContrato = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Contract value: ");
            contract.ValorTotal = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of installments: ");
            int months = Convert.ToInt32(Console.ReadLine());

            ContractService service = new ContractService(new PaypalService());
            service.ProcessContract(contract, months);

            foreach(Installment installment in contract.installments) {
                Console.WriteLine(installment);
            }
        }
    }
}
