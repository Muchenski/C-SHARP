using _115___Enumerações.Entities;
using _115___Enumerações.Entities.Enums;
using System;

namespace _115___Enumerações {
    class Program {
        static void Main(string[] args) {
            Order order = new Order {
                Id = 1080,
                Moment = DateTime.Now,

                // Convertendo uma string para enum
                Status = Enum.Parse<OrderStatus>("Delivered")

                // Status = OrderStatus.Delivered
            };

            // Convertendo enum pra string
            string txt = OrderStatus.Delivered.ToString();

            Console.WriteLine(order);
        }
    }
}
