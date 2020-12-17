using System;
using System.Collections.Generic;
using System.Text;

namespace Ex_03.Entities {
    class OrderItem {
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Product Product;

        public OrderItem() {
        }

        public OrderItem(int quantity, double price, Product product) {
            Quantity = quantity;
            Price = price;
            Product = product;
        }

        public double SubTotal() {
            return Quantity * Price;
        }

        public override string ToString() {
            return $"Product: {Product.Name}\nUnit Price: {Price}\nQuantity: {Quantity}\nSubtotal: {SubTotal()}";
        }
    }
}
