using System;
using System.Collections.Generic;
using System.Text;

namespace _133___Ex_02.Entities {
    sealed class ImportedProduct:Product {

        public double CustomsFee { get; set; }

        public ImportedProduct() {
        }

        public ImportedProduct(string name, double price, double customsFee)
            : base(name, price) {
            CustomsFee = customsFee;
        }

        public double TotalPrice() {
            return CustomsFee + Price;
        }

        public override string PriceTag() {
            return base.PriceTag() + $"\nCustoms Fee: {CustomsFee}\nTotal price: {TotalPrice()}";
        }
    }
}
