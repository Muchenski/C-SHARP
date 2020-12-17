using System;
using System.Collections.Generic;
using System.Text;

namespace Ex_03.Entities {
    class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product() {
        }

        public Product(int id, string name, double price) {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
