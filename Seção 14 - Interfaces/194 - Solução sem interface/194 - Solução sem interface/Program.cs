using _194___Solução_sem_interface.Entities;
using _194___Solução_sem_interface.Services;
using System;
using System.Globalization;

namespace _194___Solução_sem_interface {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter rental data");
            Console.Write("Car model: ");
            string model = Console.ReadLine();
            Console.Write("Pickup (dd/MM/yyyy HH:mm): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Return (dd/MM/yyyy HH:mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            CarRental carRental = new CarRental(start, finish, new Vehicle(model));

            RentalService rentalService = new RentalService(hour, day, new BrazilTaxService());

            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("INVOICE:");
            Console.WriteLine(carRental.Invoice);
        }
    }
}

/*
 * Nós podemos implementar métodos na própria classe de entidade, porém métodos que dizem respeito ao próprio objeto (lembra da discussão sobre métodos estáticos e métodos de instância?).
 * 
 * Por exemplo: uma classe Product pode ter preço e quantidade, daí o total desse produto pode ficar na própria classe Product por meio de um método Total().
 *
 * Agora, se você quiser fazer uma busca por produtos por faixa de preços, esta é uma operação que não diz respeito a um produto específico, então neste caso nós colocaríamos a operação em uma classe ProductService:
 * public List<Product> SearchByDate(DateTime start, DateTime end).
 *
 * Resumindo:
 * 
 * A classe de serviço, no caso de serviços relacionado a entidades, é responsável por oferecer operações que não estão relacionadas a uma entidade específica.
 * Podemos ainda ter serviços que oferecem operações não relacionadas a entidades, tais como EmailService, AuthenticationService, etc.
 */
