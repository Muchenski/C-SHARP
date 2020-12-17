using System;
using System.Collections.Generic;
using System.Text;

namespace _133___Ex_02.Entities {
    class Product {

        public string Name { get; set; }
        public double Price { get; set; }

        public Product() {
        }

        public Product(string name, double price) {
            Name = name;
            Price = price;
        }

        public virtual string PriceTag() {
            return $"Name: {Name}\nPrice: {Price}";
        }
    }
}
