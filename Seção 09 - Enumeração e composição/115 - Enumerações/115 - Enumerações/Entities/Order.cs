using _115___Enumerações.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _115___Enumerações.Entities {
    class Order {
        public int Id { get; set; }
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }

        public override string ToString() {
            return "\n" + Id + ", " + Moment + ", " + Status + "\n";
        }
    }
}
