using Ex_03.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex_03.Entities {
    class Order {
        public int Id { get; set; }
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }

        public Client Client { get; set; }

        List<OrderItem> Items = new List<OrderItem>();

        public Order() {
        }

        public Order(int id, DateTime moment, OrderStatus status, Client client) {
            Id = id;
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item) {
            Items.Add(item);
        }

        public void RemomeItem(OrderItem item) {
            Items.Remove(item);
        }

        public double Total() {

            double total = 0;

            foreach(OrderItem item in Items) {
                total += item.SubTotal();
            }

            return total;
        }

        public override string ToString() {

            StringBuilder sb = new StringBuilder();

            foreach(OrderItem item in Items) {
                sb.AppendLine(item.ToString() + "\n");
            }

            return $"Client: {Client}\n\nOrder: Id: {Id}\nMoment: {Moment}\nStatus: {Status}\nTotal: {Total()}\n\nDetails: {sb}";
        }
    }
}
